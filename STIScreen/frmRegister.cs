using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Principal;

namespace STI_Queuing_System
{
    public partial class frmRegister : Form
    {
        string MAC_address, checkState,IP_address;
        bool isRegistered_Accounting, isRegistered_Cashier, isRegistered_Registrar;

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (checkState)
            {
                case "Accounting":
                    {
                        if (isRegistered_Accounting == true)
                        {
                            if (MessageBox.Show("Accounting account is already registered to another PC. Overwrite data?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            {
                                return;
                            }
                            else
                            {
                                Program.Query("UPDATE dbstiqueue.tbladdress SET IP_Address='" + IP_address + "',MAC_Address='" + MAC_address + "',Working='" + "1" + "' WHERE Window='" + "Accounting" + "'").Close();
                                MessageBox.Show("Network details has been successfully registered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            Program.Query("UPDATE dbstiqueue.tbladdress SET IP_Address='" + IP_address + "',MAC_Address='" + MAC_address + "',Working='" + "1" + "' WHERE Window='" + "Accounting" + "'").Close();
                            MessageBox.Show("Network details has been successfully registered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                        break;
                    }
                case "Registrar":
                    {
                        if (isRegistered_Registrar == true)
                        {
                            if (MessageBox.Show("Registrar account is already registered to another PC. Overwrite data?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            {
                                return;
                            }
                            else
                            {
                                Program.Query("UPDATE dbstiqueue.tbladdress SET IP_Address='" + IP_address + "',MAC_Address='" + MAC_address + "',Working='" + "1" + "' WHERE Window='" + "Registrar" + "'").Close();
                                MessageBox.Show("Network details has been successfully registered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            Program.Query("UPDATE dbstiqueue.tbladdress SET IP_Address='" + IP_address + "',MAC_Address='" + MAC_address + "',Working='" + "1" + "' WHERE Window='" + "Registrar" + "'").Close();
                            MessageBox.Show("Network details has been successfully registered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                        break;
                    }
                case "Cashier":
                    {
                        if (isRegistered_Accounting == true)
                        {
                            if (MessageBox.Show("Cashier account is already registered to another PC. Overwrite data?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
                            {
                                return;
                            }
                            else
                            {
                                Program.Query("UPDATE dbstiqueue.tbladdress SET IP_Address='" + IP_address + "',MAC_Address='" + MAC_address + "',Working='" + "1" + "' WHERE Window='" + "Cashier" + "'").Close();
                                MessageBox.Show("Network details has been successfully registered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                            }
                        }
                        else
                        {
                            Program.Query("UPDATE dbstiqueue.tbladdress SET IP_Address='" + IP_address + "',MAC_Address='" + MAC_address + "',Working='" + "1" + "' WHERE Window='" + "Cashier" + "'").Close();
                            MessageBox.Show("Network details has been successfully registered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }
                        break;
                    }
            }
        }

        private void radRegistrar_CheckedChanged(object sender, EventArgs e)
        {
            if (radRegistrar.Checked == true)
            {
                checkState = "Registrar";
            }
        }

        private void frmRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radCashier_CheckedChanged(object sender, EventArgs e)
        {
            if (radCashier.Checked == true)
            {
                checkState = "Cashier";
            }
        }

        private void radAccounting_CheckedChanged(object sender, EventArgs e)
        {
            if (radAccounting.Checked == true)
            {
                checkState = "Accounting";
            }
        }

        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            MAC_address = lbl_MAC.Text;
            IP_address = lbl_IPAddress.Text;
            MySqlDataReader check = Program.Query("SELECT * FROM dbstiqueue.tbladdress WHERE Working='" + "1" + "'");
            while (check.Read())
            {
                switch (check.GetString(0))
                {
                    case "Accounting":
                        {
                            isRegistered_Accounting = true;
                            break;
                        }
                    case "Registrar":
                        {
                            isRegistered_Registrar = true;
                            break;
                        }
                    case "Cashier":
                        {
                            isRegistered_Cashier = true;
                            break;
                        }
                }
            }
            check.Close();
        }
    }
}
