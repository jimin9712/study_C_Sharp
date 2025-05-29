namespace UsingControls
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grpFont = new GroupBox();
            txtSampleText = new TextBox();
            chkitalic = new CheckBox();
            chkBold = new CheckBox();
            cboFont = new ComboBox();
            lblFont = new Label();
            grpBar = new GroupBox();
            pgDummy = new ProgressBar();
            tbDummy = new TrackBar();
            btnModal = new Button();
            grpForm = new GroupBox();
            btnMsgBox = new Button();
            btnModaless = new Button();
            grpTreeList = new GroupBox();
            btnAddChild = new Button();
            btnAddRoot = new Button();
            lvDummy = new ListView();
            tvDummy = new TreeView();
            grpFont.SuspendLayout();
            grpBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbDummy).BeginInit();
            grpForm.SuspendLayout();
            grpTreeList.SuspendLayout();
            SuspendLayout();
            // 
            // grpFont
            // 
            grpFont.Controls.Add(txtSampleText);
            grpFont.Controls.Add(chkitalic);
            grpFont.Controls.Add(chkBold);
            grpFont.Controls.Add(cboFont);
            grpFont.Controls.Add(lblFont);
            grpFont.Location = new Point(57, 40);
            grpFont.Name = "grpFont";
            grpFont.Size = new Size(677, 169);
            grpFont.TabIndex = 0;
            grpFont.TabStop = false;
            grpFont.Text = "ComboBox, CheckBox, TextBox";
            // 
            // txtSampleText
            // 
            txtSampleText.Location = new Point(19, 119);
            txtSampleText.Name = "txtSampleText";
            txtSampleText.Size = new Size(584, 31);
            txtSampleText.TabIndex = 4;
            txtSampleText.Text = "Hello, C#";
            // 
            // chkitalic
            // 
            chkitalic.AutoSize = true;
            chkitalic.Location = new Point(511, 66);
            chkitalic.Name = "chkitalic";
            chkitalic.Size = new Size(92, 29);
            chkitalic.TabIndex = 3;
            chkitalic.Text = "이탤릭";
            chkitalic.UseVisualStyleBackColor = true;
            chkitalic.CheckedChanged += chkitalic_CheckedChanged;
            // 
            // chkBold
            // 
            chkBold.AutoSize = true;
            chkBold.Location = new Point(380, 66);
            chkBold.Name = "chkBold";
            chkBold.Size = new Size(74, 29);
            chkBold.TabIndex = 2;
            chkBold.Text = "굵게";
            chkBold.UseVisualStyleBackColor = true;
            chkBold.CheckedChanged += chkBold_CheckedChanged;
            // 
            // cboFont
            // 
            cboFont.FormattingEnabled = true;
            cboFont.Location = new Point(73, 58);
            cboFont.Name = "cboFont";
            cboFont.Size = new Size(278, 33);
            cboFont.TabIndex = 1;
            cboFont.SelectedIndexChanged += cboFont_SelectedIndexChanged;
            // 
            // lblFont
            // 
            lblFont.AutoSize = true;
            lblFont.Location = new Point(19, 61);
            lblFont.Name = "lblFont";
            lblFont.Size = new Size(48, 25);
            lblFont.TabIndex = 0;
            lblFont.Text = "Font";
            // 
            // grpBar
            // 
            grpBar.Controls.Add(pgDummy);
            grpBar.Controls.Add(tbDummy);
            grpBar.Location = new Point(57, 239);
            grpBar.Name = "grpBar";
            grpBar.Size = new Size(677, 172);
            grpBar.TabIndex = 5;
            grpBar.TabStop = false;
            grpBar.Text = "TrackBar && ProgressBar";
            // 
            // pgDummy
            // 
            pgDummy.Location = new Point(34, 103);
            pgDummy.Name = "pgDummy";
            pgDummy.Size = new Size(602, 34);
            pgDummy.TabIndex = 6;
            // 
            // tbDummy
            // 
            tbDummy.Location = new Point(34, 44);
            tbDummy.Maximum = 100;
            tbDummy.Name = "tbDummy";
            tbDummy.Size = new Size(602, 69);
            tbDummy.TabIndex = 0;
            tbDummy.Scroll += tbDummy_Scroll;
            // 
            // btnModal
            // 
            btnModal.Location = new Point(32, 62);
            btnModal.Name = "btnModal";
            btnModal.Size = new Size(162, 62);
            btnModal.TabIndex = 6;
            btnModal.Text = "Modal";
            btnModal.UseVisualStyleBackColor = true;
            btnModal.Click += btnModal_Click;
            // 
            // grpForm
            // 
            grpForm.Controls.Add(btnMsgBox);
            grpForm.Controls.Add(btnModaless);
            grpForm.Controls.Add(btnModal);
            grpForm.Location = new Point(57, 443);
            grpForm.Name = "grpForm";
            grpForm.Size = new Size(677, 165);
            grpForm.TabIndex = 7;
            grpForm.TabStop = false;
            grpForm.Text = "Modal && Modaless";
            // 
            // btnMsgBox
            // 
            btnMsgBox.Location = new Point(393, 62);
            btnMsgBox.Name = "btnMsgBox";
            btnMsgBox.Size = new Size(256, 62);
            btnMsgBox.TabIndex = 8;
            btnMsgBox.Text = "MessageBox";
            btnMsgBox.UseVisualStyleBackColor = true;
            btnMsgBox.Click += btnMsgBox_Click;
            // 
            // btnModaless
            // 
            btnModaless.Location = new Point(214, 62);
            btnModaless.Name = "btnModaless";
            btnModaless.Size = new Size(162, 62);
            btnModaless.TabIndex = 7;
            btnModaless.Text = "Modaless";
            btnModaless.UseVisualStyleBackColor = true;
            btnModaless.Click += btnModaless_Click;
            // 
            // grpTreeList
            // 
            grpTreeList.Controls.Add(btnAddChild);
            grpTreeList.Controls.Add(btnAddRoot);
            grpTreeList.Controls.Add(lvDummy);
            grpTreeList.Controls.Add(tvDummy);
            grpTreeList.Location = new Point(782, 40);
            grpTreeList.Name = "grpTreeList";
            grpTreeList.Size = new Size(677, 568);
            grpTreeList.TabIndex = 8;
            grpTreeList.TabStop = false;
            grpTreeList.Text = "TreeView && ListView";
            // 
            // btnAddChild
            // 
            btnAddChild.Location = new Point(175, 504);
            btnAddChild.Name = "btnAddChild";
            btnAddChild.Size = new Size(131, 51);
            btnAddChild.TabIndex = 3;
            btnAddChild.Text = "자식 추가";
            btnAddChild.UseVisualStyleBackColor = true;
            btnAddChild.ChangeUICues += btnAddChild_ChangeUICues;
            // 
            // btnAddRoot
            // 
            btnAddRoot.Location = new Point(28, 504);
            btnAddRoot.Name = "btnAddRoot";
            btnAddRoot.Size = new Size(131, 51);
            btnAddRoot.TabIndex = 2;
            btnAddRoot.Text = "루트 추가";
            btnAddRoot.UseVisualStyleBackColor = true;
            btnAddRoot.Click += btnAddRoot_Click;
            // 
            // lvDummy
            // 
            lvDummy.Location = new Point(359, 49);
            lvDummy.Name = "lvDummy";
            lvDummy.Size = new Size(295, 443);
            lvDummy.TabIndex = 1;
            lvDummy.UseCompatibleStateImageBehavior = false;
            lvDummy.View = View.Details;
            // 
            // tvDummy
            // 
            tvDummy.Location = new Point(28, 49);
            tvDummy.Name = "tvDummy";
            tvDummy.Size = new Size(310, 443);
            tvDummy.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 644);
            Controls.Add(grpTreeList);
            Controls.Add(grpBar);
            Controls.Add(grpFont);
            Controls.Add(grpForm);
            Name = "MainForm";
            Text = "Control Test";
            Load += MainForm_Load;
            grpFont.ResumeLayout(false);
            grpFont.PerformLayout();
            grpBar.ResumeLayout(false);
            grpBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbDummy).EndInit();
            grpForm.ResumeLayout(false);
            grpTreeList.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpFont;
        private CheckBox chkitalic;
        private CheckBox chkBold;
        private ComboBox cboFont;
        private Label lblFont;
        private TextBox txtSampleText;
        private GroupBox grpBar;
        private ProgressBar pgDummy;
        private TrackBar tbDummy;
        private Button btnModal;
        private GroupBox grpForm;
        private Button btnMsgBox;
        private Button btnModaless;
        private GroupBox grpTreeList;
        private ListView lvDummy;
        private TreeView tvDummy;
        private Button btnAddChild;
        private Button btnAddRoot;
    }
}
