using DevExpress.DataAccess.DataFederation;
using DevExpress.DataProcessing.InMemoryDataProcessor;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace File_BackUp_Front
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        string _userId, _userName;
        bool _isAdmin;
        private volatile bool _isPaused = false;
        private bool _isBackupRunning = false;
        private System.Windows.Forms.Timer scheduleTimer;
        private IProgress<ProgressInfo> progress;
        private bool _useChecksum = true;
        public class ProgressInfo
        {
            public string Message { get; set; }
            public bool? IsChecksumValid { get; set; }
        }

        public MainForm(string userId, string userName, bool isAdmin)
        {
            InitializeComponent();
            _userId = userId;
            _userName = userName;
            _isAdmin = isAdmin;
            Insert_User.Visible = _isAdmin;

            source_folder.Image = Properties.Resources.source_folder;
            target_folder.Image = Properties.Resources.target_folder;
            source_folder2.Image = Properties.Resources.source_folder;
            target_folder2.Image = Properties.Resources.target_folder;

            this.Text = $"백업 프로그램 - {_userName} ({(_isAdmin ? "관리자" : "일반 사용자")})";
        }

        // 백업 시작/일시정지/재개 버튼 클릭 시 동작
        private async void BtnBackUp_Click(object sender, EventArgs e)
        {
            if (!_isBackupRunning)
            {
                // 백업 시작
                BtnBackUp.Text = "일시정지";
                _isBackupRunning = true;
                _isPaused = false;

                string source = txtSource.Text.Trim();
                string target = txtTarget.Text.Trim();

                var reservation = LoadReservationInfo(source, target);

                progress = new Progress<ProgressInfo>(info =>
                {
                    progress_list.Text += info.Message + Environment.NewLine;
                    progress_list.SelectionStart = progress_list.Text.Length;
                    progress_list.ScrollToCaret();
                });
                progress_list.Text = "";

                try
                {
                    if (reservation == null)
                    {
                        await RunBackupNow();
                    }
                    else
                    {
                        ShowReservationInfo(reservation);
                        StartBackupSchedule(reservation);
                    }
                }
                finally
                {
                    BtnBackUp.Text = "백업 시작";
                    _isBackupRunning = false;
                }
            }
            else
            {
                if (!_isPaused)
                {
                    _isPaused = true;
                    BtnBackUp.Text = "재개";
                    progress?.Report(new ProgressInfo { Message = " 백업이 일시정지되었습니다." });
                }
                else
                {
                    _isPaused = false;
                    BtnBackUp.Text = "일시정지";
                    progress?.Report(new ProgressInfo { Message = "백업이 재개되었습니다." });
                }
            }
        }
        // 파일 크기 보기 좋게 포맷
        private string FormatSize(long bytes)
        {
            if (bytes >= 1024 * 1024)
                return $"{(bytes / (1024.0 * 1024)):N2} MB";
            if (bytes >= 1024)
                return $"{bytes / 1024.0:N2} KB";
            return $"{bytes} byte";
        }

        // 일시정지 상태일 때 대기 (Pause 기능)

        private void WaitIfPaused()
        {
            while (_isPaused)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        // 파일 복사(버퍼 단위) - Pause 상태 실시간 반영
        private void CopyFileWithPause(string sourceFile, string destFile)
        {
            const int bufferSize = 1024 * 1024; // 1MB
            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    WaitIfPaused();
                    destStream.Write(buffer, 0, bytesRead);
                }
            }
        }

        // 폴더 전체 복사, 복사 진행 상황 Progress로 전달, Pause랑 resume 반영
        private void CopyAllWithProgress(string sourcePath, string targetPath, IProgress<ProgressInfo> progress)
        {
            if (System.IO.File.Exists(sourcePath))
            {
                WaitIfPaused();
                string fileName = System.IO.Path.GetFileName(sourcePath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);

                try
                {
                    CopyFileWithPause(sourcePath, destFile);
                }
                catch (System.IO.IOException ioEx)
                {
                    progress?.Report(new ProgressInfo
                    {
                        Message = $"[복사 실패: 다른 프로세스에서 사용 중] {fileName} - {ioEx.Message}"
                    });
                    return;
                }

                progress?.Report(new ProgressInfo { Message = $"복사 완료: {fileName}" });
                return;
            }

            string folderName = System.IO.Path.GetFileName(sourcePath.TrimEnd(System.IO.Path.DirectorySeparatorChar));
            string destFolder = System.IO.Path.Combine(targetPath, folderName);
            if (!System.IO.Directory.Exists(destFolder))
                System.IO.Directory.CreateDirectory(destFolder);

            string[] allFiles = null;
            try
            {
                allFiles = System.IO.Directory.GetFiles(sourcePath, "*.*", System.IO.SearchOption.AllDirectories);
            }
            catch (Exception ex)
            {
                progress?.Report(new ProgressInfo
                {
                    Message = $"[폴더 내 파일 목록 조회 실패] {ex.Message}"
                });
                return;
            }
            int total = allFiles.Length;
            int count = 0;

            foreach (var dirPath in System.IO.Directory.GetDirectories(sourcePath, "*", System.IO.SearchOption.AllDirectories))
            {
                WaitIfPaused();

                string subDir = dirPath.Replace(sourcePath, destFolder);
                if (!System.IO.Directory.Exists(subDir))
                    System.IO.Directory.CreateDirectory(subDir);
            }

            foreach (var filePath in allFiles)
            {
                WaitIfPaused();

                string destFile = filePath.Replace(sourcePath, destFolder);

                try
                {
                    CopyFileWithPause(filePath, destFile);
                }
                catch (System.IO.IOException ioEx)
                {
                    progress?.Report(new ProgressInfo
                    {
                        Message = $"[복사 실패: 다른 프로세스에서 사용 중] {System.IO.Path.GetFileName(filePath)} - {ioEx.Message}"
                    });
                    continue;
                }

                string srcHash = _useChecksum ? GetFileHash(filePath) : null;
                string tgtHash = _useChecksum ? GetFileHash(destFile) : null;
                bool isValid = !_useChecksum || (srcHash == tgtHash);
                count++;
                long fileSize = new System.IO.FileInfo(filePath).Length;
                progress?.Report(new ProgressInfo
                {
                    Message = _useChecksum
                              ? $"[{(isValid ? "체크섬 검사 통과" : "체크섬 검사 통과 안됨")}] 복사 중... {System.IO.Path.GetFileName(filePath)} ({count}/{total}), 파일 크기: {fileSize} byte"
                              : $"[체크섬 미검사] 복사 중... {System.IO.Path.GetFileName(filePath)} ({count}/{total}), 파일 크기: {fileSize} byte",
                    IsChecksumValid = isValid
                });
            }
        }
        // 복사한 파일/폴더 무결성(체크섬) 검사 -체크박스로 제어 가능

        private bool CheckIntegrity(string source, string target)
        {
            if (System.IO.File.Exists(source))
            {
                string fileName = System.IO.Path.GetFileName(source);
                string srcFile = source;
                string tgtFile = System.IO.Path.Combine(target, fileName);
                return GetFileHash(srcFile) == GetFileHash(tgtFile);
            }

            string srcRoot = source.TrimEnd(System.IO.Path.DirectorySeparatorChar);
            string tgtRoot = System.IO.Path.Combine(target, System.IO.Path.GetFileName(srcRoot));
            var srcFiles = System.IO.Directory.GetFiles(srcRoot, "*.*", System.IO.SearchOption.AllDirectories);
            var tgtFiles = System.IO.Directory.GetFiles(tgtRoot, "*.*", System.IO.SearchOption.AllDirectories);

            if (srcFiles.Length != tgtFiles.Length) return false;

            for (int i = 0; i < srcFiles.Length; i++)
            {
                string relPath = srcFiles[i].Substring(srcRoot.Length);
                string tgtFile = tgtRoot + relPath;
                if (!System.IO.File.Exists(tgtFile)) return false;
                if (GetFileHash(srcFiles[i]) != GetFileHash(tgtFile)) return false;
            }
            return true;
        }
        // 파일의 SHA256 해시값 계산

        private string GetFileHash(string filePath)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            using (var stream = System.IO.File.OpenRead(filePath))
            {
                var hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
        // 백업 결과를 DB에 기록

        private void SaveBackupHistory(string source, string target, bool isSuccess, string errorMsg)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string fileName = System.IO.File.Exists(source)
                ? System.IO.Path.GetFileName(source)
                : "";

            long fileSize = 0;
            if (System.IO.File.Exists(source))
            {
                fileSize = new System.IO.FileInfo(source).Length;
            }
            else if (System.IO.Directory.Exists(source))
            {
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
        // 백업 이력 로드 후 Grid에 표시

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
            gridView1.Columns["BackupDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["BackupDate"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            gridView1.Columns["IsSuccess"].Caption = "성공 여부";
            gridView1.Columns["IsRecovery"].Visible = false;
            gridView1.Columns["RecoveryDate"].Visible = false;
            gridView1.Columns["RecoveredBy"].Visible = false;
            gridView1.Columns["IntegrityCheck"].Visible = false;
            gridView1.Columns["ErrorMsg"].Visible = false;
        }
        //폼이 로드될 때 - 기본 UI 및 데이터 초기화

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            chk_checksum.Checked = true;
            string source = txtSource.Text.Trim();
            string target = txtTarget.Text.Trim();
            txtTarget.Text = @"C:\MyBackup";
            UpdateFolderSizeAndFreeSpace();
            LoadHistory();
            gridView1.OptionsBehavior.Editable = _isAdmin;

            var reservation = LoadReservationInfo(source, target);
            ShowReservationInfo(reservation);
        }
        // [이벤트] 소스 폴더 선택(아이콘 클릭)

        private void source_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = fbd.SelectedPath;
                    UpdateFolderSizeAndFreeSpace();
                }
            }
        }
        // [이벤트] 소스 폴더 선택(아이콘 클릭)

        private void target_folder_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtTarget.Text = fbd.SelectedPath;
                    UpdateFolderSizeAndFreeSpace();
                }
            }
        }
        // [이벤트] 백업 예약 설정창 열기

        private void simpleButton6_Click(object sender, EventArgs e)
        {
            using (var form = new Schedule(_userId, _userName, _isAdmin, txtSource.Text, txtTarget.Text))
            {
                form.ShowDialog();
            }
        }
        // [이벤트] 백업 이력 Grid 더블클릭 - 상세 팝업
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle >= 0)
            {
                var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);

                using (var dlg = new BackupDetailForm(row))
                {
                    dlg.Owner = this;
                    dlg.ShowDialog();
                }
            }
        }

        // [이벤트] 소스 폴더 다시 선택 버튼

        private void simpleButton7_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = ofd.FileName;
                    UpdateFolderSizeAndFreeSpace();
                    return;
                }
            }

            // 2. 폴더 선택(파일 선택 취소한 경우)
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = fbd.SelectedPath;
                    UpdateFolderSizeAndFreeSpace();
                }
            }
        }

        // [이벤트] 타겟 폴더 다시 선택 버튼

        private void simpleButton8_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtSource.Text = fbd.SelectedPath;
                    UpdateFolderSizeAndFreeSpace();

                }
            }

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    restoreSourcePath.Text = ofd.FileName;
                    UpdateFolderSizeAndFreeSpace();
                    return;
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    restoreTargetPath.Text = fbd.SelectedPath;
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
        // 예약 정보 화면에 표시

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
                    nextTime = now.AddDays(1);
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
                progress_list.Text += "알 수 없는 예약 유형\r\n";
                return;
            }

            if (nextTime != null)
            {
                TimeSpan wait = nextTime.Value - now;
                progress_list.Text += $"[다음 예약] {nextTime.Value}\r\n";
                if (scheduleTimer != null) scheduleTimer.Stop();
                scheduleTimer = new System.Windows.Forms.Timer();
                scheduleTimer.Interval = Math.Min((int)wait.TotalMilliseconds, int.MaxValue - 1);
                scheduleTimer.Tick += async (s, e) =>
                {
                    scheduleTimer.Stop();
                    await RunBackupNow();
                    StartBackupSchedule(reservation);
                };
                scheduleTimer.Start();
            }
        }
        // 실제 백업 작업 비동기로 실행

        private async Task RunBackupNow()
        {
            string source = txtSource.Text.Trim();
            string target = txtTarget.Text.Trim();

            try
            {
                await Task.Run(() => CopyAllWithProgress(source, target, progress));

                bool isValid = CheckIntegrity(source, target);

                SaveBackupHistory(source, target, isValid, null);

                progress?.Report(new ProgressInfo
                {
                    Message = "백업 완료!"
                });

                LoadHistory();
            }
            catch (Exception ex)
            {
                progress?.Report(new ProgressInfo
                {
                    Message = $"백업 실패: {ex.Message}"
                });
                SaveBackupHistory(source, target, false, ex.Message);
            }
        }
        // [이벤트] 복구 버튼 클릭 - 파일/폴더 복구 실행

        private async void btn_Restore_Click(object sender, EventArgs e)
        {
            string backupPath = restoreSourcePath.Text;
            string restorePath = restoreTargetPath.Text;

            // 복구 현황 초기화
            memoEdit1.Text = "";

            var restoreProgress = new Progress<ProgressInfo>(info =>
            {
                memoEdit1.Text += info.Message + Environment.NewLine;
                memoEdit1.SelectionStart = memoEdit1.Text.Length;
                memoEdit1.ScrollToCaret();
            });

            try
            {
                // 폴더 복구
                if (Directory.Exists(backupPath))
                {
                    await Task.Run(() => CopyAllWithProgress(backupPath, restorePath, restoreProgress));
                }
                // 파일 복구
                else if (File.Exists(backupPath))
                {
                    string fileName = Path.GetFileName(backupPath);
                    string destFile = Path.Combine(restorePath, fileName);

                    await Task.Run(() => CopyFileWithPause(backupPath, destFile));
                }
                else
                {
                    XtraMessageBox.Show("복구할 파일/폴더가 없습니다.");
                    return;
                }

                memoEdit1.Text += "복구 완료!" + Environment.NewLine;
                memoEdit1.SelectionStart = memoEdit1.Text.Length;
                memoEdit1.ScrollToCaret();

                XtraMessageBox.Show("복구 완료!");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("복구 실패: " + ex.Message);
            }
        }




        private void gridControl1_MouseHover(object sender, EventArgs e)
        {

        }
        // 백업 이력에서 복구대상(소스/타겟/파일명) 지정

        public void SetRestoreTarget(string sourcePath, string targetPath, string fileName)
        {
            restoreSourcePath.Text = sourcePath;
            txtTarget.Text = targetPath;
        }

        private void chk_checksum_CheckedChanged(object sender, EventArgs e)
        {
            _useChecksum = chk_checksum.Checked;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DateTime startDate = dateEdit2.DateTime.Date;
            TimeSpan startTime = timeEdit1.Time.TimeOfDay;
            DateTime startDateTime = startDate + startTime;

            DateTime endDate = dateEdit1.DateTime.Date;
            TimeSpan endTime = timeEdit2.Time.TimeOfDay;
            DateTime endDateTime = endDate + endTime;

            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql = @"
                SELECT * FROM TEST_BackupHistory
                WHERE BackupDate >= @start AND BackupDate <= @end
                ORDER BY BackupDate DESC
            ";

            DataTable dt = new DataTable();
            using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
            using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@start", startDateTime);
                cmd.Parameters.AddWithValue("@end", endDateTime);

                using (var da = new System.Data.SqlClient.SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            gridControl1.DataSource = dt;
        }
        private long GetDirectorySize(string path)
        {
            if (!Directory.Exists(path))
                return 0;
            return Directory.GetFiles(path, "*.*", SearchOption.AllDirectories)
                .Select(f => new FileInfo(f).Length)
                .Sum();
        }
        private long GetAvailableFreeSpace(string path)
        {
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                return 0;
            string root = Path.GetPathRoot(path);
            var drive = new DriveInfo(root);
            return drive.AvailableFreeSpace;
        }
        private void UpdateFolderSizeAndFreeSpace()
        {
            // 소스 폴더 크기
            string sourcePath = txtSource.Text.Trim();
            long totalSourceSize = GetDirectorySize(sourcePath);
            total_filesize_source.Text = FormatSize(totalSourceSize);

            // 타겟 폴더 여유공간
            string targetPath = txtTarget.Text.Trim();
            long freeTargetSpace = GetAvailableFreeSpace(targetPath);
            total_filesize_target.Text = FormatSize(freeTargetSpace);
        }

        private void Insert_User_Click(object sender, EventArgs e)
        {
            using (var signupForm = new SignupForm())
            {
                signupForm.ShowDialog();
            }
        }
    }
}
