using DevExpress.XtraEditors;
using DevExpress.XtraScheduler.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace File_BackUp_Front
{
    public partial class Schedule : DevExpress.XtraEditors.XtraForm
    {
        string _userId, _userName;
        bool _isAdmin;
        public Schedule(string userId, string userName, bool isAdmin, string source, string target)
        {
            InitializeComponent();
            _userId = userId;
            _userName = userName;
            _isAdmin = isAdmin;

            // 소스/타겟 폼에 미리 세팅
            txtSource.Text = source;
            txtTarget.Text = target;
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
            else // 월간
            {
                scheduleType = "Monthly";
                // DevExpress RecurrenceControl을 쓸 경우
                scheduleValue = monthlyRecurrenceControl1.RecurrenceInfo.ToXml();
                // 만약 수동 조립이면: scheduleValue = $"{numericDay.Value} {timeEditMonth.Time:HH:mm}";
            }

            // DB INSERT
            string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
            string sql = @"INSERT INTO TEST_BackupSchedule 
                (UserID, SourcePath, TargetPath, ScheduleType, ScheduleValue, IsActive, CreatedDate)
                VALUES (@userId, @src, @tgt, @type, @val, 1, GETDATE())";
            using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
            using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@src", source);
                cmd.Parameters.AddWithValue("@tgt", target);
                cmd.Parameters.AddWithValue("@type", scheduleType);
                cmd.Parameters.AddWithValue("@val", scheduleValue);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            XtraMessageBox.Show("예약이 완료되었습니다!");
            this.Close();
        }
    }
}
