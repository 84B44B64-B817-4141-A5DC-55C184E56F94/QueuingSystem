using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace STI_Queuing_System
{
    public partial class frmDisplay : Form
    {
        //Change password to connect to your SQL
        int update_accounting = 0, update_registrar = 0, update_cashier = 0, calling_accounting = 0, calling_registrar = 0, calling_cashier = 0, computed_accounting = 0, computed_registrar =0, computed_cashier = 0, blinker_accounting = 0, blinker_registrar = 0, blinker_cashier = 0, arrayCounter = 0, soundCounter = 0;
        string transactDate;
        bool isUpdating, isCalling, isBlinking_Accounting, isBlinking_Registrar, isBlinking_Cashier;

        public frmDisplay()
        {
            InitializeComponent();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            transactDate = DateTime.Now.ToString("yyyy-MM-dd");
            if (isUpdating == false)
            {
                isUpdating = true;
                MySqlDataReader refresher_accounting = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "1" + "' and TransactDate like '" + transactDate + "'");
                while (refresher_accounting.Read())
                {
                    update_accounting = int.Parse(refresher_accounting.GetString(2));
                    calling_accounting = int.Parse(refresher_accounting.GetString(3));
                    computed_accounting = int.Parse(refresher_accounting.GetString(5));
                }
                refresher_accounting.Close();
                MySqlDataReader refresher_registrar = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "2" + "' and TransactDate like '" + transactDate + "'");
                while (refresher_registrar.Read())
                {
                    update_registrar = int.Parse(refresher_registrar.GetString(2));
                    calling_registrar = int.Parse(refresher_registrar.GetString(3));
                    computed_registrar = int.Parse(refresher_registrar.GetString(5));
                }
                refresher_registrar.Close();
                MySqlDataReader refresher_cashier = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "3" + "' and TransactDate like '" + transactDate + "'");
                while (refresher_cashier.Read())
                {
                    update_cashier = int.Parse(refresher_cashier.GetString(2));
                    calling_cashier = int.Parse(refresher_cashier.GetString(3));
                    computed_cashier = int.Parse(refresher_cashier.GetString(5));
                }
                refresher_cashier.Close();
                if (update_accounting == 1)
                {
                    MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "1" + "'");
                    while (loader.Read())
                    {
                        lblAcc.Text = loader.GetString(1);
                    }
                    loader.Close();
                    switch (lblAcc.Text.Length)
                    {
                        case 1:
                            {
                                lblAcc.Text = "00" + lblAcc.Text;
                                break;
                            }
                        case 2:
                            {
                                lblAcc.Text = "0" + lblAcc.Text;
                                break;
                            }
                    }
                    Program.Query("Update dbstiqueue.tblscreen set Serving = '" + "0" + "' where Window = '" + "1" + "'").Close();
                }
                if (calling_accounting == 1)
                {
                    Program.Query("Update dbstiqueue.tblscreen set Calling = '" + "0" + "' where Window = '" + "1" + "'").Close();
                    AccountingCall();
                }
                if (computed_accounting == 1)
                {
                    MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "1" + "'");
                    while (loader.Read())
                    {
                        lblAccTime.Text = loader.GetString(4);
                    }
                    loader.Close();
                    Program.Query("Update dbstiqueue.tblscreen set Computed = '" + "0" + "' where Window = '" + "1" + "'").Close();
                }
                if (update_registrar == 1)
                {
                    MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "2" + "'");
                    while (loader.Read())
                    {
                        lblReg.Text = loader.GetString(1);
                    }
                    loader.Close();
                    switch (lblReg.Text.Length)
                    {
                        case 1:
                            {
                                lblReg.Text = "00" + lblReg.Text;
                                break;
                            }
                        case 2:
                            {
                                lblReg  .Text = "0" + lblReg.Text;
                                break;
                            }
                    }
                    Program.Query("Update dbstiqueue.tblscreen set Serving = '" + "0" + "' where Window = '" + "2" + "'").Close();
                }
                if (calling_registrar == 1)
                {
                    Program.Query("Update dbstiqueue.tblscreen set Calling = '" + "0" + "' where Window = '" + "2" + "'").Close();
                    RegistrarCall();
                }
                if (computed_registrar == 1)
                {
                    MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "2" + "'");
                    while (loader.Read())
                    {
                        lblRegTime.Text = loader.GetString(4);
                    }
                    loader.Close();
                    Program.Query("Update dbstiqueue.tblscreen set Computed = '" + "0" + "' where Window = '" + "2" + "'").Close();
                }
                if (update_cashier == 1)
                {
                    MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "3" + "'");
                    while (loader.Read())
                    {
                        lblCash.Text = loader.GetString(1);
                    }
                    loader.Close();
                    switch (lblCash.Text.Length)
                    {
                        case 1:
                            {
                                lblCash.Text = "00" + lblCash.Text;
                                break;
                            }
                        case 2:
                            {
                                lblCash.Text = "0" + lblCash.Text;
                                break;
                            }
                    }
                    Program.Query("Update dbstiqueue.tblscreen set Serving = '" + "0" + "' where Window = '" + "3" + "'").Close();
                }
                if (calling_cashier == 1)
                {
                    Program.Query("Update dbstiqueue.tblscreen set Calling = '" + "0" + "' where Window = '" + "3" + "'").Close();
                    CashierCall();
                }
                if (computed_cashier == 1)
                {
                    MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblscreen where Window like '" + "3" + "'");
                    while (loader.Read())
                    {
                        lblCashTime.Text = loader.GetString(4);
                    }
                    loader.Close();
                    Program.Query("Update dbstiqueue.tblscreen set Computed = '" + "0" + "' where Window = '" + "3" + "'").Close();
                }
                isUpdating = false;
            }
            lblClock.Text = DateTime.Now.ToString("MMM dd, yyyy hh:mm:ss tt");
            if (isCalling == true)
            {
                soundCounter++;
            }
            if (isBlinking_Accounting == true)
            {
                blinkAccounting();
            }
            if (isBlinking_Registrar == true)
            {
                blinkRegistrar();
            }
            if (isBlinking_Cashier == true)
            {
                blinkCashier();
            }
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

        private void AccountingCall()
        {
            if (soundCounter > 50)
            {
                isCalling = false;
                soundCounter = 0;
            }
            if (isCalling == false)
            {
                isCalling = true;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "beep.wav";
                player.Play();
            }
            isBlinking_Accounting = true;
        }

        private void blinkAccounting()
        {
            blinker_accounting++;
            if (blinker_accounting >= 5 && blinker_accounting <= 9)
            {
                lblAcc.Visible = false;
            }
            else if (blinker_accounting >= 10 && blinker_accounting <= 14)
            {
                lblAcc.Visible = true;
            }
            else if (blinker_accounting >= 15 && blinker_accounting <= 19)
            {
                lblAcc.Visible = false;
            }
            else if (blinker_accounting > 19 && blinker_accounting <= 24)
            {
                lblAcc.Visible = true;
            }
            else if (blinker_accounting > 25 && blinker_accounting <= 29)
            {
                lblAcc.Visible = false;
            }
            else if (blinker_accounting > 29)
            {
                lblAcc.Visible = true;
                blinker_accounting = 0;
                isBlinking_Accounting = false;
            }
        }

        private void RegistrarCall()
        {
            if (soundCounter > 50)
            {
                isCalling = false;
                soundCounter = 0;
            }
            if (isCalling == false)
            {
                isCalling = true;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "beep.wav";
                player.Play();
            }
            isBlinking_Registrar = true;
        }

        private void blinkRegistrar()
        {
            blinker_registrar++;
            if (blinker_registrar >= 5 && blinker_registrar <= 9)
            {
                lblReg.Visible = false;
            }
            else if (blinker_registrar >= 10 && blinker_registrar <= 14)
            {
                lblReg.Visible = true;
            }
            else if (blinker_registrar >= 15 && blinker_registrar <= 19)
            {
                lblReg.Visible = false;
            }
            else if (blinker_registrar > 19 && blinker_registrar <= 24)
            {
                lblReg.Visible = true;
            }
            else if (blinker_registrar > 25 && blinker_registrar <= 29)
            {
                lblReg.Visible = false;
            }
            else if (blinker_registrar > 29)
            {
                lblReg.Visible = true;
                blinker_registrar = 0;
                isBlinking_Registrar = false;
            }
        }

        private void CashierCall()
        {
            if (soundCounter > 50)
            {
                isCalling = false;
                soundCounter = 0;
            }
            if (isCalling == false)
            {
                isCalling = true;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "beep.wav";
                player.Play();
            }
            isBlinking_Cashier = true;
        }

        private void blinkCashier()
        {
            blinker_cashier++;
            if (blinker_cashier >= 5 && blinker_cashier <= 9)
            {
                lblCash.Visible = false;
            }
            else if (blinker_cashier >= 10 && blinker_cashier <= 14)
            {
                lblCash.Visible = true;
            }
            else if (blinker_cashier >= 15 && blinker_cashier <= 19)
            {
                lblCash.Visible = false;
            }
            else if (blinker_cashier > 19 && blinker_cashier <= 24)
            {
                lblCash.Visible = true;
            }
            else if (blinker_cashier > 25 && blinker_cashier <= 29)
            {
                lblCash.Visible = false;
            }
            else if (blinker_cashier > 29)
            {
                lblCash.Visible = true;
                blinker_cashier = 0;
                isBlinking_Cashier = false;
            }
        }
    }
}
