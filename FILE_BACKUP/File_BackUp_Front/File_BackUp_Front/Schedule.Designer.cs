namespace File_BackUp_Front
{
    partial class Schedule
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
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            radioButtonMonth = new System.Windows.Forms.RadioButton();
            radioButtonWeek = new System.Windows.Forms.RadioButton();
            radioButtonDaily = new System.Windows.Forms.RadioButton();
            panelDaily = new DevExpress.XtraEditors.PanelControl();
            timeEditDaily = new DevExpress.XtraEditors.TimeEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            panelWeek = new DevExpress.XtraEditors.PanelControl();
            timeEditWeek = new DevExpress.XtraEditors.TimeEdit();
            timeEdit2 = new DevExpress.XtraEditors.TimeEdit();
            chkboxWeekday = new DevExpress.XtraScheduler.UI.WeekDaysCheckEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            panelMonth = new DevExpress.XtraEditors.PanelControl();
            timeEditMonth = new DevExpress.XtraEditors.TimeEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            monthlyRecurrenceControl1 = new DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            labelControl4 = new DevExpress.XtraEditors.LabelControl();
            txtSource = new DevExpress.XtraEditors.TextEdit();
            txtTarget = new DevExpress.XtraEditors.TextEdit();
            labelControl5 = new DevExpress.XtraEditors.LabelControl();
            labelControl6 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelDaily).BeginInit();
            panelDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeEditDaily.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelWeek).BeginInit();
            panelWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeEditWeek.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chkboxWeekday).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelMonth).BeginInit();
            panelMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeEditMonth.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtSource.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtTarget.Properties).BeginInit();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(radioButtonMonth);
            panelControl1.Controls.Add(radioButtonWeek);
            panelControl1.Controls.Add(radioButtonDaily);
            panelControl1.Location = new System.Drawing.Point(12, 24);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(181, 188);
            panelControl1.TabIndex = 0;
            // 
            // radioButtonMonth
            // 
            radioButtonMonth.AutoSize = true;
            radioButtonMonth.Location = new System.Drawing.Point(20, 126);
            radioButtonMonth.Name = "radioButtonMonth";
            radioButtonMonth.Size = new System.Drawing.Size(61, 26);
            radioButtonMonth.TabIndex = 2;
            radioButtonMonth.TabStop = true;
            radioButtonMonth.Text = "월간";
            radioButtonMonth.UseVisualStyleBackColor = true;
            radioButtonMonth.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonWeek
            // 
            radioButtonWeek.AutoSize = true;
            radioButtonWeek.Location = new System.Drawing.Point(20, 74);
            radioButtonWeek.Name = "radioButtonWeek";
            radioButtonWeek.Size = new System.Drawing.Size(61, 26);
            radioButtonWeek.TabIndex = 1;
            radioButtonWeek.TabStop = true;
            radioButtonWeek.Text = "주간";
            radioButtonWeek.UseVisualStyleBackColor = true;
            radioButtonWeek.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonDaily
            // 
            radioButtonDaily.AutoSize = true;
            radioButtonDaily.Location = new System.Drawing.Point(20, 23);
            radioButtonDaily.Name = "radioButtonDaily";
            radioButtonDaily.Size = new System.Drawing.Size(61, 26);
            radioButtonDaily.TabIndex = 0;
            radioButtonDaily.TabStop = true;
            radioButtonDaily.Text = "매일";
            radioButtonDaily.UseVisualStyleBackColor = true;
            radioButtonDaily.CheckedChanged += radioButton_CheckedChanged;
            // 
            // panelDaily
            // 
            panelDaily.Controls.Add(timeEditDaily);
            panelDaily.Controls.Add(labelControl1);
            panelDaily.Location = new System.Drawing.Point(221, 24);
            panelDaily.Name = "panelDaily";
            panelDaily.Size = new System.Drawing.Size(548, 189);
            panelDaily.TabIndex = 1;
            // 
            // timeEditDaily
            // 
            timeEditDaily.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEditDaily.Location = new System.Drawing.Point(17, 63);
            timeEditDaily.Name = "timeEditDaily";
            timeEditDaily.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditDaily.Size = new System.Drawing.Size(391, 28);
            timeEditDaily.TabIndex = 3;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(17, 24);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(162, 24);
            labelControl1.TabIndex = 0;
            labelControl1.Text = "다음 시간에 백업 실행";
            // 
            // panelWeek
            // 
            panelWeek.Controls.Add(timeEditWeek);
            panelWeek.Controls.Add(timeEdit2);
            panelWeek.Controls.Add(chkboxWeekday);
            panelWeek.Controls.Add(labelControl2);
            panelWeek.Location = new System.Drawing.Point(221, 24);
            panelWeek.Name = "panelWeek";
            panelWeek.Size = new System.Drawing.Size(620, 188);
            panelWeek.TabIndex = 2;
            // 
            // timeEditWeek
            // 
            timeEditWeek.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEditWeek.Location = new System.Drawing.Point(14, 58);
            timeEditWeek.Name = "timeEditWeek";
            timeEditWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditWeek.Size = new System.Drawing.Size(391, 28);
            timeEditWeek.TabIndex = 1;
            // 
            // timeEdit2
            // 
            timeEdit2.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEdit2.Location = new System.Drawing.Point(14, 58);
            timeEdit2.Name = "timeEdit2";
            timeEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEdit2.Size = new System.Drawing.Size(391, 28);
            timeEdit2.TabIndex = 2;
            // 
            // chkboxWeekday
            // 
            chkboxWeekday.Appearance.BackColor = System.Drawing.Color.Transparent;
            chkboxWeekday.Appearance.Options.UseBackColor = true;
            chkboxWeekday.Location = new System.Drawing.Point(14, 139);
            chkboxWeekday.Margin = new System.Windows.Forms.Padding(0);
            chkboxWeekday.Name = "chkboxWeekday";
            chkboxWeekday.Size = new System.Drawing.Size(583, 34);
            chkboxWeekday.TabIndex = 2;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(14, 23);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(162, 24);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "다음 시간에 백업 실행";
            // 
            // panelMonth
            // 
            panelMonth.Controls.Add(timeEditMonth);
            panelMonth.Controls.Add(labelControl3);
            panelMonth.Controls.Add(monthlyRecurrenceControl1);
            panelMonth.Location = new System.Drawing.Point(221, 24);
            panelMonth.Name = "panelMonth";
            panelMonth.Size = new System.Drawing.Size(703, 236);
            panelMonth.TabIndex = 2;
            // 
            // timeEditMonth
            // 
            timeEditMonth.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEditMonth.Location = new System.Drawing.Point(21, 59);
            timeEditMonth.Name = "timeEditMonth";
            timeEditMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditMonth.Size = new System.Drawing.Size(391, 28);
            timeEditMonth.TabIndex = 4;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(21, 24);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(162, 24);
            labelControl3.TabIndex = 3;
            labelControl3.Text = "다음 시간에 백업 실행";
            // 
            // monthlyRecurrenceControl1
            // 
            monthlyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            monthlyRecurrenceControl1.Appearance.Options.UseBackColor = true;
            monthlyRecurrenceControl1.Location = new System.Drawing.Point(21, 127);
            monthlyRecurrenceControl1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            monthlyRecurrenceControl1.Name = "monthlyRecurrenceControl1";
            monthlyRecurrenceControl1.Size = new System.Drawing.Size(659, 102);
            monthlyRecurrenceControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(762, 441);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(143, 44);
            simpleButton1.TabIndex = 3;
            simpleButton1.Text = "확인";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // simpleButton2
            // 
            simpleButton2.Location = new System.Drawing.Point(593, 441);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new System.Drawing.Size(143, 44);
            simpleButton2.TabIndex = 4;
            simpleButton2.Text = "뒤로";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // labelControl4
            // 
            labelControl4.Location = new System.Drawing.Point(16, 16);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(58, 22);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "백업 주기";
            // 
            // txtSource
            // 
            txtSource.Location = new System.Drawing.Point(32, 336);
            txtSource.Name = "txtSource";
            txtSource.Properties.ReadOnly = true;
            txtSource.Size = new System.Drawing.Size(408, 28);
            txtSource.TabIndex = 5;
            // 
            // txtTarget
            // 
            txtTarget.Location = new System.Drawing.Point(32, 450);
            txtTarget.Name = "txtTarget";
            txtTarget.Properties.ReadOnly = true;
            txtTarget.Size = new System.Drawing.Size(408, 28);
            txtTarget.TabIndex = 6;
            // 
            // labelControl5
            // 
            labelControl5.Location = new System.Drawing.Point(32, 308);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(58, 22);
            labelControl5.TabIndex = 7;
            labelControl5.Text = "소스 폴더";
            // 
            // labelControl6
            // 
            labelControl6.Location = new System.Drawing.Point(32, 422);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(58, 22);
            labelControl6.TabIndex = 8;
            labelControl6.Text = "타겟 폴더";
            // 
            // Schedule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(962, 520);
            Controls.Add(labelControl6);
            Controls.Add(labelControl5);
            Controls.Add(txtTarget);
            Controls.Add(txtSource);
            Controls.Add(labelControl4);
            Controls.Add(panelWeek);
            Controls.Add(panelMonth);
            Controls.Add(simpleButton2);
            Controls.Add(simpleButton1);
            Controls.Add(panelDaily);
            Controls.Add(panelControl1);
            Name = "Schedule";
            Text = "백업 예약";
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelDaily).EndInit();
            panelDaily.ResumeLayout(false);
            panelDaily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeEditDaily.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelWeek).EndInit();
            panelWeek.ResumeLayout(false);
            panelWeek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeEditWeek.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)chkboxWeekday).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelMonth).EndInit();
            panelMonth.ResumeLayout(false);
            panelMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeEditMonth.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtSource.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtTarget.Properties).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.RadioButton radioButtonMonth;
        private System.Windows.Forms.RadioButton radioButtonWeek;
        private System.Windows.Forms.RadioButton radioButtonDaily;
        private DevExpress.XtraEditors.PanelControl panelDaily;
        private DevExpress.XtraEditors.PanelControl panelWeek;
        private DevExpress.XtraEditors.PanelControl panelMonth;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TimeEdit timeEditWeek;
        private DevExpress.XtraEditors.TimeEdit timeEdit2;
        private DevExpress.XtraScheduler.UI.WeekDaysCheckEdit chkboxWeekday;
        private DevExpress.XtraEditors.TimeEdit timeEditMonth;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl monthlyRecurrenceControl1;
        private DevExpress.XtraEditors.TimeEdit timeEditDaily;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtSource;
        private DevExpress.XtraEditors.TextEdit txtTarget;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}