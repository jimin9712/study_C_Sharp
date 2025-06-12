using DevExpress.Office.Utils;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace File_BackUp_Front
{
    public partial class BackupDetailForm : DevExpress.XtraEditors.XtraForm
    {
        private DataRow _row;
        public BackupDetailForm(DataRow row)
        {
            InitializeComponent();
            _row = row;
            FillDetail();
        }

        private void FillDetail()
        {
            txtUserID.Text = _row["UserID"].ToString();
            txtSourcePath.Text = _row["SourcePath"].ToString();
            txtTargetPath.Text = _row["TargetPath"].ToString();
            txtFileName.Text = _row["FileName"].ToString();
            if (long.TryParse(_row["FileSize"]?.ToString(), out long size))
                txtFileSize.Text = size.ToString("N0");
            else
                txtFileSize.Text = _row["FileSize"].ToString(); txtBackupDate.Text = _row["BackupDate"].ToString();
            txtIsSuccess.Text = _row["IsSuccess"].ToString();
            txtIntegrityCheck.Text = _row["IntegrityCheck"].ToString();
            txtErrorMsg.Text = _row["ErrorMsg"].ToString();
            if (_row.Table.Columns.Contains("IsRecovery") && _row["IsRecovery"] != DBNull.Value && Convert.ToInt32(_row["IsRecovery"]) == 1)
            {
                btn_Restore.Visible = false;
            }
            else
            {
                btn_Restore.Visible = true;
            }
        }

        private void BackupDetailForm_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btn_Restore_Click(object sender, EventArgs e)
        {

            var mainForm = this.Owner as MainForm;
            if (mainForm != null)
            {
                // 복구 소스: DB의 타겟 + 소스의 마지막 폴더명
                string dbSource = _row["SourcePath"].ToString();
                string dbTarget = _row["TargetPath"].ToString();
                string lastFolder = Path.GetFileName(dbSource.TrimEnd('\\', '/'));

                string restoreSource = Path.Combine(dbTarget, lastFolder);
                string restoreTarget = Path.GetDirectoryName(dbSource); // 복구 위치(상위폴더), 예시로 "C:\"

                mainForm.SetRestoreTarget(restoreSource, restoreTarget, _row["FileName"].ToString());

                mainForm.MoveToRestoreTab();

            }
            this.Close();
        }
    }
}