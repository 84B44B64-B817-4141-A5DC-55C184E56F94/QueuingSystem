using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections;

namespace STI_Queuing_System
{
    public partial class frmDisplay : Form
    {
        //Change password to connect to your SQL
        MySqlConnection con = new MySqlConnection("datasource=localhost;port=3306;username=root;password='mySQL09122016'");
        /// <summary>
        /// PUBLIC VARIABLES:
        int WindowNo, count;
        string TicketNo;
        /// </summary>
        public frmDisplay()
        {
            InitializeComponent();
            getFromDb();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //lblCashier1.Visible = true;
            //lblCashier1.Text = "0001";
        }
        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
        }
        void getFromDb()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from dbstiqueue.tblscreen where Served = 0 limit 10 ", con);
            MySqlDataReader reader;
            con.Open();

            reader = cmd.ExecuteReader();
            count = 0;
            while (reader.Read())
            {
                count = count + 1;
                TicketNo = reader.GetString(0);
                WindowNo = reader.GetInt32(1);
                if (WindowNo == 1)
                {
                    Window1();
                }
                else if (WindowNo == 2)
                {
                    Window2();
                }
                else if (WindowNo == 3)
                {
                    Window3();
                }
            }
            con.Close();
        }
        void Window1()
        {
            lblReg.Visible = true;
            lblReg.Text = TicketNo;
        }
        void Window2()
        {
            lblReg.Visible = true;
            lblAcc.Text = TicketNo;
        }
        void Window3()
        {
            lblCash.Visible = true;
            lblCash.Text = TicketNo;
        }


        private void timerNews_Tick(object sender, EventArgs e)
        {
            if (lblNews.Left == (0 - lblNews.Width))
            {
                lblNews.Location = new Point(1360, 569);
            }
            else
            {
                lblNews.Left = lblNews.Left - 5;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
