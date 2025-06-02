namespace File_BackUp_Front
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            marqueeProgressBarControl1 = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(components);
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            imageSlider2 = new DevExpress.XtraEditors.Controls.ImageSlider();
            imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            groupBox1 = new System.Windows.Forms.GroupBox();
            accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)marqueeProgressBarControl1.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageSlider2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)imageSlider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).BeginInit();
            SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            fluentDesignFormContainer1.Controls.Add(simpleButton1);
            fluentDesignFormContainer1.Controls.Add(groupControl1);
            fluentDesignFormContainer1.Controls.Add(marqueeProgressBarControl1);
            fluentDesignFormContainer1.Controls.Add(imageSlider2);
            fluentDesignFormContainer1.Controls.Add(imageSlider1);
            fluentDesignFormContainer1.Controls.Add(groupBox1);
            fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            fluentDesignFormContainer1.Location = new System.Drawing.Point(310, 46);
            fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            fluentDesignFormContainer1.Size = new System.Drawing.Size(1362, 765);
            fluentDesignFormContainer1.TabIndex = 0;
            fluentDesignFormContainer1.Click += fluentDesignFormContainer1_Click;
            // 
            // simpleButton1
            // 
            simpleButton1.Appearance.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            simpleButton1.Appearance.Options.UseForeColor = true;
            simpleButton1.Location = new System.Drawing.Point(1190, 695);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(141, 48);
            simpleButton1.TabIndex = 6;
            simpleButton1.Text = "Back up now";
            simpleButton1.Click += simpleButton1_Click;
            // 
            // groupControl1
            // 
            groupControl1.Location = new System.Drawing.Point(6, 373);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(1325, 307);
            groupControl1.TabIndex = 5;
            groupControl1.Text = "Task details";
            // 
            // marqueeProgressBarControl1
            // 
            marqueeProgressBarControl1.EditValue = 0;
            marqueeProgressBarControl1.Location = new System.Drawing.Point(299, 228);
            marqueeProgressBarControl1.MenuManager = fluentFormDefaultManager1;
            marqueeProgressBarControl1.Name = "marqueeProgressBarControl1";
            marqueeProgressBarControl1.Size = new System.Drawing.Size(701, 40);
            marqueeProgressBarControl1.TabIndex = 3;
            // 
            // fluentFormDefaultManager1
            // 
            fluentFormDefaultManager1.Form = this;
            fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1 });
            fluentFormDefaultManager1.MaxItemId = 2;
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "barButtonItem1";
            barButtonItem1.Id = 0;
            barButtonItem1.Name = "barButtonItem1";
            // 
            // imageSlider2
            // 
            imageSlider2.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 240, 241);
            imageSlider2.Appearance.Options.UseBackColor = true;
            imageSlider2.Location = new System.Drawing.Point(1046, 126);
            imageSlider2.Name = "imageSlider2";
            imageSlider2.Size = new System.Drawing.Size(192, 165);
            imageSlider2.TabIndex = 2;
            imageSlider2.Text = "파일 ";
            // 
            // imageSlider1
            // 
            imageSlider1.Appearance.BackColor = System.Drawing.Color.FromArgb(240, 240, 241);
            imageSlider1.Appearance.Options.UseBackColor = true;
            imageSlider1.Location = new System.Drawing.Point(49, 126);
            imageSlider1.Name = "imageSlider1";
            imageSlider1.Size = new System.Drawing.Size(192, 165);
            imageSlider1.TabIndex = 1;
            imageSlider1.Text = "파일";
            imageSlider1.Click += imageSlider1_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new System.Drawing.Point(6, 34);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(1325, 333);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Backup";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // accordionControl1
            // 
            accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] { accordionControlElement1 });
            accordionControl1.Location = new System.Drawing.Point(0, 46);
            accordionControl1.Name = "accordionControl1";
            accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            accordionControl1.Size = new System.Drawing.Size(310, 765);
            accordionControl1.TabIndex = 1;
            accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // accordionControlElement1
            // 
            accordionControlElement1.Expanded = true;
            accordionControlElement1.Name = "accordionControlElement1";
            accordionControlElement1.Text = "New Backups";
            // 
            // fluentDesignFormControl1
            // 
            fluentDesignFormControl1.FluentDesignForm = this;
            fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1 });
            fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            fluentDesignFormControl1.Manager = fluentFormDefaultManager1;
            fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            fluentDesignFormControl1.Size = new System.Drawing.Size(1672, 46);
            fluentDesignFormControl1.TabIndex = 2;
            fluentDesignFormControl1.TabStop = false;
            fluentDesignFormControl1.Text = "File_Backup";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1672, 811);
            ControlContainer = fluentDesignFormContainer1;
            Controls.Add(fluentDesignFormContainer1);
            Controls.Add(accordionControl1);
            Controls.Add(fluentDesignFormControl1);
            FluentDesignFormControl = fluentDesignFormControl1;
            Name = "Form1";
            NavigationControl = accordionControl1;
            Text = "Form1";
            fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)marqueeProgressBarControl1.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentFormDefaultManager1).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageSlider2).EndInit();
            ((System.ComponentModel.ISupportInitialize)imageSlider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)accordionControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fluentDesignFormControl1).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MarqueeProgressBarControl marqueeProgressBarControl1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

