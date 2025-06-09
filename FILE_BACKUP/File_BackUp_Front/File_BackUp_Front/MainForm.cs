using DevExpress.DataAccess.DataFederation;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace File_BackUp_Front
{

    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        string _userId, _userName;
        bool _isAdmin;

        public class ProgressInfo
        {
            public int Percent { get; set; }
            public string Message { get; set; }
        }

        private System.Windows.Forms.Timer scheduleTimer;
        private Progress<ProgressInfo> progress;
        public MainForm(string userId, string userName, bool isAdmin)
        {
            InitializeComponent();
            _userId = userId;
            _userName = userName;
            _isAdmin = isAdmin;


            source_folder.Image = Properties.Resources.source_folder;
            target_folder.Image = Properties.Resources.target_folder;
            source_folder2.Image = Properties.Resources.source_folder;
            target_folder2.Image = Properties.Resources.target_folder;

           

            this.Text = $"백업 프로그램 - {_userName} ({(_isAdmin ? "관리자" : "일반 사용자")})";
        }

        private async void BtnBackUp_Click(object sender, EventArgs e)
        {
            string source = txtSource.Text.Trim();
            string target = txtTarget.Text.Trim();

            // 예약 정보 조회
            var reservation = LoadReservationInfo(source, target);  // << 여기!

            // Progress 콜백 등록
            progress = new Progress<ProgressInfo>(info =>
            {
                Backup_progressBar.Position = info.Percent;
                progress_list.Text += info.Message + Environment.NewLine;
                progress_list.SelectionStart = progress_list.Text.Length;
                progress_list.ScrollToCaret();
            });
            Backup_progressBar.Position = 0;
            progress_list.Text = "";

            if (reservation == null)
            {
                await RunBackupNow(); // 예약 없으면 즉시 백업
            }
            else
            {
                ShowReservationInfo(reservation);
                StartBackupSchedule(reservation);
            }
        }


        private string FormatSize(long bytes)
        {
            if (bytes >= 1024 * 1024)
                return $"{(bytes / (1024.0 * 1024)):N2} MB";
            if (bytes >= 1024)
                return $"{(bytes / 1024.0):N2} KB";
            return $"{bytes} byte";
        }



        private void CopyAllWithProgress(string sourcePath, string targetPath, IProgress<ProgressInfo> progress)
        {
            if (System.IO.File.Exists(sourcePath))
            {
                string fileName = System.IO.Path.GetFileName(sourcePath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                System.IO.File.Copy(sourcePath, destFile, true);
                progress?.Report(new ProgressInfo { Percent = 100, Message = $"복사 완료: {fileName}" });
                return;
            }

            string folderName = System.IO.Path.GetFileName(sourcePath.TrimEnd(System.IO.Path.DirectorySeparatorChar));
            string destFolder = System.IO.Path.Combine(targetPath, folderName);
            if (!System.IO.Directory.Exists(destFolder))
                System.IO.Directory.CreateDirectory(destFolder);

            var allFiles = System.IO.Directory.GetFiles(sourcePath, "*.*", System.IO.SearchOption.AllDirectories);
            int total = allFiles.Length;
            int count = 0;

            foreach (var dirPath in System.IO.Directory.GetDirectories(sourcePath, "*", System.IO.SearchOption.AllDirectories))
            {
                string subDir = dirPath.Replace(sourcePath, destFolder);
                if (!System.IO.Directory.Exists(subDir))
                    System.IO.Directory.CreateDirectory(subDir);
            }

            foreach (var filePath in allFiles)
            {
                string destFile = filePath.Replace(sourcePath, destFolder);
                System.IO.File.Copy(filePath, destFile, true);
                count++;
                int percent = (int)((count / (double)total) * 100);

                long fileSize = new System.IO.FileInfo(filePath).Length;
                string fileSizeText = FormatSize(fileSize);
                progress?.Report(new ProgressInfo
                {
                    Percent = percent,
                    Message = $"복사 중 -  파일명 : {System.IO.Path.GetFileName(filePath)} 파일 사이즈: {fileSize} ({count}/{total})"
                });
            }
        }



        private bool CheckIntegrity(string source, string target)
        {
            // 단일 파일 복사면 기존 방식
            if (System.IO.File.Exists(source))
            {
                string fileName = System.IO.Path.GetFileName(source);
                string srcFile = source;
                string tgtFile = System.IO.Path.Combine(target, fileName);
                return GetFileHash(srcFile) == GetFileHash(tgtFile);
            }

            // 폴더 복사면, 모든 파일을 비교
            string srcRoot = source.TrimEnd(System.IO.Path.DirectorySeparatorChar);
            string tgtRoot = System.IO.Path.Combine(target, System.IO.Path.GetFileName(srcRoot));

            var srcFiles = System.IO.Directory.GetFiles(srcRoot, "*.*", System.IO.SearchOption.AllDirectories);
            var tgtFiles = System.IO.Directory.GetFiles(tgtRoot, "*.*", System.IO.SearchOption.AllDirectories);

            if (srcFiles.Length != tgtFiles.Length) return false;

            for (int i = 0; i < srcFiles.Length; i++)
            {
                // 상대 경로 맞추기
                string relPath = srcFiles[i].Substring(srcRoot.Length);
                string tgtFile = tgtRoot + relPath;
                if (!System.IO.File.Exists(tgtFile)) return false;
                if (GetFileHash(srcFiles[i]) != GetFileHash(tgtFile)) return false;
            }
            return true;
        }


        private string GetFileHash(string filePath)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            using (var stream = System.IO.File.OpenRead(filePath))
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        private void SaveBackupHistory(string source, string target, bool isSuccess, string errorMsg)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string fileName = System.IO.File.Exists(source)
                ? System.IO.Path.GetFileName(source)
                : "";

            // 🔻 단일 파일/폴더 전체 크기 합산
            long fileSize = 0;
            if (System.IO.File.Exists(source))
            {
                fileSize = new System.IO.FileInfo(source).Length;
            }
            else if (System.IO.Directory.Exists(source))
            {
                // 폴더: 모든 파일 합산
                fileSize = System.IO.Directory.GetFiles(source, "*.*", System.IO.SearchOption.AllDirectories)
                           .Select(f => new System.IO.FileInfo(f).Length)
                           .Sum();
            }

            string sql = "INSERT INTO TEST_BackupHistory (UserID, SourcePath, TargetPath, FileName, FileSize, BackupDate, IsSuccess, IntegrityCheck, ErrorMsg) " +
                         "VALUES (@userId, @src, @tgt, @file, @size, @date, @succ, @integrity, @err)";
            using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
            using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@userId", _userId);
                cmd.Parameters.AddWithValue("@src", source);
                cmd.Parameters.AddWithValue("@tgt", target);
                cmd.Parameters.AddWithValue("@file", fileName);
                cmd.Parameters.AddWithValue("@size", fileSize);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@succ", isSuccess ? 1 : 0);
                cmd.Parameters.AddWithValue("@integrity", isSuccess ? "성공" : "실패");
                cmd.Parameters.AddWithValue("@err", errorMsg ?? "");
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }



        private void LoadHistory()
        {

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql = @"SELECT * FROM TEST_BackupHistory ORDER BY BackupDate DESC";
            DataTable dt = new DataTable();
            using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
            using (var da = new System.Data.SqlClient.SqlDataAdapter(sql, conn))

            {
                da.Fill(dt);
            }
            gridControl1.DataSource = dt;
            gridView1.Columns["FileSize"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridView1.Columns["FileSize"].DisplayFormat.FormatString = "N0";

            gridView1.Columns["UserID"].Caption = "사용자ID";
            gridView1.Columns["SourcePath"].Caption = "소스 경로";
            gridView1.Columns["TargetPath"].Caption = "타겟 경로";
            gridView1.Columns["FileName"].Caption = "파일명";
            gridView1.Columns["FileSize"].Caption = "파일크기(byte)";
            gridView1.Columns["BackupDate"].Caption = "백업 일시";
            gridView1.Columns["IsSuccess"].Caption = "성공 여부";
            gridView1.Columns["IsRecovery"].Visible = false;
            gridView1.Columns["RecoveryDate"].Visible = false;
            gridView1.Columns["RecoveredBy"].Visible = false;
            gridView1.Columns["IntegrityCheck"].Visible = false;
            gridView1.Columns["ErrorMsg"].Visible = false;
        }
        private void MainForm_Load_1(object sender, EventArgs e)
        {
            string source = txtSource.Text.Trim();
            string target = txtTarget.Text.Trim();
            txtTarget.Text = @"C:\MyBackup";
            LoadHistory();
            gridView1.OptionsBehavior.Editable = _isAdmin;

            var reservation = LoadReservationInfo(source, target);
            ShowReservationInfo(reservation);
        }
        private void source_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = fbd.SelectedPath;
                }
            }

        }

        private void target_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtTarget.Text = fbd.SelectedPath;
                }
            }

        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            using (var form = new Schedule(_userId, _userName, _isAdmin, txtSource.Text, txtTarget.Text))
            {
                form.ShowDialog();
            }

        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                using (var dlg = new BackupDetailForm(row))
                {
                    dlg.ShowDialog();
                }
            }
        }

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = fbd.SelectedPath;
                }
            }

        }

        private void simpleButton8_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtTarget.Text = fbd.SelectedPath;
                }
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtTarget.Text = fbd.SelectedPath;
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtTarget.Text = fbd.SelectedPath;
                }
            }
        }
        private DataRow LoadReservationInfo(string source, string target)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql = @"SELECT TOP 1 * FROM TEST_BackupSchedule 
                   WHERE UserID=@userId AND IsActive=1 
                   AND SourcePath=@src AND TargetPath=@tgt
                   ORDER BY CreatedDate DESC";
            　
            using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
            using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@userId", _userId);
                cmd.Parameters.AddWithValue("@src", source);
                cmd.Parameters.AddWithValue("@tgt", target);
                conn.Open();
                using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0];
                }
            }
            return null;
        }
        private void ShowReservationInfo(DataRow row)
        {
            if (row == null)
            {
                Schedule_list.Text += "[예약 없음]\r\n";
                return;
            }
            Schedule_list.Text += $"[예약정보] 유형: {row["ScheduleType"]}, 값: {row["ScheduleValue"]}\r\n";
        }


        private void StartBackupSchedule(DataRow reservation)
        {
            string scheduleType = reservation["ScheduleType"].ToString();
            string scheduleValue = reservation["ScheduleValue"].ToString();
            DateTime now = DateTime.Now;
            DateTime? nextTime = null;

            if (scheduleType == "Daily")
            {
                TimeSpan t = TimeSpan.Parse(scheduleValue);
                nextTime = new DateTime(now.Year, now.Month, now.Day, t.Hours, t.Minutes, 0);
                if (nextTime <= now)
                    nextTime = nextTime.Value.AddDays(1);
            }
            else if (scheduleType == "Weekly")
            {
                var split = scheduleValue.Split(' ');
                string[] weekDays = split[0].Split(',');
                TimeSpan t = TimeSpan.Parse(split[1]);
                nextTime = null;
                for (int addDay = 0; addDay <= 7; addDay++)
                {
                    var day = now.AddDays(addDay);
                    var weekShort = day.ToString("ddd", System.Globalization.CultureInfo.InvariantCulture);
                    if (weekDays.Contains(weekShort, StringComparer.OrdinalIgnoreCase))
                    {
                        var tempTime = new DateTime(day.Year, day.Month, day.Day, t.Hours, t.Minutes, 0);
                        if (tempTime > now)
                        {
                            nextTime = tempTime;
                            break;
                        }
                    }
                }
                if (nextTime == null)
                    nextTime = now.AddDays(1); // Fallback
            }
            else if (scheduleType == "Monthly")
            {
                var split = scheduleValue.Split(' ');
                int day = int.Parse(split[0]);
                TimeSpan t = TimeSpan.Parse(split[1]);
                var thisMonth = new DateTime(now.Year, now.Month, day, t.Hours, t.Minutes, 0);
                if (thisMonth > now)
                    nextTime = thisMonth;
                else
                    nextTime = thisMonth.AddMonths(1);
            }
            else
            {
                progress_list.Text += "[알 수 없는 예약 유형]\r\n";
                return;
            }

            if (nextTime != null)
            {
                TimeSpan wait = nextTime.Value - now;
                progress_list.Text += $"[다음 예약] {nextTime.Value}\r\n";
                if (scheduleTimer != null) scheduleTimer.Stop();
                scheduleTimer = new System.Windows.Forms.Timer();
                scheduleTimer.Interval = Math.Min((int)wait.TotalMilliseconds, int.MaxValue - 1); // 최대치 제한
                scheduleTimer.Tick += async (s, e) =>
                {
                    scheduleTimer.Stop();
                    await RunBackupNow(); // 예약 백업
                    StartBackupSchedule(reservation); // 반복 예약
                };
                scheduleTimer.Start();
            }
        }

        private async Task RunBackupNow()
        {
            string source = txtSource.Text.Trim();
            string target = txtTarget.Text.Trim();

            try
            {
                await Task.Run(() => CopyAllWithProgress(source, target, progress));
                bool isValid = CheckIntegrity(source, target);
                SaveBackupHistory(source, target, isValid, null);
                XtraMessageBox.Show("백업 완료!");
                LoadHistory();
            }
            catch (Exception ex)
            {
                SaveBackupHistory(source, target, false, ex.Message);
                XtraMessageBox.Show("백업 실패: " + ex.Message);
            }
        }


        private void btn_Restore_Click(object sender, EventArgs e)
        {

        }

        private void gridControl1_MouseHover(object sender, EventArgs e)
        {
           
        }
    }
}