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
    public partial class SignupForm : DevExpress.XtraEditors.XtraForm
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            string id = txtID.Text.Trim();
            string pw = txtPassword.Text.Trim();
            string pw2 = txtPassword2.Text.Trim();
            string nickname = txtNickname.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) ||
        string.IsNullOrWhiteSpace(pw) ||
        string.IsNullOrWhiteSpace(pw2))
            {
                XtraMessageBox.Show("모든 항목을 입력해주세요.");
                return;
            }
            if (pw != pw2)
            {
                XtraMessageBox.Show("비밀번호가 일치하지 않습니다.");
                return;
            }
            try
            {
                
                string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["BackupDb"].ConnectionString;
                using (var conn = new System.Data.SqlClient.SqlConnection(connStr))
                {
                    conn.Open();
                    string sql = "INSERT INTO TEST_USERS (UserID, Password, UserName, IsAdmin) VALUES (@id, @pw, @nickname, 0)";
                    using (var cmd = new System.Data.SqlClient.SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.Parameters.AddWithValue("@pw", pw);
                        cmd.Parameters.AddWithValue("@nickname", nickname);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            XtraMessageBox.Show("회원가입 완료!");
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                            this.Close();
                        }
                        else
                        {
                            XtraMessageBox.Show("회원가입 실패!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("DB 오류: " + ex.Message);
            }
        }
    }
}