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
        bool DBAccessible;
        public bool setIP, QueueButtonisClicked, changeView;
        int access_count = 0, arrayReference = 0, arrayCounter = 0, ticket_check = 0, nextCount = 0;
        public int time_QueueButton = 0, time_CallButton = 100, current_count;
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

        private void switchToCompactModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           //READ ALL DATAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA
            frmMini mini = new frmMini(this);
            Screen screen = Screen.AllScreens[0];
            mini.Left = screen.WorkingArea.Right - mini.Width;
            mini.Top = screen.WorkingArea.Top;
            mini.TopMost = true;
            mini.Show();
            Hide();
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
            if (changeView != true && setIP != true)
            {
                if (MessageBox.Show("Exit application?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
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
            if (changeView != true)
            {

            }
            Dispose();
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
                        menQueue_ctm.Enabled = false;
                        menCall_ctm.Enabled = false;
                        time_QueueButton = 0;
                        time_CallButton = 100;
                        transactDate = DateTime.Now.ToString("yyyy-MM-dd");
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    ticket_check = Program.Count("SELECT COUNT(*) FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window like '" + "Accounting" + "'");
                                    if (ticket_check > 0)
                                    {
                                        MySqlDataReader ticket_checker = Program.Query("SELECT * FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window LIKE '" + "Accounting" + "' order by TicketNo LIMIT 0,1 ");
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
                                    ticket_check = Program.Count("SELECT COUNT(*) FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window like '" + "Cashier" + "'");
                                    if (ticket_check > 0)
                                    {
                                        MySqlDataReader ticket_checker = Program.Query("SELECT * FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window LIKE '" + "Cashier" + "' order by TicketNo LIMIT 0,1 ");
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
                                    ticket_check = Program.Count("SELECT COUNT(*) FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window like '" + "Registrar" + "'");
                                    if (ticket_check > 0)
                                    {
                                        MySqlDataReader ticket_checker = Program.Query("SELECT * FROM dbstiqueue.tblscreen WHERE TransactDate like '" + transactDate + "' and Window LIKE '" + "Registrar" + "' order by TicketNo LIMIT 0,1 ");
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
                       // DisplayIsChanged = true;
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
                                    Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Accounting" + "','" + lblDisplay.Text + "','" + "Serve" + "','" + transactDate + "')").Close();
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',transactDate='" + transactDate + "' WHERE Window='" + "Accounting" + "'").Close();
                                    break;
                                }
                            case "Cashier":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Cashier" + "','" + lblDisplay.Text + "','" + "Serve" + "','" + transactDate + "')").Close();
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',transactDate='" + transactDate + "' WHERE Window='" + "Cashier" + "'").Close();
                                    break;
                                }
                            case "Registrar":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Registrar" + "','" + lblDisplay.Text + "','" + "Serve" + "','" + transactDate + "')").Close();
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',transactDate='" + transactDate + "' WHERE Window='" + "Registrar" + "'").Close();
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
                        menQueue_ctm.Enabled = false;
                        btnCall.Enabled = false;
                        menCall_ctm.Enabled = false;
                        lblCallCount.Text = "0";
                        btnCall.Text = "Call Again";
                        time_QueueButton = DateTime.Now.Second;
                        QueueButtonisClicked = true;
                        transactLength = (timer_stop - timer_start).ToString(@"hh\:mm\:ss");
                        transactDate = DateTime.Now.ToString("yyyy-MM-dd");
                        transactTime = timer_start.ToString("hh:mm:ss");
                        Program.Query("DELETE FROM dbstiqueue.tblaudit WHERE TicketNo='" + lblDisplay.Text + "' AND Window='" + user + "' AND TransactDate='" + transactDate + "'").Close();
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblaudit (Window,TicketNo,TransactLength,TransactDate,TransactTime) VALUE ('" + "Accounting" + "','" + lblDisplay.Text + "','" + transactLength + "', '" + transactDate + "','" + transactTime + "')").Close();
                                    break;
                                }
                            case "Cashier":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblaudit (Window,TicketNo,TransactLength,TransactDate,TransactTime) VALUE ('" + "Cashier" + "','" + lblDisplay.Text + "','" + transactLength + "', '" + transactDate + "','" + transactTime + "')").Close();
                                    break;
                                }
                            case "Registrar":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblaudit (Window,TicketNo,TransactLength,TransactDate,TransactTime) VALUE ('" + "Registrar" + "','" + lblDisplay.Text + "','" + transactLength + "', '" + transactDate + "','" + transactTime + "')").Close();
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                        getAverage();
                        sum = TimeSpan.Parse("00:00:00");
                        average = TimeSpan.Parse("00:00:00");
                        sum = value_1 + value_2 + value_3 + value_4 + value_5;
                        average = new TimeSpan(sum.Ticks / 5);
                        lblTransactTime.Text = average.ToString(@"hh\:mm\:ss");
                        break;
                    }
                case "Next Queue / Start Timer":
                    {
                        btnQueue.Text = "End Timer";
                        menQueue_ctm.Text = "End Timer";
                        btnQueue.Enabled = false;
                        menQueue_ctm.Enabled = false;
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
                                    Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Accounting" + "','" + lblDisplay.Text + "','" + "Serve" + "','" + transactDate + "')").Close();
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',transactDate='" + transactDate + "' WHERE Window='" + "Accounting" + "'").Close();
                                    break;
                                }
                            case "Cashier":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Cashier" + "','" + lblDisplay.Text + "','" + "Serve" + "','" + transactDate + "')").Close();
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',transactDate='" + transactDate + "' WHERE Window='" + "Cashier" + "'").Close();
                                    break;
                                }
                            case "Registrar":
                                {
                                    Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Registrar" + "','" + lblDisplay.Text + "','" + "Serve" + "','" + transactDate + "')").Close();
                                    Program.Query("UPDATE dbstiqueue.tblscreen SET TicketNo='" + lblDisplay.Text + "',transactDate='" + transactDate + "' WHERE Window='" + "Registrar" + "'").Close();
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

        private void btnCall_Click(object sender, EventArgs e)
        {
            btnCall.Enabled = false;
            menCall_ctm.Enabled = false;
            //DisplayIsChanged = true;
            time_CallButton = 100;
            lblCallCount.Text = (int.Parse(lblCallCount.Text) + 1).ToString();
            transactDate = DateTime.Now.ToString("yyyy-MM-dd");
            switch (user)
            {
                case "Accounting":
                    {
                        Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Accounting" + "','" + lblDisplay.Text + "','" + "Call" + "','" + transactDate +"')").Close();
                        break;
                    }
                case "Cashier":
                    {
                        Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Cashier" + "','" + lblDisplay.Text + "','" + "Call" + "','" + transactDate + "')").Close();
                        break;
                    }
                case "Registrar":
                    {
                        Program.Query("INSERT INTO dbstiqueue.tblqueue (Window,TicketNo,Action,TransactDate) VALUE ('" + "Registrar" + "','" + lblDisplay.Text + "','" + "Call" + "','" +transactDate + "')").Close();
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
                if (time_QueueButton > 39)
                {
                    btnQueue.Enabled = true;
                    menQueue_ctm.Enabled = true;
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
            user = lbl_user.Text;
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
            switch (user)
            {
                case "Accounting":
                    {
                        Text = "Queuing System: ACCOUNTING";
                        user = "Accounting";
                        notMain.BalloonTipText = "Queuing System for ACCOUNTING is now ready.";
                        notMain.ShowBalloonTip(60000);
                        break;
                    }
                case "Registrar":
                    {
                        Text = "Queuing System: REGISTRAR";
                        user = "Registrar";
                        notMain.BalloonTipText = "Queuing System for REGISTRAR is now ready.";
                        notMain.ShowBalloonTip(60000);
                        break;
                    }
                case "Cashier":
                    {
                        Text = "Queuing System: CASHIER";
                        user = "Cashier";
                        notMain.BalloonTipText = "Queuing System for CASHIER is now ready.";
                        notMain.ShowBalloonTip(60000);
                        break;
                    }
            }
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
            value_1 = TimeSpan.Parse("00:00:00");
            value_2 = TimeSpan.Parse("00:00:00");
            value_3 = TimeSpan.Parse("00:00:00");
            value_4 = TimeSpan.Parse("00:00:00");
            value_5 = TimeSpan.Parse("00:00:00");
            transactDate = DateTime.Now.ToString("yyyy-MM-dd");
            arrayCounter = 0;
            switch (user)
            {
                case "Accounting":
                    {
                        arrayReference = Program.Count("SELECT COUNT(*) from dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "Accounting" + "'");
                        if (arrayReference < 1)
                        {
                            return;
                        }
                        else
                        {
                            if (arrayReference > 5)
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "Accounting" + "' order by TransactTime DESC LIMIT 0,5");
                                while (fetchTime.Read())
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayCounter)
                                        {
                                            case 0:
                                                {
                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2));
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
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window like '" + "Accounting" + "' order by TransactTime");
                                while (fetchTime.Read() || arrayCounter < arrayReference)
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayReference)
                                        {
                                            case 1:
                                                {
                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    value_2 = TimeSpan.Parse("00:00:00");
                                                    value_3 = TimeSpan.Parse("00:00:00");
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_3 = TimeSpan.Parse("00:00:00");
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                value_5 = TimeSpan.Parse(fetchTime.GetString(2));
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
                        arrayReference = Program.Count("SELECT COUNT(*) from dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "Cashier" + "'");
                        if (arrayReference < 1)
                        {
                            return;
                        }
                        else
                        {
                            if (arrayReference > 5)
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "Cashier" + "' order by TransactTime DESC LIMIT 0,5");
                                while (fetchTime.Read())
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayCounter)
                                        {
                                            case 0:
                                                {
                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2));
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
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window like '" + "Cashier" + "' order by TransactTime");
                                while (fetchTime.Read() || arrayCounter < arrayReference)
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayReference)
                                        {
                                            case 1:
                                                {
                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    value_2 = TimeSpan.Parse("00:00:00");
                                                    value_3 = TimeSpan.Parse("00:00:00");
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_3 = TimeSpan.Parse("00:00:00");
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                value_5 = TimeSpan.Parse(fetchTime.GetString(2));
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
                        arrayReference = Program.Count("SELECT COUNT(*) from dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "Registrar" + "'");
                        if (arrayReference < 1)
                        {
                            return;
                        }
                        else
                        {
                            if (arrayReference > 5)
                            {
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window LIKE '" + "Registrar" + "' order by TransactTime DESC LIMIT 0,5");
                                while (fetchTime.Read())
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayCounter)
                                        {
                                            case 0:
                                                {
                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 1:
                                                {
                                                    value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    value_5 = TimeSpan.Parse(fetchTime.GetString(2));
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
                                MySqlDataReader fetchTime = Program.Query("SELECT * FROM dbstiqueue.tblaudit WHERE TransactDate LIKE '" + transactDate + "' and Window like '" + "Registrar" + "' order by TransactTime");
                                while (fetchTime.Read() || arrayCounter < arrayReference)
                                {
                                    if (!fetchTime.IsDBNull(0))
                                    {
                                        switch (arrayReference)
                                        {
                                            case 1:
                                                {
                                                    value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                    value_2 = TimeSpan.Parse("00:00:00");
                                                    value_3 = TimeSpan.Parse("00:00:00");
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 2:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_3 = TimeSpan.Parse("00:00:00");
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 3:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_4 = TimeSpan.Parse("00:00:00");
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 4:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                    }
                                                    value_5 = TimeSpan.Parse("00:00:00");
                                                    break;
                                                }
                                            case 5:
                                                {
                                                    switch (arrayCounter)
                                                    {
                                                        case 0:
                                                            {
                                                                value_1 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 1:
                                                            {
                                                                value_2 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 2:
                                                            {
                                                                value_3 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 3:
                                                            {
                                                                value_4 = TimeSpan.Parse(fetchTime.GetString(2));
                                                                break;
                                                            }
                                                        case 4:
                                                            {
                                                                value_5 = TimeSpan.Parse(fetchTime.GetString(2));
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


