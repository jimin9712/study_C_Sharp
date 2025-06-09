namespace File_BackUp_Front
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            txtUserId = new DevExpress.XtraEditors.TextEdit();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            BtnLogin = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtUserId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(43, 139);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 22);
            label1.TabIndex = 0;
            label1.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(43, 236);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(62, 22);
            label2.TabIndex = 1;
            label2.Text = "비밀번호";
            // 
            // txtUserId
            // 
            txtUserId.EditValue = "";
            txtUserId.Location = new System.Drawing.Point(43, 164);
            txtUserId.Name = "txtUserId";
            txtUserId.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            txtUserId.Properties.Appearance.Options.UseFont = true;
            txtUserId.Size = new System.Drawing.Size(436, 50);
            txtUserId.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(43, 261);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(436, 50);
            txtPassword.TabIndex = 3;
            // 
            // BtnLogin
            // 
            BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            BtnLogin.Location = new System.Drawing.Point(43, 379);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new System.Drawing.Size(436, 44);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "로그인";
            BtnLogin.Click += BtnLogin_Click;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(200, 61);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(105, 53);
            labelControl1.TabIndex = 5;
            labelControl1.Text = "로그인";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(525, 469);
            Controls.Add(labelControl1);
            Controls.Add(BtnLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUserId);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "LoginForm";
            Text = "로그인";
            ((System.ComponentModel.ISupportInitialize)txtUserId.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtUserId;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.SimpleButton BtnLogin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}