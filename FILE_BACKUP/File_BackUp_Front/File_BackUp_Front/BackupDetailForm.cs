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
        bool _isAdmin;
        public BackupDetailForm(DataRow row)
        {
            InitializeComponent();
            _row = row;
            FillDetail();
        }
        
        private void FillDetail()
        {
            txtHistoryID.Text = _row["HistoryID"].ToString();
            txtUserID.Text = _row["UserID"].ToString();
            txtSourcePath.Text = _row["SourcePath"].ToString();
            txtTargetPath.Text = _row["TargetPath"].ToString();
            txtFileName.Text = _row["FileName"].ToString();
            txtFileSize.Text = _row["FileSize"].ToString();
            txtBackupDate.Text = _row["BackupDate"].ToString();
            txtIsSuccess.Text = _row["IsSuccess"].ToString();
            txtIntegrityCheck.Text = _row["IntegrityCheck"].ToString();
            txtErrorMsg.Text = _row["ErrorMsg"].ToString();
            txtIsRecovery.Text = _row["IsRecovery"].ToString();
            txtRecoveryDate.Text = _row["RecoveryDate"].ToString();
            txtRecoveredBy.Text = _row["RecoveredBy"].ToString();
        }

        private void BackupDetailForm_Load(object sender, EventArgs e)
        {

        }
    }
}