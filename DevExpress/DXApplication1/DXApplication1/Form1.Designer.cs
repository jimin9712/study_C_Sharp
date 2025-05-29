namespace DXApplication1
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
            groupBox2 = new System.Windows.Forms.GroupBox();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Location = new System.Drawing.Point(12, 38);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(1552, 775);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "File Secure";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1589, 854);
            Controls.Add(groupBox2);
            Margin = new System.Windows.Forms.Padding(5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
    }
}

