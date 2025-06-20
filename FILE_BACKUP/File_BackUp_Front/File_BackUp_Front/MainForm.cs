﻿using DevExpress.DataAccess.DataFederation;
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
        private volatile bool _isRestorePaused = false;
        private volatile bool _isRestoreStopped = false;
        private bool _isRestoreRunning = false;

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
                    // 일시정지 버튼을 처음 누른 시점
                    var result = XtraMessageBox.Show(
                        "중지하시겠습니까?", "일시정지", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    );
                    if (result == DialogResult.Yes)
                    {
                        // 백업 중지(롤백 또는 리셋: 변수/진행상태/버튼/텍스트 등)
                        _isPaused = false;
                        _isBackupRunning = false;
                        BtnBackUp.Text = "백업 시작";
                        progress?.Report(new ProgressInfo { Message = "[사용자에 의해 백업이 중단되었습니다.]" });
                        return;
                    }
                    // 아니오(일시정지)
                    _isPaused = true;
                    BtnBackUp.Text = "재개";
                    progress?.Report(new ProgressInfo { Message = "백업이 일시정지되었습니다." });
                }
                else
                {
                    // 재개
                    _isPaused = false;
                    BtnBackUp.Text = "일시정지";
                    progress?.Report(new ProgressInfo { Message = "백업이 재개되었습니다." });
                }
            }
        }

        // 파일 크기 보기 좋게 포맷
        private string FormatSize(long bytes)
        {
            if (bytes >= 1024L * 1024 * 1024 * 1024)
                return $"{(bytes / (1024.0 * 1024 * 1024 * 1024)):N2} TB";
            if (bytes >= 1024L * 1024 * 1024)
                return $"{(bytes / (1024.0 * 1024 * 1024)):N2} GB";
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
                Console.WriteLine("일시정지 대기중...");

                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        // 파일 복사(버퍼 단위) - Pause 상태 실시간 반영
        private void CopyFileWithPause(string sourceFile, string destFile, IProgress<ProgressInfo> progress)
        {
            const int bufferSize = 4 * 1024 * 1024;
            long fileSize = new FileInfo(sourceFile).Length;
            long copied = 0;

            // 복구 시작 메시지
            progress?.Report(new ProgressInfo
            {
                Message = $"복구 시작: {Path.GetFileName(sourceFile)} (크기: {FormatSize(fileSize)})"
            });

            using (var sourceStream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read))
            using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    WaitIfPaused();
                    destStream.Write(buffer, 0, bytesRead);
                    copied += bytesRead;
                    double percent = fileSize > 0 ? (double)copied / fileSize * 100 : 100;
                    progress?.Report(new ProgressInfo
                    {
                        Message = $"복구 중... {Path.GetFileName(sourceFile)} ({FormatSize(copied)}/{FormatSize(fileSize)}, {percent:F1}%)"
                    });
                }
            }

            // 복구 완료 메시지
            progress?.Report(new ProgressInfo
            {
                Message = $"복구 완료: {Path.GetFileName(sourceFile)} (크기: {FormatSize(fileSize)})"
            });
        }


        // 폴더 전체 복사, 복사 진행 상황 Progress로 전달, Pause랑 resume 반영
        private void CopyAllWithProgress(string sourcePath, string targetPath, IProgress<ProgressInfo> progress)
        {
            // 파일 복사
            if (System.IO.File.Exists(sourcePath))
            {
                WaitIfPaused();
                string fileName = System.IO.Path.GetFileName(sourcePath);
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                long fileSize = new System.IO.FileInfo(sourcePath).Length;

                progress?.Report(new ProgressInfo
                {
                    Message = $"복사 시작: {fileName} (파일 크기: {FormatSize(fileSize)} byte)"
                });

                try
                {
                    // 4MB 단위로 복사하며 진행률 보고
                    int bufferSize = 4 * 1024 * 1024;
                    long copied = 0;

                    using (var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read))
                    using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead;
                        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            WaitIfPaused();
                            destStream.Write(buffer, 0, bytesRead);
                            copied += bytesRead;
                            double percent = fileSize > 0 ? (double)copied / fileSize * 100 : 100;

                            progress?.Report(new ProgressInfo
                            {
                                Message = $"복사 중... {fileName} ({FormatSize(copied)}/{FormatSize(fileSize)}, {percent:F1}%)"
                            });
                        }
                    }
                }
                catch (System.IO.IOException ioEx)
                {
                    progress?.Report(new ProgressInfo
                    {
                        Message = $"[복사 실패: 다른 프로세스에서 사용 중] {fileName} - {ioEx.Message}"
                    });
                    return;
                }

                // 체크섬 검사 단계
                progress?.Report(new ProgressInfo
                {
                    Message = $"체크섬 검사 중: {fileName}"
                });
                string srcHash = _useChecksum ? GetFileHash(sourcePath) : null;
                string tgtHash = _useChecksum ? GetFileHash(destFile) : null;
                bool isValid = !_useChecksum || (srcHash == tgtHash);

                progress?.Report(new ProgressInfo
                {
                    Message = _useChecksum
                              ? $"[{(isValid ? "체크섬 검사 통과" : "체크섬 검사 통과 안됨")}] 복사 완료: {fileName} (1/1), 파일 크기: {FormatSize(fileSize)} byte"
                              : $"[체크섬 미검사] 복사 완료: {fileName} (1/1), 파일 크기: {FormatSize(fileSize)} byte",
                    IsChecksumValid = isValid
                });
                return;
            }

            // 폴더 복사
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

            // 모든 하위 폴더 생성
            foreach (var dirPath in System.IO.Directory.GetDirectories(sourcePath, "*", System.IO.SearchOption.AllDirectories))
            {
                WaitIfPaused();
                string subDir = dirPath.Replace(sourcePath, destFolder);
                if (!System.IO.Directory.Exists(subDir))
                    System.IO.Directory.CreateDirectory(subDir);
            }

            // 파일 복사
            foreach (var filePath in allFiles)
            {
                WaitIfPaused();

                string destFile = filePath.Replace(sourcePath, destFolder);

                // 파일별 복사 시작 메시지
                long fileSize = new System.IO.FileInfo(filePath).Length;
                string fileName = System.IO.Path.GetFileName(filePath);

                progress?.Report(new ProgressInfo
                {
                    Message = $"복사 시작: {fileName} (파일 크기: {FormatSize(fileSize)})"
                });
                try
                {
                    // 블록 단위 복사 및 진행률 보고
                    int bufferSize = 4 * 1024 * 1024;
                    long copied = 0;

                    using (var sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead;
                        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            WaitIfPaused();
                            destStream.Write(buffer, 0, bytesRead);
                            copied += bytesRead;
                            double percent = fileSize > 0 ? (double)copied / fileSize * 100 : 100;

                            progress?.Report(new ProgressInfo
                            {
                                Message = $"복사 중... {fileName} ({FormatSize(copied)}/{FormatSize(fileSize)}, {percent:F1}%)"
                            });
                        }
                    }
                }
                catch (System.IO.IOException ioEx)
                {
                    progress?.Report(new ProgressInfo
                    {
                        Message = $"[복사 실패: 다른 프로세스에서 사용 중] {fileName} - {ioEx.Message}"
                    });
                    continue;
                }

                // 체크섬 검사 단계
                progress?.Report(new ProgressInfo
                {
                    Message = $"체크섬 검사 중: {fileName}"
                });
                string srcHash = _useChecksum ? GetFileHash(filePath) : null;
                string tgtHash = _useChecksum ? GetFileHash(destFile) : null;
                bool isValid = !_useChecksum || (srcHash == tgtHash);
                count++;

                progress?.Report(new ProgressInfo
                {
                    Message = _useChecksum
                      ? $"[{(isValid ? "체크섬 검사 통과" : "체크섬 검사 통과 안됨")}] 복사 완료: {fileName} (1/1), 파일 크기: {FormatSize(fileSize)}"
                      : $"[체크섬 미검사] 복사 완료: {fileName} (1/1), 파일 크기: {FormatSize(fileSize)}",
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
        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "IsSuccess")
            {
                if (e.Value != null && e.Value != DBNull.Value)
                {
                    bool isSuccess = Convert.ToBoolean(e.Value);
                    e.DisplayText = isSuccess ? "성공" : "실패";
                }
                else
                {
                    e.DisplayText = "";
                }
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
            gridView1.Columns["BackupDate"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            gridView1.Columns["BackupDate"].DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";

            gridView1.Columns["IsSuccess"].Caption = "성공 여부";
            gridView1.Columns["IsSuccess"].ColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            gridView1.Columns["IsSuccess"].AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridView1.CustomColumnDisplayText += gridView1_CustomColumnDisplayText;

            gridView1.Columns["IsRecovery"].Visible = false;
            gridView1.Columns["RecoveryDate"].Visible = false;
            gridView1.Columns["RecoveredBy"].Visible = false;
            gridView1.Columns["IntegrityCheck"].Visible = false;
            gridView1.Columns["ErrorMsg"].Visible = false;
        }
        //폼이 로드될 때 - 기본 UI 및 데이터 초기화

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            //시작 일자
            dateEdit2.DateTime = DateTime.Now;
            timeEdit1.Time = DateTime.Now;
            //종료 일시
            dateEdit1.DateTime = DateTime.Now;
            timeEdit2.Time = dateEdit1.DateTime;
            timeEdit2.Time = new DateTime(1, 1, 1, 23, 59, 59);

            chk_checksum.Checked = Properties.Settings.Default.UseChecksum;
            _useChecksum = chk_checksum.Checked; string source = txtSource.Text.Trim();
            string target = txtTarget.Text.Trim();
            txtTarget.Text = @"C:\MyBackup";
            UpdateFolderSizeAndFreeSpace();
            LoadHistory();

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
                form.Owner = this;
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
      

        // 소스 폴더 다시 선택 버튼

        // 파일 선택 (btnSelectFile)
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
        }

        // [이벤트] 타겟 폴더 다시 선택 버튼

        private void simpleButton8_Click(object sender, EventArgs e)
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



        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.CheckFileExists = true;
                ofd.Multiselect = false;

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    restoreTargetPath.Text = ofd.FileName;
                    UpdateFolderSizeAndFreeSpace();
                    return;
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
                return;
            }
            Schedule_list.Text += $"[예약정보] 유형: {row["ScheduleType"]}, 값: {row["ScheduleValue"]}\r\n";
        }
        public void RefreshSchedule()
        {
            string source = txtSource.Text.Trim().TrimEnd('\\');
            string target = txtTarget.Text.Trim().TrimEnd('\\');
            var reservation = LoadReservationInfo(source, target);

            ShowReservationInfo(reservation);
            StartBackupSchedule(reservation);
        }
        private void StartBackupSchedule(DataRow reservation)
        {

            if (reservation == null)
            {
                progress_list.Text += "[예약 정보 없음, 스케줄 동작 불가]\r\n";
                return;
            }
            string scheduleType = reservation["ScheduleType"].ToString();
            string scheduleValue = reservation["ScheduleValue"].ToString();
            DateTime now = DateTime.Now;
            DateTime? nextTime = null;

            if (scheduleType == "Once")
            {
                if (DateTime.TryParse(scheduleValue, out var oneTime))
                {
                    if (oneTime > now)
                        nextTime = oneTime;
                    else
                    {
                        progress_list.Text += "[일회 예약: 이미 지난 예약입니다]\r\n";
                        return;
                    }
                }
                else
                {
                    progress_list.Text += "[일회 예약: 잘못된 날짜/시간]\r\n";
                    return;
                }
            }
            else if (scheduleType == "Daily")
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

                    // ✅ 한 번만 예약이면 비활성화 처리!
                    if (scheduleType == "Once")
                    {
                        DeactivateOnceSchedule(reservation);
                        progress_list.Text += "[일회 예약: 예약이 완료되어 비활성화되었습니다.]\r\n";
                    }
                    else
                    {
                        // 나머지 예약은 계속 스케줄링
                        StartBackupSchedule(reservation);
                    }
                };
                scheduleTimer.Start();
            }
        }
        private void DeactivateOnceSchedule(DataRow reservation)
        {
            if (reservation.Table.Columns.Contains("ScheduleID"))
            {
                int scheduleId = Convert.ToInt32(reservation["ScheduleID"]);
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
                string sql = "UPDATE TEST_BackupSchedule SET IsActive = 0 WHERE ScheduleID = @id";
                using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
                using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", scheduleId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
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
        private void WaitIfRestorePaused()
        {
            while (_isRestorePaused)
            {
                Application.DoEvents(); // UI 응답
                Thread.Sleep(100);
            }
        }
        private async void btn_Restore_Click(object sender, EventArgs e)
        {

            // 이미 복구가 진행 중일 때: 일시정지/중지/재개 흐름
            if (_isRestoreRunning)
            {
                if (!_isRestorePaused)
                {
                    // 일시정지 중에 중지여부 확인
                    var result = XtraMessageBox.Show(
                        "중지하시겠습니까?",
                        "복구 중지 확인",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        _isRestoreStopped = true;
                        _isRestorePaused = false;
                        btn_Restore.Text = "복구 시작";
                        memoEdit1.Text += "복구가 중단되었습니다.\r\n";
                    }
                    else
                    {
                        _isRestorePaused = true;
                        btn_Restore.Text = "재개";
                        memoEdit1.Text += "복구가 일시정지되었습니다.\r\n";
                    }
                    return;
                }
                else
                {
                    // 재개
                    _isRestorePaused = false;
                    btn_Restore.Text = "일시정지";
                    memoEdit1.Text += "복구가 재개되었습니다.\r\n";
                    return;
                }
            }

            // 복구 시작
            _isRestoreRunning = true;
            _isRestorePaused = false;
            _isRestoreStopped = false;
            btn_Restore.Text = "일시정지";

            string backupPath = restoreTargetPath.Text;     // 원본(백업된 폴더/파일)
            string restorePath = restoreSourcePath.Text;     // 복구할 위치

            // 복구 현황 초기화
            memoEdit1.Text = "";

            var restoreProgress = new Progress<ProgressInfo>(info =>
            {
                memoEdit1.Text += info.Message + Environment.NewLine;
                memoEdit1.SelectionStart = memoEdit1.Text.Length;
                memoEdit1.ScrollToCaret();
            });

            bool isSuccess = false;
            string errorMsg = null;

            try
            {
                if (Directory.Exists(backupPath))
                {
                    // 폴더라면, backupPath의 '내용만' restorePath로 복사
                    await Task.Run(() => RestoreFolderContents(backupPath, restorePath, restoreProgress));
                }
                else if (File.Exists(backupPath))
                {
                    // 파일은 파일만 복사
                    string fileName = Path.GetFileName(backupPath);
                    string destFile = Path.Combine(restorePath, fileName);

                    await Task.Run(() => CopyFileWithPause(backupPath, destFile, restoreProgress));
                }
                else
                {
                    XtraMessageBox.Show("복구할 파일/폴더가 없습니다.");
                    return;
                }

                isSuccess = CheckIntegrity(backupPath, restorePath);
                if (!isSuccess)
                    errorMsg = "복구 무결성 검사 실패";

                memoEdit1.Text += isSuccess ? "복구 완료!\n" : "복구 실패(무결성 오류)\n";
                memoEdit1.SelectionStart = memoEdit1.Text.Length;
                memoEdit1.ScrollToCaret();

                XtraMessageBox.Show(isSuccess ? "복구 완료!" : "복구 실패(무결성 오류)");
            }
            catch (Exception ex)
            {
                isSuccess = false;
                errorMsg = ex.Message;
                XtraMessageBox.Show("복구 실패: " + ex.Message);
            }
            finally
            {
                try
                {
                    var row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    if (row != null)
                    {
                        int historyId = Convert.ToInt32(row["HistoryID"]);
                        SaveRestoreHistory(
                            historyId,
                            _userId,
                            restorePath,
                            isSuccess,
                            errorMsg
                        );
                    }
                    else
                    {
                        XtraMessageBox.Show("복구 이력을 기록할 백업 항목이 선택되지 않았습니다.");
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show("복구 이력 기록 실패: " + ex.Message);
                }
                btn_Restore.Text = "복구 시작";
                _isRestoreRunning = false;
            }
        }
        // backupFolder(백업본 경로)의 하위 파일/폴더만 restorePath에 복사
        private void RestoreFolderContents(string backupFolder, string restorePath, IProgress<ProgressInfo> progress)
        {
            // 상위 폴더명까지 포함해서 복구
            string folderName = Path.GetFileName(backupFolder.TrimEnd('\\'));
            string destRoot = Path.Combine(restorePath, folderName);

            // 1. 하위 폴더 복사 (진행률 표시)
            var allDirs = Directory.GetDirectories(backupFolder, "*", SearchOption.AllDirectories);
            int dirCount = allDirs.Length;
            int dirIdx = 0;
            foreach (string dirPath in allDirs)
            {
                string relative = dirPath.Substring(backupFolder.Length).TrimStart('\\');
                string destDir = Path.Combine(destRoot, relative);
                if (!Directory.Exists(destDir))
                {
                    Directory.CreateDirectory(destDir);
                    dirIdx++;
                    double percent = dirCount > 0 ? (double)dirIdx / dirCount * 100 : 100;
                    progress?.Report(new ProgressInfo
                    {
                        Message = $"폴더 생성: {destDir} ({dirIdx}/{dirCount}, {percent:F1}%)"
                    });
                }
            }

            // 파일 복사
            foreach (string filePath in Directory.GetFiles(backupFolder, "*", SearchOption.AllDirectories))
            {
                WaitIfPaused();
                string relative = filePath.Substring(backupFolder.Length).TrimStart('\\');
                string destFile = Path.Combine(destRoot, relative);

                long fileSize = new FileInfo(filePath).Length;
                const int bufferSize = 4 * 1024 * 1024; // 4MB 단위
                long copied = 0;

                progress?.Report(new ProgressInfo { Message = $"복구 시작: {relative} (크기: {FormatSize(fileSize)})" });

                try
                {
                    using (var sourceStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    using (var destStream = new FileStream(destFile, FileMode.Create, FileAccess.Write))
                    {
                        byte[] buffer = new byte[bufferSize];
                        int bytesRead;
                        while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            WaitIfPaused();
                            destStream.Write(buffer, 0, bytesRead);
                            copied += bytesRead;
                            double percent = fileSize > 0 ? (double)copied / fileSize * 100 : 100;
                            progress?.Report(new ProgressInfo
                            {
                                Message = $"복구 중... {relative} ({FormatSize(copied)}/{FormatSize(fileSize)}, {percent:F1}%)"
                            });
                        }
                    }
                    progress?.Report(new ProgressInfo { Message = $"복구 완료: {relative} (크기: {FormatSize(fileSize)})" });
                }
                catch (Exception ex)
                {
                    progress?.Report(new ProgressInfo
                    {
                        Message = $"[복구 실패: {relative}] {ex.Message}"
                    });
                    // continue; // 다음 파일로 진행
                }
            }
        }


        private void SaveRestoreHistory(
        int historyId, string userId, string Target, bool isSuccess, string errorMsg)
        {
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql = @"UPDATE TEST_BackupHistory
                   SET IsRecovery = @isRecovery,
                       RecoveryDate = @recoveryDate,
                       RecoveredBy = @userId,
                      TargetPath = @restoreTarget,
                       ErrorMsg = @errorMsg
                   WHERE HistoryID = @historyId";
            using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
            using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@isRecovery", isSuccess ? 1 : 0);
                cmd.Parameters.AddWithValue("@recoveryDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@restoreTarget", Target ?? "");
                cmd.Parameters.AddWithValue("@errorMsg", errorMsg ?? "");
                cmd.Parameters.AddWithValue("@historyId", historyId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void gridControl1_MouseHover(object sender, EventArgs e)
        {

        }
        // 백업 이력에서 복구대상(소스/타겟/파일명) 지정

        public void SetRestoreTarget(string sourcePath, string targetPath, string fileName)
        {
            restoreTargetPath.Text = sourcePath;
            restoreSourcePath.Text = targetPath;
        }

        private void chk_checksum_CheckedChanged(object sender, EventArgs e)
        {
            _useChecksum = chk_checksum.Checked;

            Properties.Settings.Default.UseChecksum = chk_checksum.Checked;
            Properties.Settings.Default.Save();

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
            labelControl20.Text = $"조회된 개수: {gridView1.RowCount}개";

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
            // 소스 경로(파일 또는 폴더)
            string sourcePath = txtSource.Text.Trim();

            long totalSourceSize = 0;
            if (System.IO.File.Exists(sourcePath))
            {
                totalSourceSize = new System.IO.FileInfo(sourcePath).Length;
            }
            else if (System.IO.Directory.Exists(sourcePath))
            {
                totalSourceSize = GetDirectorySize(sourcePath);
            }
            else
            {
                total_filesize_source.Text = "경로 없음";
                total_filesize_target.Text = "경로 없음";
                return;
            }
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
        public void MoveToRestoreTab()
        {
            Menu.SelectedTabPageIndex = 2;
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
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

        private void btn_backuplist_Click(object sender, EventArgs e)
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
        WHERE RecoveryDate IS NULL
          AND BackupDate >= @start AND BackupDate <= @end
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
            labelControl20.Text = $"조회된 개수: {gridView1.RowCount}개";

        }


        private void btn_restorelist_Click(object sender, EventArgs e)
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
        WHERE RecoveryDate IS NOT NULL
          AND BackupDate >= @start AND BackupDate <= @end
        ORDER BY RecoveryDate DESC
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
            labelControl20.Text = $"조회된 개수: {gridView1.RowCount}개";

        }

        private void btnSelectFile_re_Click(object sender, EventArgs e)
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

        private void btnSelectFolder_re_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    restoreSourcePath.Text = fbd.SelectedPath;
                    UpdateFolderSizeAndFreeSpace();
                }
            }
        }
    }
}
