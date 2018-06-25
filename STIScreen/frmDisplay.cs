using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;
using System.Threading;

namespace STI_Queuing_System
{
    public partial class frmDisplay : Form
    {
        //Change password to connect to your SQL
        int blinker = 0;
        int hundredths, tenths;
        int num;
        SoundPlayer tone = new SoundPlayer();
        Thread forServe, forCall;
        string transactDate;
        string display, user, action;
        bool isUpdating, isBlinking;
        bool isHundred, isTwenty;

        public frmDisplay()
        {
            InitializeComponent();
        }

        private void timerBlink_Tick(object sender, EventArgs e)
        {
            if (isBlinking == true)
            {
                blinker++;
                if (blinker >= 5 && blinker <= 9)
                {
                    switch (user)
                    {
                        case "Accounting":
                            {
                                lblAccounting.Visible = false;
                                break;
                            }
                        case "Cashier":
                            {
                                lblCashier.Visible = false;
                                break;
                            }
                        case "Registrar":
                            {
                                lblRegistrar.Visible = false;
                                break;
                            }
                    }
                }
                else if (blinker >= 10 && blinker <= 14)
                {
                    switch (user)
                    {
                        case "Accounting":
                            {
                                lblAccounting.Visible = true;
                                break;
                            }
                        case "Cashier":
                            {
                                lblCashier.Visible = true;
                                break;
                            }
                        case "Registrar":
                            {
                                lblRegistrar.Visible = true;
                                break;
                            }
                    }
                }
                else if (blinker >= 15 && blinker <= 19)
                {
                    switch (user)
                    {
                        case "Accounting":
                            {
                                lblAccounting.Visible = false;
                                break;
                            }
                        case "Cashier":
                            {
                                lblCashier.Visible = false;
                                break;
                            }
                        case "Registrar":
                            {
                                lblRegistrar.Visible = false;
                                break;
                            }
                    }
                }
                else if (blinker > 19 && blinker <= 24)
                {
                    switch (user)
                    {
                        case "Accounting":
                            {
                                lblAccounting.Visible = true;
                                break;
                            }
                        case "Cashier":
                            {
                                lblCashier.Visible = true;
                                break;
                            }
                        case "Registrar":
                            {
                                lblRegistrar.Visible = true;
                                break;
                            }
                    }
                }
                else if (blinker > 25 && blinker <= 29)
                {
                    switch (user)
                    {
                        case "Accounting":
                            {
                                lblAccounting.Visible = false;
                                break;
                            }
                        case "Cashier":
                            {
                                lblCashier.Visible = false;
                                break;
                            }
                        case "Registrar":
                            {
                                lblRegistrar.Visible = false;
                                break;
                            }
                    }
                }
                else if (blinker > 29)
                {
                    switch (user)
                    {
                        case "Accounting":
                            {
                                lblAccounting.Visible = true;
                                break;
                            }
                        case "Cashier":
                            {
                                lblCashier.Visible = true;
                                break;
                            }
                        case "Registrar":
                            {
                                lblRegistrar.Visible = true;
                                break;
                            }
                    }
                    blinker = 0;
                    isBlinking = false;
                }
            }
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            transactDate = DateTime.Now.ToString("yyyy-MM-dd");

            if (isUpdating == false)
            {
                isUpdating = true;

                if (Program.Count("SELECT COUNT(*) FROM dbstiqueue.tblqueue WHERE TransactDate='" + transactDate + "'") > 0)
                {
                    MySqlDataReader queue_reader = Program.Query("SELECT * FROM dbstiqueue.tblqueue WHERE TransactDate='" + transactDate + "' LIMIT 0,1 ");
                    while (queue_reader.Read())
                    {
                        user = queue_reader.GetString(0);
                        action = queue_reader.GetString(2);
                        display = queue_reader.GetString(1);
                    }
                    queue_reader.Close();
                    if (int.Parse(display) >= 100)
                    {
                        isHundred = true;
                        hundredths = int.Parse(display) / 100;
                        num = int.Parse(display) - (hundredths * 100);
                    }
                    else
                    {
                        isHundred = false;
                        num = int.Parse(display);
                    }

                    if (num >= 20)
                    {
                        isTwenty = true;
                        tenths = num / 10;
                        num = num - (tenths * 10);
                    }
                    else
                    {
                        isTwenty = false;
                    }

                    switch (action)
                    {
                        case "Serve":
                            {
                                forServe = new Thread(Serve);
                                forServe.Start();
                                switch (user)
                                {
                                    case "Accounting":
                                        {
                                            switch (display.Length)
                                            {
                                                case 1:
                                                    {
                                                        lblAccounting.Text = "00" + display;
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        lblAccounting.Text = "0" + display;
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        lblAccounting.Text = display;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case "Registrar":
                                        {
                                            switch (display.Length)
                                            {
                                                case 1:
                                                    {
                                                        lblRegistrar.Text = "00" + display;
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        lblRegistrar.Text = "0" + display;
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        lblRegistrar.Text = display;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case "Cashier":
                                        {
                                            switch (display.Length)
                                            {
                                                case 1:
                                                    {
                                                        lblCashier.Text = "00" + display;
                                                        break;
                                                    }
                                                case 2:
                                                    {
                                                        lblCashier.Text = "0" + display;
                                                        break;
                                                    }
                                                case 3:
                                                    {
                                                        lblCashier.Text = display;
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                }
                                break;
                            }
                        case "Call":
                            {
                                forCall = new Thread(Call);
                                forCall.Start();
                                break;
                            }
                    }
                }
                else
                {
                    Program.Query("DELETE FROM dbstiqueue.tblqueue WHERE Window= '" + user + "'").Close();
                    isUpdating = false;
                }
            }
        }

        private void Serve()
        {
            tone.SoundLocation = "beep_once.wav";
            tone.PlaySync();
            isBlinking = true;
            tone.SoundLocation = "n.wav";
            tone.PlaySync();
            if (isHundred == true)
            {
                switch (hundredths)
                {
                    case 1:
                        {
                            tone.SoundLocation = "1h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 2:
                        {
                            tone.SoundLocation = "2h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "3h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "4h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "5h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "6h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "7h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "8h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "9h.wav";
                            tone.PlaySync();
                            break;
                        }

                }
            }
            if (isTwenty == true)
            {
                switch (tenths)
                {
                    case 2:
                        {
                            tone.SoundLocation = "20.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "30.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "40.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "50.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "60.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "70.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "80.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "90.wav";
                            tone.PlaySync();
                            break;
                        }
                }
                switch (num)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            tone.SoundLocation = "1.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 2:
                        {
                            tone.SoundLocation = "2.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "3.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "4.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "5.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "6.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "7.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "8.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "9.wav";
                            tone.PlaySync();
                            break;
                        }
                }
            }
            else
            {
                switch (num)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            tone.SoundLocation = "1.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 2:
                        {
                            tone.SoundLocation = "2.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "3.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "4.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "5.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "6.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "7.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "8.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "9.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 10:
                        {
                            tone.SoundLocation = "10.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 11:
                        {
                            tone.SoundLocation = "11.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 12:
                        {
                            tone.SoundLocation = "12.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 13:
                        {
                            tone.SoundLocation = "13.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 14:
                        {
                            tone.SoundLocation = "14.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 15:
                        {
                            tone.SoundLocation = "15.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 16:
                        {
                            tone.SoundLocation = "16.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 17:
                        {
                            tone.SoundLocation = "17.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 18:
                        {
                            tone.SoundLocation = "18.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 19:
                        {
                            tone.SoundLocation = "19.wav";
                            tone.PlaySync();
                            break;
                        }
                }
            }

            switch (user)
            {
                case "Accounting":
                    {
                        tone.SoundLocation = "a1.wav";
                        tone.PlaySync();
                        break;
                    }
                case "Registrar":
                    {
                        tone.SoundLocation = "a2.wav";
                        tone.PlaySync();
                        break;
                    }
                case "Cashier":
                    {
                        tone.SoundLocation = "a3.wav";
                        tone.PlaySync();
                        break;
                    }
            }
            Program.Query("DELETE FROM dbstiqueue.tblqueue WHERE Window='" + user + "' AND TicketNo='" + display + "' AND Action='" + "Serve" + "'").Close();
            isUpdating = false;
        }

        private void Call()
        {
            tone.SoundLocation = "beep_twice.wav";
            tone.PlaySync();
            tone.SoundLocation = "Calling.wav";
            tone.PlaySync();
            isBlinking = true;
            if (isHundred == true)
            {
                switch (hundredths)
                {
                    case 1:
                        {
                            tone.SoundLocation = "1h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 2:
                        {
                            tone.SoundLocation = "2h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "3h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "4h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "5h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "6h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "7h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "8h.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "9h.wav";
                            tone.PlaySync();
                            break;
                        }

                }
            }
            if (isTwenty == true)
            {
                switch (tenths)
                {
                    case 2:
                        {
                            tone.SoundLocation = "20.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "30.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "40.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "50.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "60.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "70.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "80.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "90.wav";
                            tone.PlaySync();
                            break;
                        }
                }
                switch (num)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            tone.SoundLocation = "1.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 2:
                        {
                            tone.SoundLocation = "2.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "3.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "4.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "5.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "6.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "7.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "8.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "9.wav";
                            tone.PlaySync();
                            break;
                        }
                }
            }
            else
            {
                switch (num)
                {
                    case 0:
                        {
                            break;
                        }
                    case 1:
                        {
                            tone.SoundLocation = "1.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 2:
                        {
                            tone.SoundLocation = "2.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 3:
                        {
                            tone.SoundLocation = "3.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 4:
                        {
                            tone.SoundLocation = "4.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 5:
                        {
                            tone.SoundLocation = "5.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 6:
                        {
                            tone.SoundLocation = "6.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 7:
                        {
                            tone.SoundLocation = "7.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 8:
                        {
                            tone.SoundLocation = "8.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 9:
                        {
                            tone.SoundLocation = "9.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 10:
                        {
                            tone.SoundLocation = "10.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 11:
                        {
                            tone.SoundLocation = "11.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 12:
                        {
                            tone.SoundLocation = "12.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 13:
                        {
                            tone.SoundLocation = "13.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 14:
                        {
                            tone.SoundLocation = "14.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 15:
                        {
                            tone.SoundLocation = "15.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 16:
                        {
                            tone.SoundLocation = "16.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 17:
                        {
                            tone.SoundLocation = "17.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 18:
                        {
                            tone.SoundLocation = "18.wav";
                            tone.PlaySync();
                            break;
                        }
                    case 19:
                        {
                            tone.SoundLocation = "19.wav";
                            tone.PlaySync();
                            break;
                        }
                }
            }

            switch (user)
            {
                case "Accounting":
                    {
                        tone.SoundLocation = "a1.wav";
                        tone.PlaySync();
                        break;
                    }
                case "Registrar":
                    {
                        tone.SoundLocation = "a2.wav";
                        tone.PlaySync();
                        break;
                    }
                case "Cashier":
                    {
                        tone.SoundLocation = "a3.wav";
                        tone.PlaySync();
                        break;
                    }
            }
            Program.Query("DELETE FROM dbstiqueue.tblqueue WHERE Window='" + user + "' AND TicketNo='" + display + "' AND Action='" + "Call" + "'").Close();
            isUpdating = false;
        }

        private void timerNews_Tick(object sender, EventArgs e)
        {
            if (lblNews.Left < (10 - lblNews.Width))
            {
                lblNews.Location = new Point(1360, 569);
            }
            else
            {
                lblNews.Left = lblNews.Left - 5;
            }
        }
    }
}
