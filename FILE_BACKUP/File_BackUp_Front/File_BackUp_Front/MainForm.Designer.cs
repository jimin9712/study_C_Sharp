namespace File_BackUp_Front
{
    partial class MainForm
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
            BtnBackUp = new DevExpress.XtraEditors.SimpleButton();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            source_folder = new DevExpress.XtraEditors.PictureEdit();
            progressBar = new DevExpress.XtraEditors.ProgressBarControl();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            textEdit3 = new DevExpress.XtraEditors.TextEdit();
            stackPanel1 = new DevExpress.Utils.Layout.StackPanel();
            target_folder = new DevExpress.XtraEditors.PictureEdit();
            txtSource = new DevExpress.XtraEditors.TextEdit();
            lblStatus = new DevExpress.XtraEditors.LabelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txtTarget = new DevExpress.XtraEditors.TextEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            Menu = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            textEdit2 = new DevExpress.XtraEditors.TextEdit();
            textEdit1 = new DevExpress.XtraEditors.TextEdit();
            pictureEdit2 = new DevExpress.XtraEditors.PictureEdit();
            pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)source_folder.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)progressBar.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)textEdit3.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)target_folder.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSource.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTarget.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Menu).BeginInit();
            Menu.SuspendLayout();
            xtraTabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)progressBarControl1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).BeginInit();
            SuspendLayout();
            // 
            // BtnBackUp
            // 
            BtnBackUp.Location = new System.Drawing.Point(1253, 737);
            BtnBackUp.Name = "BtnBackUp";
            BtnBackUp.Size = new System.Drawing.Size(171, 49);
            BtnBackUp.TabIndex = 0;
            BtnBackUp.Text = "Back up Now";
            BtnBackUp.Click += BtnBackUp_Click;
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Controls.Add(simpleButton6);
            xtraTabPage1.Controls.Add(labelControl5);
            xtraTabPage1.Controls.Add(progressPanel1);
            xtraTabPage1.Controls.Add(source_folder);
            xtraTabPage1.Controls.Add(progressBar);
            xtraTabPage1.Controls.Add(groupControl1);
            xtraTabPage1.Controls.Add(target_folder);
            xtraTabPage1.Controls.Add(BtnBackUp);
            xtraTabPage1.Controls.Add(txtSource);
            xtraTabPage1.Controls.Add(lblStatus);
            xtraTabPage1.Controls.Add(labelControl1);
            xtraTabPage1.Controls.Add(txtTarget);
            xtraTabPage1.Controls.Add(labelControl2);
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new System.Drawing.Size(1468, 819);
            xtraTabPage1.Text = "Backup";
            // 
            // simpleButton6
            // 
            simpleButton6.Location = new System.Drawing.Point(1049, 737);
            simpleButton6.Name = "simpleButton6";
            simpleButton6.Size = new System.Drawing.Size(164, 49);
            simpleButton6.TabIndex = 14;
            simpleButton6.Text = "Schedule";
            simpleButton6.Click += simpleButton6_Click;
            // 
            // labelControl5
            // 
            labelControl5.Location = new System.Drawing.Point(151, 62);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(107, 22);
            labelControl5.TabIndex = 13;
            labelControl5.Text = "Source Folder";
            // 
            // progressPanel1
            // 
            progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            progressPanel1.Appearance.Options.UseBackColor = true;
            progressPanel1.Location = new System.Drawing.Point(617, 49);
            progressPanel1.Name = "progressPanel1";
            progressPanel1.Size = new System.Drawing.Size(214, 99);
            progressPanel1.TabIndex = 12;
            progressPanel1.Text = "progressPanel1";
            // 
            // source_folder
            // 
            source_folder.Location = new System.Drawing.Point(151, 90);
            source_folder.Name = "source_folder";
            source_folder.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            source_folder.Size = new System.Drawing.Size(150, 144);
            source_folder.TabIndex = 9;
            source_folder.Click += source_folder_Click;
            // 
            // progressBar
            // 
            progressBar.Location = new System.Drawing.Point(398, 156);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(688, 40);
            progressBar.TabIndex = 7;
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(textEdit3);
            groupControl1.Controls.Add(stackPanel1);
            groupControl1.Location = new System.Drawing.Point(55, 340);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1369, 382);
            groupControl1.TabIndex = 11;
            groupControl1.Text = "Task details";
            // 
            // textEdit3
            // 
            textEdit3.Location = new System.Drawing.Point(15, 53);
            textEdit3.Name = "textEdit3";
            textEdit3.Size = new System.Drawing.Size(1338, 28);
            textEdit3.TabIndex = 1;
            // 
            // stackPanel1
            // 
            stackPanel1.Location = new System.Drawing.Point(180, 166);
            stackPanel1.Name = "stackPanel1";
            stackPanel1.Size = new System.Drawing.Size(8, 8);
            stackPanel1.TabIndex = 0;
            stackPanel1.UseSkinIndents = true;
            // 
            // target_folder
            // 
            target_folder.Location = new System.Drawing.Point(1161, 90);
            target_folder.Name = "target_folder";
            target_folder.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            target_folder.Size = new System.Drawing.Size(150, 144);
            target_folder.TabIndex = 10;
            target_folder.Click += target_folder_Click;
            // 
            // txtSource
            // 
            txtSource.Location = new System.Drawing.Point(55, 253);
            txtSource.Name = "txtSource";
            txtSource.Size = new System.Drawing.Size(364, 28);
            txtSource.TabIndex = 3;
            // 
            // lblStatus
            // 
            lblStatus.Location = new System.Drawing.Point(399, 128);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(39, 22);
            lblStatus.TabIndex = 8;
            lblStatus.Text = "진행률";
            // 
            // labelControl1
            // 
            labelControl1.Location = new System.Drawing.Point(151, 62);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(0, 22);
            labelControl1.TabIndex = 1;
            // 
            // txtTarget
            // 
            txtTarget.Location = new System.Drawing.Point(1035, 253);
            txtTarget.Name = "txtTarget";
            txtTarget.Size = new System.Drawing.Size(389, 28);
            txtTarget.TabIndex = 4;
            // 
            // labelControl2
            // 
            labelControl2.Location = new System.Drawing.Point(1161, 62);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(105, 22);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "Target Folder";
            // 
            // Menu
            // 
            Menu.Location = new System.Drawing.Point(2, 3);
            Menu.Name = "Menu";
            Menu.SelectedTabPage = xtraTabPage1;
            Menu.ShowTabHeader = DevExpress.Utils.DefaultBoolean.True;
            Menu.Size = new System.Drawing.Size(1470, 857);
            Menu.TabIndex = 11;
            Menu.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage3, xtraTabPage2 });
            // 
            // xtraTabPage3
            // 
            xtraTabPage3.Controls.Add(labelControl7);
            xtraTabPage3.Controls.Add(simpleButton1);
            xtraTabPage3.Controls.Add(dateTimePicker2);
            xtraTabPage3.Controls.Add(dateTimePicker1);
            xtraTabPage3.Controls.Add(labelControl6);
            xtraTabPage3.Controls.Add(gridControl1);
            xtraTabPage3.Name = "xtraTabPage3";
            xtraTabPage3.Size = new System.Drawing.Size(1468, 819);
            xtraTabPage3.Text = "History";
            // 
            // labelControl7
            // 
            labelControl7.Location = new System.Drawing.Point(432, 745);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new System.Drawing.Size(7, 22);
            labelControl7.TabIndex = 6;
            labelControl7.Text = "-";
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(765, 741);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(96, 30);
            simpleButton1.TabIndex = 5;
            simpleButton1.Text = "검색";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new System.Drawing.Point(450, 742);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new System.Drawing.Size(300, 29);
            dateTimePicker2.TabIndex = 4;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new System.Drawing.Point(124, 742);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new System.Drawing.Size(300, 29);
            dateTimePicker1.TabIndex = 3;
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new System.Drawing.Point(9, 741);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(91, 29);
            labelControl6.TabIndex = 1;
            labelControl6.Text = "시간 선택";
            // 
            // gridControl1
            // 
            gridControl1.Location = new System.Drawing.Point(9, 15);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(1447, 692);
            gridControl1.TabIndex = 0;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.DoubleClick += gridView1_DoubleClick;
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Controls.Add(simpleButton5);
            xtraTabPage2.Controls.Add(simpleButton4);
            xtraTabPage2.Controls.Add(progressBarControl1);
            xtraTabPage2.Controls.Add(simpleButton3);
            xtraTabPage2.Controls.Add(simpleButton2);
            xtraTabPage2.Controls.Add(textEdit2);
            xtraTabPage2.Controls.Add(textEdit1);
            xtraTabPage2.Controls.Add(pictureEdit2);
            xtraTabPage2.Controls.Add(pictureEdit1);
            xtraTabPage2.Controls.Add(labelControl4);
            xtraTabPage2.Controls.Add(labelControl3);
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new System.Drawing.Size(1468, 819);
            xtraTabPage2.Text = "Restore";
            // 
            // simpleButton5
            // 
            simpleButton5.Location = new System.Drawing.Point(1095, 643);
            simpleButton5.Name = "simpleButton5";
            simpleButton5.Size = new System.Drawing.Size(168, 51);
            simpleButton5.TabIndex = 10;
            simpleButton5.Text = "simpleButton5";
            // 
            // simpleButton4
            // 
            simpleButton4.Location = new System.Drawing.Point(884, 643);
            simpleButton4.Name = "simpleButton4";
            simpleButton4.Size = new System.Drawing.Size(168, 51);
            simpleButton4.TabIndex = 4;
            simpleButton4.Text = "simpleButton4";
            // 
            // progressBarControl1
            // 
            progressBarControl1.Location = new System.Drawing.Point(209, 440);
            progressBarControl1.Name = "progressBarControl1";
            progressBarControl1.Size = new System.Drawing.Size(1035, 67);
            progressBarControl1.TabIndex = 9;
            // 
            // simpleButton3
            // 
            simpleButton3.Location = new System.Drawing.Point(1097, 346);
            simpleButton3.Name = "simpleButton3";
            simpleButton3.Size = new System.Drawing.Size(94, 30);
            simpleButton3.TabIndex = 8;
            simpleButton3.Text = "simpleButton3";
            // 
            // simpleButton2
            // 
            simpleButton2.Location = new System.Drawing.Point(447, 346);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new System.Drawing.Size(94, 30);
            simpleButton2.TabIndex = 7;
            simpleButton2.Text = "simpleButton2";
            // 
            // textEdit2
            // 
            textEdit2.Location = new System.Drawing.Point(870, 312);
            textEdit2.Name = "textEdit2";
            textEdit2.Size = new System.Drawing.Size(321, 28);
            textEdit2.TabIndex = 6;
            // 
            // textEdit1
            // 
            textEdit1.Location = new System.Drawing.Point(220, 312);
            textEdit1.Name = "textEdit1";
            textEdit1.Size = new System.Drawing.Size(321, 28);
            textEdit1.TabIndex = 4;
            // 
            // pictureEdit2
            // 
            pictureEdit2.Location = new System.Drawing.Point(870, 153);
            pictureEdit2.Name = "pictureEdit2";
            pictureEdit2.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit2.Size = new System.Drawing.Size(150, 144);
            pictureEdit2.TabIndex = 5;
            // 
            // pictureEdit1
            // 
            pictureEdit1.Location = new System.Drawing.Point(220, 153);
            pictureEdit1.Name = "pictureEdit1";
            pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            pictureEdit1.Size = new System.Drawing.Size(150, 144);
            pictureEdit1.TabIndex = 4;
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(870, 125);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(105, 22);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "Target Folder";
            // 
            // labelControl3
            // 
            labelControl3.Location = new System.Drawing.Point(220, 125);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(107, 22);
            labelControl3.TabIndex = 2;
            labelControl3.Text = "Source Folder";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1471, 853);
            Controls.Add(Menu);
            Name = "MainForm";
            Text = "MainForm";
            Load += MainForm_Load_1;
            xtraTabPage1.ResumeLayout(false);
            xtraTabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)source_folder.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)progressBar.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)textEdit3.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)stackPanel1).EndInit();
            ((System.ComponentModel.ISupportInitialize)target_folder.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSource.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTarget.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)Menu).EndInit();
            Menu.ResumeLayout(false);
            xtraTabPage3.ResumeLayout(false);
            xtraTabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            xtraTabPage2.ResumeLayout(false);
            xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)progressBarControl1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)textEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureEdit1.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BtnBackUp;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabControl Menu;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.TextEdit textEdit2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit2;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.PictureEdit source_folder;
        private DevExpress.XtraEditors.PictureEdit target_folder;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lblStatus;
        private DevExpress.XtraEditors.ProgressBarControl progressBar;
        private DevExpress.XtraEditors.TextEdit txtTarget;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSource;
        private DevExpress.Utils.Layout.StackPanel stackPanel1;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.TextEdit textEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
    }
}