using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STI_Queuing_System
{
    public partial class frmMini : Form
    {
        frmMain main;

        public frmMini()
        {
            InitializeComponent();
        }

        public frmMini(frmMain viaParameter) : this()
        {
            main = viaParameter;
        }

        private void frmMini_Load(object sender, EventArgs e)
        {
            ToolTip mini = new ToolTip();
            mini.SetToolTip(btnMain, "Return to Main View Mode");
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMini_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Show();
            Hide();
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            main.btnQueue.PerformClick();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            main.btnCall.PerformClick();
        }
    }
}
