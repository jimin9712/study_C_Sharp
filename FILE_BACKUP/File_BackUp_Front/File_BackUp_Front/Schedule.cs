using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace File_BackUp_Front
{
    public partial class Schedule : DevExpress.XtraEditors.XtraForm
    {
        public Schedule()
        {
            InitializeComponent();
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            panelDaily.Visible = radioButtonDaily.Checked;
            panelWeek.Visible = radioButtonWeek.Checked;
            panelMonth.Visible = radioButtonMonth.Checked;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
           this.Close();
        }
    }
}