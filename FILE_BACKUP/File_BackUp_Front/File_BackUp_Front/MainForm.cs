using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public MainForm(string userId, string userName, bool isAdmin)
        {
            InitializeComponent();
            _userId = userId;
            _userName = userName;
            _isAdmin = isAdmin;

            source_folder.Image = Properties.Resources.source_folder;
            target_folder.Image = Properties.Resources.target_folder;

            this.Text = $"Main - {_userName} ({(_isAdmin ? "관리자" : "사용자")})";
        }

        private void BtnBackUp_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("백업이 시작되었습니다.");
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

            gridView1.Columns["UserID"].Caption = "사용자ID";
            gridView1.Columns["SourcePath"].Caption = "소스 경로";
            gridView1.Columns["TargetPath"].Caption = "타겟 경로";
            gridView1.Columns["FileName"].Caption = "파일명";
            gridView1.Columns["FileSize"].Caption = "파일크기(byte)";
            gridView1.Columns["BackupDate"].Caption = "백업 일시";
            gridView1.Columns["IsSuccess"].Caption = "성공여부";
            gridView1.Columns["IntegrityCheck"].Caption = "무결성";
            gridView1.Columns["ErrorMsg"].Visible = false;
            gridView1.Columns["IsRecovery"].Caption = "복구 여부";
            gridView1.Columns["RecoveryDate"].Caption = "복구 일시";
            gridView1.Columns["RecoveredBy"].Caption = "복구자";
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {
            LoadHistory();
            gridView1.OptionsBehavior.Editable = _isAdmin;
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
            using (var form = new Schedule())
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
    }
}