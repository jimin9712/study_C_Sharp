namespace File_BackUp_Front
{
    partial class SignupForm
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
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            txtID = new DevExpress.XtraEditors.TextEdit();
            txtPassword = new DevExpress.XtraEditors.TextEdit();
            txtPassword2 = new DevExpress.XtraEditors.TextEdit();
            txtNickname = new DevExpress.XtraEditors.TextEdit();
            btnSignup = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)txtID.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtNickname.Properties).BeginInit();
            SuspendLayout();
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(166, 57);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(166, 53);
            labelControl1.TabIndex = 6;
            labelControl1.Text = "Sign up";
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(43, 139);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(19, 22);
            labelControl2.TabIndex = 7;
            labelControl2.Text = "ID";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(43, 316);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(142, 22);
            labelControl3.TabIndex = 8;
            labelControl3.Text = "Confirm password";
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(43, 400);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(119, 22);
            labelControl4.TabIndex = 9;
            labelControl4.Text = "user_Nickname";
            // 
            // labelControl5
            // 
            labelControl5.Location = new System.Drawing.Point(43, 232);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(74, 22);
            labelControl5.TabIndex = 10;
            labelControl5.Text = "Password";
            // 
            // txtID
            // 
            txtID.EditValue = "";
            txtID.Location = new System.Drawing.Point(43, 167);
            txtID.Name = "txtID";
            txtID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            txtID.Properties.Appearance.Options.UseFont = true;
            txtID.Size = new System.Drawing.Size(436, 50);
            txtID.TabIndex = 11;
            // 
            // txtPassword
            // 
            txtPassword.EditValue = "";
            txtPassword.Location = new System.Drawing.Point(43, 260);
            txtPassword.Name = "txtPassword";
            txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            txtPassword.Properties.Appearance.Options.UseFont = true;
            txtPassword.Properties.PasswordChar = '*';
            txtPassword.Size = new System.Drawing.Size(436, 50);
            txtPassword.TabIndex = 12;
            // 
            // txtPassword2
            // 
            txtPassword2.EditValue = "";
            txtPassword2.Location = new System.Drawing.Point(43, 344);
            txtPassword2.Name = "txtPassword2";
            txtPassword2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            txtPassword2.Properties.Appearance.Options.UseFont = true;
            txtPassword2.Properties.PasswordChar = '*';
            txtPassword2.Size = new System.Drawing.Size(436, 50);
            txtPassword2.TabIndex = 13;
            // 
            // txtNickname
            // 
            txtNickname.EditValue = "";
            txtNickname.Location = new System.Drawing.Point(43, 428);
            txtNickname.Name = "txtNickname";
            txtNickname.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 18F);
            txtNickname.Properties.Appearance.Options.UseFont = true;
            txtNickname.Size = new System.Drawing.Size(436, 50);
            txtNickname.TabIndex = 14;
            // 
            // btnSignup
            // 
            btnSignup.Location = new System.Drawing.Point(43, 507);
            btnSignup.Name = "btnSignup";
            btnSignup.Size = new System.Drawing.Size(436, 51);
            btnSignup.TabIndex = 15;
            btnSignup.Text = "Sign up";
            btnSignup.Click += btnSignup_Click;
            // 
            // SignupForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(525, 614);
            Controls.Add(btnSignup);
            Controls.Add(txtNickname);
            Controls.Add(txtPassword2);
            Controls.Add(txtPassword);
            Controls.Add(txtID);
            Controls.Add(labelControl5);
            Controls.Add(labelControl4);
            Controls.Add(labelControl3);
            Controls.Add(labelControl2);
            Controls.Add(labelControl1);
            Name = "SignupForm";
            Text = "SignupForm";
            ((System.ComponentModel.ISupportInitialize)txtID.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtPassword2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtNickname.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtPassword2;
        private DevExpress.XtraEditors.TextEdit txtNickname;
        private DevExpress.XtraEditors.SimpleButton btnSignup;
    }
}