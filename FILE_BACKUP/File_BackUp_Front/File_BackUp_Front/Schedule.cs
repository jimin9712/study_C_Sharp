using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.UI;
using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace File_BackUp_Front
{
    public partial class Schedule : DevExpress.XtraEditors.XtraForm
    {
        string _userId, _userName;
        bool _isAdmin;
        private int? _editingScheduleId = null;

        public Schedule(string userId, string userName, bool isAdmin, string source, string target)
        {
            InitializeComponent();
            _userId = userId;
            _userName = userName;
            _isAdmin = isAdmin;

            txtSource.Text = source;
            txtTarget.Text = target;
            simpleButton1.Text = "예약 등록"; // 초기 상태는 "예약 등록"
            LoadScheduleList();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            panelDaily.Visible = radioButtonDaily.Checked;
            panelWeek.Visible = radioButtonWeek.Checked;
            panelMonth.Visible = radioButtonMonth.Checked;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // 저장 (추가/수정)
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string userId = _userId;
            string source = txtSource.Text.Trim();
            string target = txtTarget.Text.Trim();
            string scheduleType = "";
            string scheduleValue = "";

            if (radioButtonDaily.Checked)
            {
                scheduleType = "Daily";
                scheduleValue = timeEditDaily.Time.ToString("HH:mm");
            }
            else if (radioButtonWeek.Checked)
            {
                scheduleType = "Weekly";
                var daysEnum = chkboxWeekday.WeekDays;
                List<string> checkedDays = new List<string>();
                if ((daysEnum & DevExpress.XtraScheduler.WeekDays.Monday) != 0) checkedDays.Add("Mon");
                if ((daysEnum & DevExpress.XtraScheduler.WeekDays.Tuesday) != 0) checkedDays.Add("Tue");
                if ((daysEnum & DevExpress.XtraScheduler.WeekDays.Wednesday) != 0) checkedDays.Add("Wed");
                if ((daysEnum & DevExpress.XtraScheduler.WeekDays.Thursday) != 0) checkedDays.Add("Thu");
                if ((daysEnum & DevExpress.XtraScheduler.WeekDays.Friday) != 0) checkedDays.Add("Fri");
                if ((daysEnum & DevExpress.XtraScheduler.WeekDays.Saturday) != 0) checkedDays.Add("Sat");
                if ((daysEnum & DevExpress.XtraScheduler.WeekDays.Sunday) != 0) checkedDays.Add("Sun");
                string weekDays = string.Join(",", checkedDays);
                scheduleValue = $"{weekDays} {timeEditWeek.Time:HH:mm}";
            }
            else
            {
                scheduleType = "Monthly";
                scheduleValue = monthlyRecurrenceControl1.RecurrenceInfo.ToXml();
            }

            string connStr = ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql;
            if (_editingScheduleId.HasValue)
            {
                // 수정
                sql = @"UPDATE TEST_BackupSchedule 
                        SET SourcePath=@src, TargetPath=@tgt, ScheduleType=@type, ScheduleValue=@val
                        WHERE ScheduleID=@id";
            }
            else
            {
                // 추가
                sql = @"INSERT INTO TEST_BackupSchedule 
                        (UserID, SourcePath, TargetPath, ScheduleType, ScheduleValue, IsActive, CreatedDate)
                        VALUES (@userId, @src, @tgt, @type, @val, 1, GETDATE())";
            }
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (_editingScheduleId.HasValue)
                {
                    cmd.Parameters.AddWithValue("@id", _editingScheduleId.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                }
                cmd.Parameters.AddWithValue("@src", source);
                cmd.Parameters.AddWithValue("@tgt", target);
                cmd.Parameters.AddWithValue("@type", scheduleType);
                cmd.Parameters.AddWithValue("@val", scheduleValue);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            XtraMessageBox.Show(_editingScheduleId.HasValue ? "수정 완료!" : "예약이 완료되었습니다!");

            _editingScheduleId = null;
            simpleButton1.Text = "예약 등록"; // 항상 저장 후엔 '예약 등록'으로 복귀
            LoadScheduleList();
            txtSource.Text = "";
            txtTarget.Text = "";
        }

        // 예약 목록 로드
        private void LoadScheduleList()
        {
            string connStr = ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql = @"
                SELECT ScheduleID, SourcePath, TargetPath, ScheduleType, ScheduleValue, CreatedDate
                FROM TEST_BackupSchedule
                WHERE UserID=@userId AND IsActive=1
                ORDER BY CreatedDate DESC";

            var dt = new DataTable();
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@userId", _userId);
                da.Fill(dt);
            }

            gridControlSchedules.DataSource = dt;

            var col = gridViewSchedules.Columns["ScheduleID"];
            if (col != null)
                col.Visible = false;

            var colDate = gridViewSchedules.Columns["CreatedDate"];
if (colDate != null)
{
    colDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
    colDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
}


            gridViewSchedules.BestFitColumns();
        }

        // 삭제
        private void btn_delete_Click(object sender, EventArgs e)
        {
            int rowHandle = gridViewSchedules.FocusedRowHandle;
            if (rowHandle < 0)
            {
                XtraMessageBox.Show("삭제할 예약을 선택하세요.");
                return;
            }

            var result = XtraMessageBox.Show("정말 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            var scheduleId = gridViewSchedules.GetRowCellValue(rowHandle, "ScheduleID");
            if (scheduleId == null)
            {
                XtraMessageBox.Show("예약 정보가 올바르지 않습니다.");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql = "UPDATE TEST_BackupSchedule SET IsActive=0 WHERE ScheduleID=@id";
            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", scheduleId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadScheduleList();
        }

        // 수정
        private void btn_modify_Click(object sender, EventArgs e)
        {
            int rowHandle = gridViewSchedules.FocusedRowHandle;
            if (rowHandle < 0)
            {
                XtraMessageBox.Show("수정할 예약을 선택하세요.");
                return;
            }

            var scheduleId = gridViewSchedules.GetRowCellValue(rowHandle, "ScheduleID");
            if (scheduleId == null)
            {
                XtraMessageBox.Show("예약 정보가 올바르지 않습니다.");
                return;
            }
            _editingScheduleId = Convert.ToInt32(scheduleId);

            txtSource.Text = gridViewSchedules.GetRowCellValue(rowHandle, "SourcePath")?.ToString();
            txtTarget.Text = gridViewSchedules.GetRowCellValue(rowHandle, "TargetPath")?.ToString();

            string type = gridViewSchedules.GetRowCellValue(rowHandle, "ScheduleType")?.ToString();
            string value = gridViewSchedules.GetRowCellValue(rowHandle, "ScheduleValue")?.ToString();

            // 타입별로 값 세팅
            if (type == "Daily")
            {
                radioButtonDaily.Checked = true;
                if (TimeSpan.TryParse(value, out var time))
                    timeEditDaily.Time = DateTime.Today.Add(time);
            }
            else if (type == "Weekly")
            {
                radioButtonWeek.Checked = true;
                if (!string.IsNullOrEmpty(value))
                {
                    var arr = value.Split(' ');
                    if (arr.Length == 2)
                    {
                        string[] days = arr[0].Split(',');
                        foreach (var day in days)
                        {
                        }
                        if (TimeSpan.TryParse(arr[1], out var wtime))
                            timeEditWeek.Time = DateTime.Today.Add(wtime);
                    }
                }
            }
            else if (type == "Monthly")
            {
                radioButtonMonth.Checked = true;
                if (!string.IsNullOrEmpty(value))
                {
                    try
                    {
                        monthlyRecurrenceControl1.RecurrenceInfo = new DevExpress.XtraScheduler.RecurrenceInfo();
                        monthlyRecurrenceControl1.RecurrenceInfo.FromXml(value);
                    }
                    catch { }
                }
            }

            simpleButton1.Text = "예약 수정";
        }

        private void simpleButton7_Click(object sender, EventArgs e)
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
    }
}
