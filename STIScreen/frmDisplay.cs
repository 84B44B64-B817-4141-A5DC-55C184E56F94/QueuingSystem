using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Media;

namespace STI_Queuing_System
{
    public partial class frmDisplay : Form
    {
        //Change password to connect to your SQL
        /// <summary>
        /// PUBLIC VARIABLES:
        int update_accounting, update_registrar, update_cashier, calling_accounting, calling_registrar, calling_cashier, computed_accounting, computed_registrar, computed_cashier, blinker_accounting, blinker_registrar, blinker_cashier, arrayCounter, soundCounter;
        string transactDate;
        bool isUpdating, isCalling;

        /// </summary>
        public frmDisplay()
        {
            InitializeComponent();
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            if (isUpdating == false)
            {
                isUpdating = true;
                arrayCounter = 0;
                MySqlDataReader refresher = Program.Query("SELECT * FROM dbstiqueue.tblscreen where TransactDate like '" + transactDate + "'");
                while (refresher.Read())
                {
                    switch (arrayCounter)
                    {
                        case 0:
                            {
                                update_accounting = int.Parse(refresher.GetString(2));
                                calling_accounting = int.Parse(refresher.GetString(3));
                                computed_accounting = int.Parse(refresher.GetString(5));
                                break;
                            }
                        case 1:
                            {
                                update_registrar = int.Parse(refresher.GetString(2));
                                calling_registrar = int.Parse(refresher.GetString(3));
                                computed_registrar = int.Parse(refresher.GetString(5));
                                break;
                            }
                        case 2:
                            {
                                update_cashier = int.Parse(refresher.GetString(2));
                                calling_cashier = int.Parse(refresher.GetString(3));
                                computed_cashier = int.Parse(refresher.GetString(5));
                                break;
                            }
                    }
                    arrayCounter++;
                }
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
                                lblReg.Text = "0" + lblReg.Text;
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
            if (isCalling == false)
            {
                isCalling = true;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "beep.wav";
                player.Play();
            }
            if (soundCounter > 10)
            {
                isCalling = false;
                soundCounter = 0;
            }
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
            }
        }

        private void RegistrarCall()
        {
            if (isCalling == false)
            {
                isCalling = true;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "beep.wav";
                player.Play();
            }
            if (soundCounter > 10)
            {
                isCalling = false;
                soundCounter = 0;
            }
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
            }
        }

        private void CashierCall()
        {
            if (isCalling == false)
            {
                isCalling = true;
                SoundPlayer player = new SoundPlayer();
                player.SoundLocation = "beep.wav";
                player.Play();
            }
            if (soundCounter > 10)
            {
                isCalling = false;
                soundCounter = 0;
            }
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
                blinker_accounting = 0;
            }
        }
    }
}
