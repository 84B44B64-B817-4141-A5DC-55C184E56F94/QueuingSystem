using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using MySql.Data.MySqlClient;
using System.Media;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace STI_Queuing_System
{
    public partial class frmMain : Form
    {
        string ip_address, user, address;
        bool QueueButtonisClicked, DisplayIsChanged, DBAccessible;
        int time_QueueButton = 0, time_CallButton = 0, display_blinker = 0, access_count = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            switch (btnQueue.Text)
            {
                case "Start Queue / Start Timer":
                    {
                        btnQueue.Text = "End Timer";
                        btnQueue.Enabled = false;
                        time_QueueButton = 0;
                        time_CallButton = 0;
                        lblDisplay.Text = "001";
                        DisplayIsChanged = true;
                        QueueButtonisClicked = true;
                        btnCall.Visible = true;
                        lblCall.Visible = true;
                        lblCallCount.Visible = true;
                        //SoundPlayer player = new SoundPlayer();
                        //player.SoundLocation = "beep.wav";
                        //player.Play();
                        break;
                    }
                case "End Timer":
                    {
                        btnQueue.Text = "Next Queue / Start Timer";
                        btnQueue.Enabled = false;
                        btnCall.Enabled = false;
                        lblCallCount.Text = "0";
                        time_QueueButton = DateTime.Now.Second;
                        QueueButtonisClicked = true;
                        break;
                    }
                case "Next Queue / Start Timer":
                    {
                        btnQueue.Text = "End Timer";
                        btnQueue.Enabled = false;
                        time_QueueButton = 0;
                        time_CallButton = 0;
                        QueueButtonisClicked = true;
                        //SoundPlayer player = new SoundPlayer();
                        //player.SoundLocation = "beep.wav";
                        //player.Play();
                        break;
                    }
            }
        }

        private void registerIPAddressesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegister register = new frmRegister();
            register.ShowDialog();
        }

        private void btnCall_Click(object sender, EventArgs e)
        {
            //SoundPlayer player = new System.Media.SoundPlayer();
            //player.SoundLocation = "beep.wav";
            //player.Play();
            btnCall.Enabled = false;
            DisplayIsChanged = true;
            time_CallButton = 0;
            lblCallCount.Text = (int.Parse(lblCallCount.Text) + 1).ToString();
        }


        private void timClock_Tick(object sender, EventArgs e)
        {
            MySqlConnection conn;
            string connectionString = "datasource= " + address + ";port=3306;username=root;password=mySQL09122016;";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                DBAccessible = true;
                conn.Close();
                access_count++;
            }
            catch (Exception ex)
            {
                DBAccessible = false;
                access_count++;
            }

            if (access_count <= 30)
            {
                lblStatus.Text = "";
                grbMain.Enabled = true;
            }
            if (access_count > 30 && access_count <=  90)
            {
                lblStatus.Text = "Warning: Losing Database Connection...";
                lblStatus.ForeColor = Color.Blue;
            }
            else if (access_count > 90)
            {
                lblStatus.Text = "Error: Database Connection Lost.";
                lblStatus.ForeColor = Color.Red;
                grbMain.Enabled = false;
                access_count = 100;
            }

            if (QueueButtonisClicked == true)
            {
                time_QueueButton++;
                if (time_QueueButton > 9)
                {
                    btnQueue.Enabled = true;
                    QueueButtonisClicked = false;
                    time_QueueButton = 0;
                }
            }
            if (btnCall.Visible == true)
            {
                if (btnCall.Enabled == false)
                {
                    time_CallButton++;
                    if (time_CallButton > 99)
                    {
                        btnCall.Enabled = true;
                        time_CallButton = 0;
                    }
                }
            }
            if (DisplayIsChanged == true)
            {
                display_blinker++;
                if (display_blinker >= 5 && display_blinker <= 9)
                {
                    lblDisplay.Visible = false;
                }
                else if (display_blinker >= 10 && display_blinker <= 14)
                {
                    lblDisplay.Visible = true;
                }
                else if (display_blinker >= 15 && display_blinker <= 19)
                {
                    lblDisplay.Visible = false;
                }
                else if (display_blinker > 19 && display_blinker <= 24)
                {
                    lblDisplay.Visible = true;
                }
                else if (display_blinker > 25 && display_blinker <= 29)
                {
                    lblDisplay.Visible = false;
                }
                else if (display_blinker > 29)
                {
                    lblDisplay.Visible = true;
                    DisplayIsChanged = false;
                    display_blinker = 0;
                }
            }
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            address = lblAddress.Text;
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
            getIPv4();
            MySqlDataReader ip_accounting = Program.Query("SELECT * FROM dbstiqueue.tbladdress where Accounting like '" + ip_address + "'");
            if (ip_accounting.Read() != true)
            {
                
                MySqlDataReader ip_cashier = Program.Query("SELECT * FROM dbstiqueue.tbladdress where Cashier like '" + ip_address + "'");
                if (ip_cashier.Read() != true)
                {
                    MySqlDataReader ip_regisrar = Program.Query("SELECT * FROM dbstiqueue.tbladdress where Registrar like '" + ip_address + "'");
                    if (ip_regisrar.Read() != true)
                    {
                        Text = "Queuing System: UNKNOWN";
                        MessageBox.Show("Unknown IP Address detected. Please reconfigure\nvia Maintenance>Register IP Addresses.", "System", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        btnQueue.Enabled = false;
                    }
                    else
                    {
                        Text = "Queuing System: REGISTRAR";
                        user = "Registrar";
                        registerIPAddressesToolStripMenuItem.Visible = false;
                    }
                    ip_regisrar.Close();
                }
                else
                {
                    Text = "Queuing System: CASHIER";
                    user = "Cashier";
                    registerIPAddressesToolStripMenuItem.Visible = false;
                }
                ip_cashier.Close();
            }
            else
            {
                Name = "Queuing System: ACCOUNTING";
                user = "Accounting";
                registerIPAddressesToolStripMenuItem.Visible = false;
            }
            ip_accounting.Close();
        }

        public void getIPv4()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ip_address = ip.ToString();
                }
            }
        }
    }
}
