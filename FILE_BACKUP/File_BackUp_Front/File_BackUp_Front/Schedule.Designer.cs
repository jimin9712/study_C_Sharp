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
            timeEdit4 = new DevExpress.XtraEditors.TimeEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            panelWeek = new DevExpress.XtraEditors.PanelControl();
            timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
            timeEdit2 = new DevExpress.XtraEditors.TimeEdit();
            weekDaysCheckEdit1 = new DevExpress.XtraScheduler.UI.WeekDaysCheckEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            panelMonth = new DevExpress.XtraEditors.PanelControl();
            timeEdit3 = new DevExpress.XtraEditors.TimeEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            monthlyRecurrenceControl1 = new DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panelDaily).BeginInit();
            panelDaily.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeEdit4.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelWeek).BeginInit();
            panelWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeEdit1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeEdit2.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)weekDaysCheckEdit1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelMonth).BeginInit();
            panelMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeEdit3.Properties).BeginInit();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(radioButtonMonth);
            panelControl1.Controls.Add(radioButtonWeek);
            panelControl1.Controls.Add(radioButtonDaily);
            panelControl1.Location = new System.Drawing.Point(12, 12);
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
            panelDaily.Controls.Add(timeEdit4);
            panelDaily.Controls.Add(labelControl1);
            panelDaily.Location = new System.Drawing.Point(199, 11);
            panelDaily.Name = "panelDaily";
            panelDaily.Size = new System.Drawing.Size(548, 189);
            panelDaily.TabIndex = 1;
            // 
            // timeEdit4
            // 
            timeEdit4.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEdit4.Location = new System.Drawing.Point(17, 63);
            timeEdit4.Name = "timeEdit4";
            timeEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEdit4.Size = new System.Drawing.Size(391, 28);
            timeEdit4.TabIndex = 3;
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
            panelWeek.Controls.Add(timeEdit1);
            panelWeek.Controls.Add(timeEdit2);
            panelWeek.Controls.Add(weekDaysCheckEdit1);
            panelWeek.Controls.Add(labelControl2);
            panelWeek.Location = new System.Drawing.Point(199, 11);
            panelWeek.Name = "panelWeek";
            panelWeek.Size = new System.Drawing.Size(620, 188);
            panelWeek.TabIndex = 2;
            // 
            // timeEdit1
            // 
            timeEdit1.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEdit1.Location = new System.Drawing.Point(14, 58);
            timeEdit1.Name = "timeEdit1";
            timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEdit1.Size = new System.Drawing.Size(391, 28);
            timeEdit1.TabIndex = 1;
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
            // weekDaysCheckEdit1
            // 
            weekDaysCheckEdit1.Appearance.BackColor = System.Drawing.Color.Transparent;
            weekDaysCheckEdit1.Appearance.Options.UseBackColor = true;
            weekDaysCheckEdit1.Location = new System.Drawing.Point(14, 139);
            weekDaysCheckEdit1.Margin = new System.Windows.Forms.Padding(0);
            weekDaysCheckEdit1.Name = "weekDaysCheckEdit1";
            weekDaysCheckEdit1.Size = new System.Drawing.Size(583, 34);
            weekDaysCheckEdit1.TabIndex = 2;
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
            panelMonth.Controls.Add(timeEdit3);
            panelMonth.Controls.Add(labelControl3);
            panelMonth.Controls.Add(monthlyRecurrenceControl1);
            panelMonth.Location = new System.Drawing.Point(199, 11);
            panelMonth.Name = "panelMonth";
            panelMonth.Size = new System.Drawing.Size(703, 236);
            panelMonth.TabIndex = 2;
            // 
            // timeEdit3
            // 
            timeEdit3.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEdit3.Location = new System.Drawing.Point(21, 59);
            timeEdit3.Name = "timeEdit3";
            timeEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEdit3.Size = new System.Drawing.Size(391, 28);
            timeEdit3.TabIndex = 4;
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
            monthlyRecurrenceControl1.Size = new System.Drawing.Size(659, 92);
            monthlyRecurrenceControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            simpleButton1.Location = new System.Drawing.Point(759, 271);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(143, 44);
            simpleButton1.TabIndex = 3;
            simpleButton1.Text = "확인";
            // 
            // simpleButton2
            // 
            simpleButton2.Location = new System.Drawing.Point(590, 271);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new System.Drawing.Size(143, 44);
            simpleButton2.TabIndex = 4;
            simpleButton2.Text = "뒤로";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // Schedule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(924, 354);
            Controls.Add(panelWeek);
            Controls.Add(panelMonth);
            Controls.Add(simpleButton2);
            Controls.Add(simpleButton1);
            Controls.Add(panelDaily);
            Controls.Add(panelControl1);
            Name = "Schedule";
            Text = "Schedule";
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)panelDaily).EndInit();
            panelDaily.ResumeLayout(false);
            panelDaily.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeEdit4.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelWeek).EndInit();
            panelWeek.ResumeLayout(false);
            panelWeek.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeEdit1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeEdit2.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)weekDaysCheckEdit1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelMonth).EndInit();
            panelMonth.ResumeLayout(false);
            panelMonth.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeEdit3.Properties).EndInit();
            ResumeLayout(false);
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
        private DevExpress.XtraEditors.TimeEdit timeEdit1;
        private DevExpress.XtraEditors.TimeEdit timeEdit2;
        private DevExpress.XtraScheduler.UI.WeekDaysCheckEdit weekDaysCheckEdit1;
        private DevExpress.XtraEditors.TimeEdit timeEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraScheduler.UI.MonthlyRecurrenceControl monthlyRecurrenceControl1;
        private DevExpress.XtraEditors.TimeEdit timeEdit4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}