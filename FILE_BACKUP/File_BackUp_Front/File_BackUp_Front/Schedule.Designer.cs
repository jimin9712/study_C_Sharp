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
            radioButtonOnce = new System.Windows.Forms.RadioButton();
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
            gridControlSchedules = new DevExpress.XtraGrid.GridControl();
            gridViewSchedules = new DevExpress.XtraGrid.Views.Grid.GridView();
            btn_delete = new DevExpress.XtraEditors.SimpleButton();
            btn_modify = new DevExpress.XtraEditors.SimpleButton();
            labelControl7 = new DevExpress.XtraEditors.LabelControl();
            simpleButton7 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            labelControl8 = new DevExpress.XtraEditors.LabelControl();
            panelOnce = new DevExpress.XtraEditors.PanelControl();
            dateEditOnce = new DevExpress.XtraEditors.DateEdit();
            timeEditOnce = new DevExpress.XtraEditors.TimeEdit();
            labelControl9 = new DevExpress.XtraEditors.LabelControl();
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
            ((System.ComponentModel.ISupportInitialize)gridControlSchedules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSchedules).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelOnce).BeginInit();
            panelOnce.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditOnce.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dateEditOnce.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeEditOnce.Properties).BeginInit();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(radioButtonOnce);
            panelControl1.Controls.Add(radioButtonMonth);
            panelControl1.Controls.Add(radioButtonWeek);
            panelControl1.Controls.Add(radioButtonDaily);
            panelControl1.Location = new System.Drawing.Point(12, 24);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(181, 277);
            panelControl1.TabIndex = 0;
            // 
            // radioButtonOnce
            // 
            radioButtonOnce.AutoSize = true;
            radioButtonOnce.Font = new System.Drawing.Font("맑은 고딕", 9F);
            radioButtonOnce.Location = new System.Drawing.Point(21, 43);
            radioButtonOnce.Name = "radioButtonOnce";
            radioButtonOnce.Size = new System.Drawing.Size(73, 29);
            radioButtonOnce.TabIndex = 3;
            radioButtonOnce.TabStop = true;
            radioButtonOnce.Text = "한번";
            radioButtonOnce.UseVisualStyleBackColor = true;
            radioButtonOnce.CheckedChanged += radioButtonOnce_CheckedChanged;
            // 
            // radioButtonMonth
            // 
            radioButtonMonth.AutoSize = true;
            radioButtonMonth.Font = new System.Drawing.Font("맑은 고딕", 9F);
            radioButtonMonth.Location = new System.Drawing.Point(21, 163);
            radioButtonMonth.Name = "radioButtonMonth";
            radioButtonMonth.Size = new System.Drawing.Size(73, 29);
            radioButtonMonth.TabIndex = 2;
            radioButtonMonth.TabStop = true;
            radioButtonMonth.Text = "월간";
            radioButtonMonth.UseVisualStyleBackColor = true;
            radioButtonMonth.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonWeek
            // 
            radioButtonWeek.AutoSize = true;
            radioButtonWeek.Font = new System.Drawing.Font("맑은 고딕", 9F);
            radioButtonWeek.Location = new System.Drawing.Point(21, 123);
            radioButtonWeek.Name = "radioButtonWeek";
            radioButtonWeek.Size = new System.Drawing.Size(73, 29);
            radioButtonWeek.TabIndex = 1;
            radioButtonWeek.TabStop = true;
            radioButtonWeek.Text = "주간";
            radioButtonWeek.UseVisualStyleBackColor = true;
            radioButtonWeek.CheckedChanged += radioButton_CheckedChanged;
            // 
            // radioButtonDaily
            // 
            radioButtonDaily.AutoSize = true;
            radioButtonDaily.Font = new System.Drawing.Font("맑은 고딕", 9F);
            radioButtonDaily.Location = new System.Drawing.Point(21, 83);
            radioButtonDaily.Name = "radioButtonDaily";
            radioButtonDaily.Size = new System.Drawing.Size(73, 29);
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
            timeEditDaily.Location = new System.Drawing.Point(14, 58);
            timeEditDaily.Name = "timeEditDaily";
            timeEditDaily.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            timeEditDaily.Properties.Appearance.Options.UseFont = true;
            timeEditDaily.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditDaily.Size = new System.Drawing.Size(391, 32);
            timeEditDaily.TabIndex = 3;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(17, 24);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(180, 25);
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
            timeEditWeek.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            timeEditWeek.Properties.Appearance.Options.UseFont = true;
            timeEditWeek.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditWeek.Size = new System.Drawing.Size(391, 32);
            timeEditWeek.TabIndex = 1;
            // 
            // timeEdit2
            // 
            timeEdit2.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEdit2.Location = new System.Drawing.Point(14, 58);
            timeEdit2.Name = "timeEdit2";
            timeEdit2.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            timeEdit2.Properties.Appearance.Options.UseFont = true;
            timeEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEdit2.Size = new System.Drawing.Size(391, 32);
            timeEdit2.TabIndex = 2;
            // 
            // chkboxWeekday
            // 
            chkboxWeekday.Appearance.BackColor = System.Drawing.Color.Transparent;
            chkboxWeekday.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            chkboxWeekday.Appearance.Options.UseBackColor = true;
            chkboxWeekday.Appearance.Options.UseFont = true;
            chkboxWeekday.Location = new System.Drawing.Point(14, 158);
            chkboxWeekday.Margin = new System.Windows.Forms.Padding(0);
            chkboxWeekday.Name = "chkboxWeekday";
            chkboxWeekday.Size = new System.Drawing.Size(583, 39);
            chkboxWeekday.TabIndex = 2;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(17, 24);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(180, 25);
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
            panelMonth.Size = new System.Drawing.Size(703, 277);
            panelMonth.TabIndex = 2;
            // 
            // timeEditMonth
            // 
            timeEditMonth.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEditMonth.Location = new System.Drawing.Point(14, 58);
            timeEditMonth.Name = "timeEditMonth";
            timeEditMonth.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            timeEditMonth.Properties.Appearance.Options.UseFont = true;
            timeEditMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditMonth.Size = new System.Drawing.Size(391, 32);
            timeEditMonth.TabIndex = 4;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(17, 24);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(180, 25);
            labelControl3.TabIndex = 3;
            labelControl3.Text = "다음 시간에 백업 실행";
            // 
            // monthlyRecurrenceControl1
            // 
            monthlyRecurrenceControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            monthlyRecurrenceControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            monthlyRecurrenceControl1.Appearance.Options.UseBackColor = true;
            monthlyRecurrenceControl1.Appearance.Options.UseFont = true;
            monthlyRecurrenceControl1.Location = new System.Drawing.Point(21, 144);
            monthlyRecurrenceControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            monthlyRecurrenceControl1.Name = "monthlyRecurrenceControl1";
            monthlyRecurrenceControl1.Size = new System.Drawing.Size(659, 116);
            monthlyRecurrenceControl1.TabIndex = 0;
            // 
            // simpleButton1
            // 
            simpleButton1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            simpleButton1.Appearance.Options.UseFont = true;
            simpleButton1.Location = new System.Drawing.Point(1332, 319);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(143, 44);
            simpleButton1.TabIndex = 3;
            simpleButton1.Text = "예약 등록";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // simpleButton2
            // 
            simpleButton2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            simpleButton2.Appearance.Options.UseFont = true;
            simpleButton2.Location = new System.Drawing.Point(1163, 319);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new System.Drawing.Size(143, 44);
            simpleButton2.TabIndex = 4;
            simpleButton2.Text = "뒤로";
            simpleButton2.Click += simpleButton2_Click;
            // 
            // labelControl4
            // 
            labelControl4.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            labelControl4.Appearance.Options.UseFont = true;
            labelControl4.Location = new System.Drawing.Point(16, 16);
            labelControl4.Name = "labelControl4";
            labelControl4.Size = new System.Drawing.Size(78, 25);
            labelControl4.TabIndex = 3;
            labelControl4.Text = "백업 주기";
            // 
            // txtSource
            // 
            txtSource.Location = new System.Drawing.Point(999, 95);
            txtSource.Name = "txtSource";
            txtSource.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            txtSource.Properties.Appearance.Options.UseFont = true;
            txtSource.Size = new System.Drawing.Size(408, 32);
            txtSource.TabIndex = 5;
            // 
            // txtTarget
            // 
            txtTarget.Location = new System.Drawing.Point(999, 209);
            txtTarget.Name = "txtTarget";
            txtTarget.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            txtTarget.Properties.Appearance.Options.UseFont = true;
            txtTarget.Size = new System.Drawing.Size(408, 32);
            txtTarget.TabIndex = 6;
            // 
            // labelControl5
            // 
            labelControl5.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            labelControl5.Appearance.Options.UseFont = true;
            labelControl5.Location = new System.Drawing.Point(999, 67);
            labelControl5.Name = "labelControl5";
            labelControl5.Size = new System.Drawing.Size(78, 25);
            labelControl5.TabIndex = 7;
            labelControl5.Text = "소스 폴더";
            // 
            // labelControl6
            // 
            labelControl6.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            labelControl6.Appearance.Options.UseFont = true;
            labelControl6.Location = new System.Drawing.Point(999, 181);
            labelControl6.Name = "labelControl6";
            labelControl6.Size = new System.Drawing.Size(78, 25);
            labelControl6.TabIndex = 8;
            labelControl6.Text = "타겟 폴더";
            // 
            // gridControlSchedules
            // 
            gridControlSchedules.Location = new System.Drawing.Point(12, 378);
            gridControlSchedules.MainView = gridViewSchedules;
            gridControlSchedules.Name = "gridControlSchedules";
            gridControlSchedules.Size = new System.Drawing.Size(1463, 444);
            gridControlSchedules.TabIndex = 9;
            gridControlSchedules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridViewSchedules });
            // 
            // gridViewSchedules
            // 
            gridViewSchedules.GridControl = gridControlSchedules;
            gridViewSchedules.Name = "gridViewSchedules";
            gridViewSchedules.OptionsBehavior.ReadOnly = true;
            gridViewSchedules.OptionsView.ShowFooter = true;
            gridViewSchedules.OptionsView.ShowGroupPanel = false;
            // 
            // btn_delete
            // 
            btn_delete.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            btn_delete.Appearance.Options.UseFont = true;
            btn_delete.Location = new System.Drawing.Point(1359, 773);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new System.Drawing.Size(110, 42);
            btn_delete.TabIndex = 11;
            btn_delete.Text = "예약 삭제";
            btn_delete.Click += btn_delete_Click;
            // 
            // btn_modify
            // 
            btn_modify.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            btn_modify.Appearance.Options.UseFont = true;
            btn_modify.Location = new System.Drawing.Point(1243, 773);
            btn_modify.Name = "btn_modify";
            btn_modify.Size = new System.Drawing.Size(110, 42);
            btn_modify.TabIndex = 12;
            btn_modify.Text = "예약 수정";
            btn_modify.Click += btn_modify_Click;
            // 
            // labelControl7
            // 
            labelControl7.Location = new System.Drawing.Point(21, 378);
            labelControl7.Name = "labelControl7";
            labelControl7.Size = new System.Drawing.Size(0, 22);
            labelControl7.TabIndex = 13;
            // 
            // simpleButton7
            // 
            simpleButton7.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            simpleButton7.Appearance.Options.UseFont = true;
            simpleButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            simpleButton7.Location = new System.Drawing.Point(1413, 95);
            simpleButton7.Name = "simpleButton7";
            simpleButton7.Size = new System.Drawing.Size(36, 32);
            simpleButton7.TabIndex = 16;
            simpleButton7.Text = "...";
            simpleButton7.Click += simpleButton7_Click;
            // 
            // simpleButton3
            // 
            simpleButton3.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            simpleButton3.Appearance.Options.UseFont = true;
            simpleButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            simpleButton3.Location = new System.Drawing.Point(1413, 209);
            simpleButton3.Name = "simpleButton3";
            simpleButton3.Size = new System.Drawing.Size(36, 32);
            simpleButton3.TabIndex = 17;
            simpleButton3.Text = "...";
            simpleButton3.Click += simpleButton3_Click;
            // 
            // labelControl8
            // 
            labelControl8.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            labelControl8.Appearance.Options.UseFont = true;
            labelControl8.Location = new System.Drawing.Point(13, 347);
            labelControl8.Name = "labelControl8";
            labelControl8.Size = new System.Drawing.Size(138, 25);
            labelControl8.TabIndex = 3;
            labelControl8.Text = "사용자 예약 내역";
            // 
            // panelOnce
            // 
            panelOnce.Controls.Add(dateEditOnce);
            panelOnce.Controls.Add(timeEditOnce);
            panelOnce.Controls.Add(labelControl9);
            panelOnce.Location = new System.Drawing.Point(221, 24);
            panelOnce.Name = "panelOnce";
            panelOnce.Size = new System.Drawing.Size(620, 188);
            panelOnce.TabIndex = 18;
            // 
            // dateEditOnce
            // 
            dateEditOnce.EditValue = null;
            dateEditOnce.Location = new System.Drawing.Point(14, 71);
            dateEditOnce.Name = "dateEditOnce";
            dateEditOnce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditOnce.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dateEditOnce.Size = new System.Drawing.Size(391, 28);
            dateEditOnce.TabIndex = 3;
            // 
            // timeEditOnce
            // 
            timeEditOnce.EditValue = new System.DateTime(2025, 6, 4, 0, 0, 0, 0);
            timeEditOnce.Location = new System.Drawing.Point(14, 127);
            timeEditOnce.Name = "timeEditOnce";
            timeEditOnce.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            timeEditOnce.Properties.Appearance.Options.UseFont = true;
            timeEditOnce.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            timeEditOnce.Size = new System.Drawing.Size(391, 32);
            timeEditOnce.TabIndex = 1;
            // 
            // labelControl9
            // 
            labelControl9.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 129);
            labelControl9.Appearance.Options.UseFont = true;
            labelControl9.Location = new System.Drawing.Point(17, 24);
            labelControl9.Name = "labelControl9";
            labelControl9.Size = new System.Drawing.Size(180, 25);
            labelControl9.TabIndex = 1;
            labelControl9.Text = "다음 시간에 백업 실행";
            // 
            // Schedule
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1484, 834);
            Controls.Add(labelControl8);
            Controls.Add(simpleButton3);
            Controls.Add(panelWeek);
            Controls.Add(simpleButton7);
            Controls.Add(labelControl7);
            Controls.Add(btn_modify);
            Controls.Add(btn_delete);
            Controls.Add(gridControlSchedules);
            Controls.Add(labelControl6);
            Controls.Add(labelControl5);
            Controls.Add(txtTarget);
            Controls.Add(txtSource);
            Controls.Add(labelControl4);
            Controls.Add(panelMonth);
            Controls.Add(simpleButton2);
            Controls.Add(simpleButton1);
            Controls.Add(panelDaily);
            Controls.Add(panelControl1);
            Controls.Add(panelOnce);
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
            ((System.ComponentModel.ISupportInitialize)gridControlSchedules).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridViewSchedules).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelOnce).EndInit();
            panelOnce.ResumeLayout(false);
            panelOnce.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dateEditOnce.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dateEditOnce.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeEditOnce.Properties).EndInit();
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
        private DevExpress.XtraGrid.GridControl gridControlSchedules;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSchedules;
        private DevExpress.XtraEditors.SimpleButton btn_delete;
        private DevExpress.XtraEditors.SimpleButton btn_modify;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton simpleButton7;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.RadioButton radioButtonOnce;
        private DevExpress.XtraEditors.PanelControl panelOnce;
        private DevExpress.XtraEditors.TimeEdit timeEditOnce;
        private DevExpress.XtraEditors.TimeEdit timeEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TimeEdit timeEdit1;
        private DevExpress.XtraEditors.DateEdit dateEditOnce;
    }
}