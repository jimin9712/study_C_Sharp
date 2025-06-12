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
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)txtUserId.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("맑은 고딕", 9F);
            label1.Location = new System.Drawing.Point(489, 278);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(66, 25);
            label1.TabIndex = 0;
            label1.Text = "아이디";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("맑은 고딕", 9F);
            label2.Location = new System.Drawing.Point(487, 375);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 25);
            label2.TabIndex = 1;
            label2.Text = "비밀번호";
            // 
            // txtUserId
            // 
            txtUserId.EditValue = "";
            txtUserId.Location = new System.Drawing.Point(489, 304);
            txtUserId.Name = "txtUserId";
            txtUserId.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            txtUserId.Properties.Appearance.Options.UseFont = true;
            txtUserId.Size = new System.Drawing.Size(436, 32);
            txtUserId.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Location = new System.Drawing.Point(489, 401);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(436, 32);
            txtPassword.TabIndex = 3;
            // 
            // BtnLogin
            // 
            BtnLogin.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            BtnLogin.Appearance.Options.UseFont = true;
            BtnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            BtnLogin.Location = new System.Drawing.Point(489, 481);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new System.Drawing.Size(436, 44);
            BtnLogin.TabIndex = 4;
            BtnLogin.Text = "로그인";
            BtnLogin.Click += BtnLogin_Click;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(634, 163);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(132, 60);
            labelControl1.TabIndex = 5;
            labelControl1.Text = "로그인";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(487, 622);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(120, 25);
            labelControl2.TabIndex = 6;
            labelControl2.Text = "어드민 로그인 ";
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(487, 653);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(114, 25);
            labelControl3.TabIndex = 7;
            labelControl3.Text = "아이디: admin";
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new System.Drawing.Point(487, 684);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(122, 25);
            labelControl4.TabIndex = 8;
            labelControl4.Text = "비밀번호: 1234";
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new System.Drawing.Point(487, 715);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(594, 25);
            labelControl5.TabIndex = 9;
            labelControl5.Text = "어드민 로그인 후 설정 탭에서 사용자 추가 후 일반 사용자로 로그인 가능 ";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1474, 863);
            Controls.Add(labelControl5);
            Controls.Add(labelControl4);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
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
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}