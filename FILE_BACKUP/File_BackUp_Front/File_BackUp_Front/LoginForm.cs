using DevExpress.XtraEditors;
using DevExpress.XtraReports.Design;
using DevExpress.XtraWaitForm;
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
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
            BtnLogin.Click += BtnLogin_Click;

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userId = txtUserId.Text.Trim();
            string pw = txtPassword.Text.Trim();

            bool isAdmin;
            string userName;

           
            if (UserService.Login(userId, pw, out isAdmin, out userName))
            {
                this.Hide();
                MainForm mf = new MainForm(userId, userName, isAdmin);
                mf.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("아이디 또는 비밀번호가 올바르지 않습니다.");
            }

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {
            SignupForm lf = new SignupForm();
            lf.ShowDialog();
            this.Close();
        }
    }
}