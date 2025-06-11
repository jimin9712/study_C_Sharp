using DevExpress.Office.Utils;
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
            txtFileSize.Text = _row["FileSize"].ToString();
            txtBackupDate.Text = _row["BackupDate"].ToString();
            txtIsSuccess.Text = _row["IsSuccess"].ToString();
            txtIntegrityCheck.Text = _row["IntegrityCheck"].ToString();
            txtErrorMsg.Text = _row["ErrorMsg"].ToString();
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
                mainForm.SetRestoreTarget(
                    _row["SourcePath"].ToString(),
                    _row["TargetPath"].ToString(),
                    _row["FileName"].ToString());
            }
            this.Close();
        }
    }
}