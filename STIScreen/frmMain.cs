using System;
using System.Drawing;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace STI_Queuing_System
{
    public partial class frmMain : Form
    {
        string ip_address, user, address, transactLength, transactDate, transactTime;
        bool QueueButtonisClicked, DisplayIsChanged, DBAccessible;
        int time_QueueButton = 0, time_CallButton = 100, access_count = 0, arrayReference = 0, arrayCounter = 0, ticket_check = 0, nextCount = 0;
        double transactFraction;
        TimeSpan value_1, value_2, value_3, value_4, value_5, sum, average;

        private void menAbout_ctm_Click(object sender, EventArgs e)
        {
            aboutProgramToolStripMenuItem.PerformClick();
        }

        private void notMain_DoubleClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Activate();
        }

        private void displayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            Activate();
        }

        private void menExit_ctm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menCall_ctm_Click(object sender, EventArgs e)
        {
            btnCall.PerformClick();
        }

        private void menQueue_ctm_Click(object sender, EventArgs e)
        {
            btnQueue.PerformClick();
        }

        private void notMain_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctmNotify.Show(Cursor.Position);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }
            if (MessageBox.Show("Exit application?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        DateTime timer_start, timer_stop;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void aboutProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void auditTrailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f is frmAudit)
                {
                    f.Focus();
                    return;
                }
            }
            frmAudit audit = new frmAudit();
            audit.lblUser.Text = user;
            audit.Show();
        }

        private void btnQueue_Click(object sender, EventArgs e)
        {
            switch (btnQueue.Text)
            {
                case "Start Queue / Start Timer":
                    {
                        btnQueue.Text = "End Timer";
                        menQueue_ctm.Text = "End Timer";
                        btnQueue.Enabled = false;
                        menCall_ctm.Enabled = false;
                        time_QueueButton = 0;
                        time_CallButton = 100;
                        transactDate = DateTime.Now.ToString("yyyy-MM-dd");
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    ticket_check = Program.Count("SELECT COUNT(*) FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window like '" + "1" + "'");
                                    if (ticket_check > 0)
                                    {
                                        MySqlDataReader ticket_checker = Program.Query("SELECT * FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window LIKE '" + "1" + "' order by TicketNo LIMIT 0,1 ");
                                        while (ticket_checker.Read())
                                        {
                                            if (!ticket_checker.IsDBNull(0))
                                            {
                                                lblDisplay.Text = ticket_checker.GetString(1);
                                            }
                                        }
                                        ticket_checker.Close();
                                        switch (lblDisplay.Text.Length)
                                        {
                                            case 1:
                                                {
                                                    lblDisplay.Text = "00" + lblDisplay.Text;
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    lblDisplay.Text = "0" + lblDisplay.Text;
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        lblDisplay.Text = "001";
                                    }
                                    displayToolStripMenuItem.Text = "Currently Displayed: " + lblDisplay.Text;
                                    break;
                                }
                            case "Cashier":
                                {
                                    ticket_check = Program.Count("SELECT COUNT(*) FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window like '" + "3" + "'");
                                    if (ticket_check > 0)
                                    {
                                        MySqlDataReader ticket_checker = Program.Query("SELECT * FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window LIKE '" + "3" + "' order by TicketNo LIMIT 0,1 ");
                                        while (ticket_checker.Read())
                                        {
                                            if (!ticket_checker.IsDBNull(0))
                                            {
                                                lblDisplay.Text = ticket_checker.GetString(1);
                                            }
                                        }
                                        ticket_checker.Close();
                                        switch (lblDisplay.Text.Length)
                                        {
                                            case 1:
                                                {
                                                    lblDisplay.Text = "00" + lblDisplay.Text;
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    lblDisplay.Text = "0" + lblDisplay.Text;
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        lblDisplay.Text = "001";
                                    }
                                    displayToolStripMenuItem.Text = "Currently Displayed: " + lblDisplay.Text;
                                    break;
                                }
                            case "Registrar":
                                {
                                    ticket_check = Program.Count("SELECT COUNT(*) FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window like '" + "2" + "'");
                                    if (ticket_check > 0)
                                    {
                                        MySqlDataReader ticket_checker = Program.Query("SELECT * FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window LIKE '" + "2" + "' order by TicketNo LIMIT 0,1 ");
                                        while (ticket_checker.Read())
                                        {
                                            if (!ticket_checker.IsDBNull(0))
                                            {
                                                lblDisplay.Text = ticket_checker.GetString(1);
                                            }
                                        }
                                        ticket_checker.Close();
                                        switch (lblDisplay.Text.Length)
                                        {
                                            case 1:
                                                {
                                                    lblDisplay.Text = "00" + lblDisplay.Text;
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    lblDisplay.Text = "0" + lblDisplay.Text;
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                    {
                                        lblDisplay.Text = "001";
                                    }
                                    displayToolStripMenuItem.Text = "Currently Displayed: " + lblDisplay.Text;
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                        DisplayIsChanged = true;
                        QueueButtonisClicked = true;
                        btnCall.Visible = true;
                        lblCall.Visible = true;
                        lblCallCount.Visible = true;
                        timer_start = DateTime.Now;
                        transactDate = DateTime.Now.ToString("yyyy-MM-dd");
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',Serving='" + "1" + "',Calling='" + "1" + "',transactDate='" + transactDate + "' WHERE Window='" + "1" + "'").Close();
                                    break;
                                }
                            case "Cashier":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',Serving='" + "1" + "',Calling='" + "1" + "',transactDate='" + transactDate + "' WHERE Window='" + "3" + "'").Close();
                                    break;
                                }
                            case "Registrar":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',Serving='" + "1" + "',Calling='" + "1" + "',transactDate='" + transactDate + "' WHERE Window='" + "2" + "'").Close();
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                        break;
                    }
                case "End Timer":
                    {
                        timer_stop = DateTime.Now;
                        btnQueue.Text = "Next Queue / Start Timer";
                        menQueue_ctm.Text = "Next Queue / Start Timer";
                        btnQueue.Enabled = false;
                        btnCall.Enabled = false;
                        menCall_ctm.Enabled = false;
                        lblCallCount.Text = "0";
                        time_QueueButton = DateTime.Now.Second;
                        QueueButtonisClicked = true;
                        transactLength = (timer_stop - timer_start).ToString(@"hh\:mm\:ss\.ff");
                        transactFraction = double.Parse(transactLength.Substring(transactLength.LastIndexOf('.')));
                        transactDate = DateTime.Now.ToString("yyyy-MM-dd");
                        transactTime = timer_start.ToString("HH:mm:ss");
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblaudit (Window,TicketNo,TransactLength,TransactFraction,TransactDate,TransactTime) VALUE ('" + "1" + "','" + lblDisplay.Text + "','" + transactLength + "','" + transactFraction + "', '" + transactDate + "','" + transactTime + "')").Close();
                                    break;
                                }
                            case "Cashier":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblaudit (Window,TicketNo,TransactLength,TransactFraction,TransactDate,TransactTime) VALUE ('" + "3" + "','" + lblDisplay.Text + "','" + transactLength + "', '" + transactFraction + "', '" + transactDate + "','" + transactTime + "')").Close();
                                    break;
                                }
                            case "Registrar":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblaudit (Window,TicketNo,TransactLength,TransactFraction,TransactDate,TransactTime) VALUE ('" + "2" + "','" + lblDisplay.Text + "','" + transactLength + "', '" + transactFraction + "', '" + transactDate + "','" + transactTime + "')").Close();
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                        getAverage();
                        sum = TimeSpan.Parse("00:00:00.00");
                        average = TimeSpan.Parse("00:00:00.00");
                        sum = value_1 + value_2 + value_3 + value_4 + value_5;
                        average = new TimeSpan(sum.Ticks / 5);
                        lblTransactTime.Text = average.ToString(@"hh\:mm\:ss\.ff");
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen set Computed = '" + "1" + "', Average = '" + lblTransactTime.Text + "' where Window = '" + "1" + "'").Close();
                                    break;
                                }
                            case "Cashier":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen set Computed = '" + "1" + "', Average = '" + lblTransactTime.Text + "' where Window = '" + "3" + "'").Close();
                                    break;
                                }
                            case "Registrar":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen set Computed = '" + "1" + "', Average = '" + lblTransactTime.Text + "' where Window = '" + "2" + "'").Close();
                                    break;
                                }
                        }
                        break;
                    }
                case "Next Queue / Start Timer":
                    {
                        btnQueue.Text = "End Timer";
                        menQueue_ctm.Text = "End Timer";
                        btnQueue.Enabled = false;
                        menCall_ctm.Enabled = false;
                        time_QueueButton = 0;
                        time_CallButton = 100;
                        QueueButtonisClicked = true;
                        timer_start = DateTime.Now;
                        nextCount = int.Parse(lblDisplay.Text) + 1;
                        lblDisplay.Text = nextCount.ToString();
                        switch (lblDisplay.Text.Length)
                        {
                            case 1:
                                {
                                    lblDisplay.Text = "00" + lblDisplay.Text;
                                    break;
                                }
                            case 2:
                                {
                                    lblDisplay.Text = "0" + lblDisplay.Text;
                                    break;
                                }
                        }
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + nextCount + "',Serving='" + "1" + "',Calling='" + "1" + "' WHERE Window='" + "1" + "'").Close();
                                    break;
                                }
                            case "Cashier":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + nextCount + "',Serving='" + "1" + "',Calling='" + "1" + "' WHERE Window='" + "3" + "'").Close();
                                    break;
                                }
                            case "Registrar":
                                {
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + nextCount + "',Serving='" + "1" + "',Calling='" + "1" + "' WHERE Window='" + "2" + "'").Close();
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                        displayToolStripMenuItem.Text = "Currently Displayed: " + lblDisplay.Text;
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
            btnCall.Enabled = false;
            menCall_ctm.Enabled = false;
            DisplayIsChanged = true;
            time_CallButton = 100;
            lblCallCount.Text = (int.Parse(lblCallCount.Text) + 1).ToString();
            switch (user)
            {
                case "Accounting":
                    {
                        Program.Query("Update dbstiqueue.tblscreen set Calling = '" + "1" + "' where Window = '" + "1" + "'").Close();
                        break;
                    }
                case "Cashier":
                    {
                        Program.Query("Update dbstiqueue.tblscreen set Calling = '" + "1" + "' where Window = '" + "3" + "'").Close();
                        break;
                    }
                case "Registrar":
                    {
                        Program.Query("Update dbstiqueue.tblscreen set Calling = '" + "1" + "' where Window = '" + "2" + "'").Close();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }


        private void timClock_Tick(object sender, EventArgs e)
        {
            //Change password for Testing
            MySqlConnection conn;
            string connectionString = "datasource= " + address + ";port=3306;username=root;password=mySQL09122016;";
            conn = new MySqlConnection(connectionString);
            try
            {
                conn.Open();
                DBAccessible = true;
                conn.Close();
                access_count = 0;
            }
            catch (Exception ex)
            {
                DBAccessible = false;
                access_count++;
            }

            if (access_count <= 30)
            {
                if (lblStatus.Text != "Unknown IP Address detected.")
                {
                    lblStatus.Text = "";
                    grbMain.Enabled = true;
                }
            }
            if (access_count > 30 && access_count <= 90)
            {
                if (lblStatus.Text != "Unknown IP Address detected.")
                {
                    lblStatus.Text = "Warning: Losing Database Connection...";
                    notMain.BalloonTipText = "Warning: Losing Database Connection..";
                    notMain.ShowBalloonTip(60000);
                    lblStatus.ForeColor = Color.Blue;
                }
            }
            else if (access_count > 90)
            {
                if (lblStatus.Text != "Unknown IP Address detected.")
                {
                    lblStatus.Text = "Error: Database Connection Lost.";
                    notMain.BalloonTipText = "Error: Database Connection Lost.";
                    notMain.ShowBalloonTip(60000);
                    lblStatus.ForeColor = Color.Red;
                    grbMain.Enabled = false;
                    access_count = 100;
                }
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
                if (btnCall.Enabled == false && btnQueue.Text == "End Timer")
                {
                    time_CallButton--;
                    if (time_CallButton < 1)
                    {
                        btnCall.Enabled = true;
                        menCall_ctm.Enabled = true;
                        time_CallButton = 100;
                    }
                    if (time_CallButton < 100)
                    {
                        btnCall.Text = "Call Again" + "(" + (time_CallButton / 10) + ")";
                        menCall_ctm.Text = "Call Again" + "(" + (time_CallButton / 10) + ")";
                    }
                    else
                    {
                        btnCall.Text = "Call Again";
                        menCall_ctm.Text = "Call Again";
                    }
                }
            }
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            address = lblAddress.Text;
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
            getIPv4();
            MySqlDataReader ip_accounting = Program.Query("SELECT * FROM dbstiqueue.tbladdress where Accounting LIKE '" + ip_address + "'");
            if (ip_accounting.Read() != true)
            {
                MySqlDataReader ip_cashier = Program.Query("SELECT * FROM dbstiqueue.tbladdress where Cashier LIKE '" + ip_address + "'");
                if (ip_cashier.Read() != true)
                {
                    MySqlDataReader ip_regisrar = Program.Query("SELECT * FROM dbstiqueue.tbladdress where Registrar LIKE '" + ip_address + "'");
                    if (ip_regisrar.Read() != true)
                    {
                        Text = "Queuing System: UNKNOWN";
                        user = "Unknown";
                        lblStatus.Text = "Unknown IP Address detected.";
                        lblStatus.ForeColor = Color.Red;
                        btnQueue.Enabled = false;
                        notMain.BalloonTipText = "Unknown IP Address detected.";
                        notMain.ShowBalloonTip(60000);
                    }
                    else
                    {
                        Text = "Queuing System: REGISTRAR";
                        user = "Registrar";
                        registerIPAddressesToolStripMenuItem.Visible = false;
                        notMain.BalloonTipText = "Queuing System for REGISTRAR is now ready.";
                        notMain.ShowBalloonTip(60000);
                    }
                    ip_regisrar.Close();
                }
                else
                {
                    Text = "Queuing System: CASHIER";
                    user = "Cashier";
                    registerIPAddressesToolStripMenuItem.Visible = false;
                    notMain.BalloonTipText = "Queuing System for CASHIER is now ready.";
                    notMain.ShowBalloonTip(60000);
                }
                ip_cashier.Close();
            }
            else
            {
                Text = "Queuing System: ACCOUNTING";
                user = "Accounting";
                registerIPAddressesToolStripMenuItem.Visible = false;
                notMain.BalloonTipText = "Queuing System for ACCOUNTING is now ready.";
                notMain.ShowBalloonTip(60000);
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
            return;
        }

        public void getAverage()
        {
            value_1 = TimeSpan.Parse("00:00:00.00");
            value_2 = TimeSpan.Parse("00:00:00.00");
            value_3 = TimeSpan.Parse("00:00:00.00");
            value_4 = TimeSpan.Parse("00:00:00.00");
            value_5 = TimeSpan.Parse("00:00:00.00");
            transactDate = DateTime.Now.ToString("yyyy-MM-dd");
            arrayCounter = 0;
            switch (user)
            {
                case "Accounting":
                    {
                        arrayReference = Program.Count("SELECT COUNT(*) from dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "1" + "'");
                        if (arrayReference < 1)
                        {
                            return;
                        }
                        else
                        {
                            if (arrayReference > 5)
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "1" + "' order by TransactTime DESC LIMIT 0,5");
                                while (fetchTime.Read())
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayCounter)
                                        {
                                            case 0:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_5 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_5 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    arrayCounter++;
                                }
                                fetchTime.Close();
                            }
                            else
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window like '" + "1" + "' order by TransactTime");
                                while (fetchTime.Read() || arrayCounter < arrayReference)
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayReference)
                                        {
                                            case 1:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    value_2 = TimeSpan.Parse("00:00:00.00");
                                                    value_3 = TimeSpan.Parse("00:00:00.00");
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_3 = TimeSpan.Parse("00:00:00.00");
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    arrayCounter++;
                                }
                                fetchTime.Close();
                            }
                        }
                        break;
                    }
                case "Cashier":
                    {
                        arrayReference = Program.Count("SELECT COUNT(*) from dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "3" + "'");
                        if (arrayReference < 1)
                        {
                            return;
                        }
                        else
                        {
                            if (arrayReference > 5)
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "3" + "' order by TransactTime DESC LIMIT 0,5");
                                while (fetchTime.Read())
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayCounter)
                                        {
                                            case 0:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_5 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_5 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    arrayCounter++;
                                }
                                fetchTime.Close();
                            }
                            else
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window like '" + "3" + "' order by TransactTime");
                                while (fetchTime.Read() || arrayCounter < arrayReference)
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayReference)
                                        {
                                            case 1:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    value_2 = TimeSpan.Parse("00:00:00.00");
                                                    value_3 = TimeSpan.Parse("00:00:00.00");
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_3 = TimeSpan.Parse("00:00:00.00");
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    arrayCounter++;
                                }
                                fetchTime.Close();
                            }
                        }
                        break;
                    }
                case "Registrar":
                    {
                        arrayReference = Program.Count("SELECT COUNT(*) from dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "2" + "'");
                        if (arrayReference < 1)
                        {
                            return;
                        }
                        else
                        {
                            if (arrayReference > 5)
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "2" + "' order by TransactTime DESC LIMIT 0,5");
                                while (fetchTime.Read())
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayCounter)
                                        {
                                            case 0:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_5 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_5 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    arrayCounter++;
                                }
                                fetchTime.Close();
                            }
                            else
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window like '" + "2" + "' order by TransactTime");
                                while (fetchTime.Read() || arrayCounter < arrayReference)
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayReference)
                                        {
                                            case 1:
                                                {
                                                    if (fetchTime.GetString(3) == "0")
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                    }
                                                    else
                                                    {
                                                        value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                    }
                                                    value_2 = TimeSpan.Parse("00:00:00.00");
                                                    value_3 = TimeSpan.Parse("00:00:00.00");
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_3 = TimeSpan.Parse("00:00:00.00");
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_4 = TimeSpan.Parse("00:00:00.00");
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    value_5 = TimeSpan.Parse("00:00:00.00");
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                if (fetchTime.GetString(3) == "0")
                                                                {
                                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2) + ".00");
                                                                }
                                                                else
                                                                {
                                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2) + fetchTime.GetString(3).Substring(fetchTime.GetString(3).LastIndexOf('.')));
                                                                }
                                                                break;
                                                            }
                                                    }
                                                    break;
                                                }
                                        }
                                    }
                                    arrayCounter++;
                                }
                                fetchTime.Close();
                            }
                        }
                        break;
                    }
                default:
                    {
                        MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }
    }
}


