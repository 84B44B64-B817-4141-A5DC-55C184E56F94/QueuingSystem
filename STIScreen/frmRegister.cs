using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace STI_Queuing_System
{
    public partial class frmRegister : Form
    {
        string ip_read, ip_address;
        public frmRegister()
        {
            InitializeComponent();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            getIPv4();
            txt1st.Text = ip_address.Substring(0, ip_address.IndexOf("."));
            ip_address = ip_address.Remove(0, ip_address.IndexOf("."));
            ip_address = ip_address.Remove(0, 1);
            txt2nd.Text = ip_address.Substring(0, ip_address.IndexOf("."));
            ip_address = ip_address.Remove(0, ip_address.IndexOf("."));
            ip_address = ip_address.Remove(0, 1);
            txt3rd.Text = ip_address.Substring(0, ip_address.IndexOf("."));
            ip_address = ip_address.Remove(0, ip_address.IndexOf("."));
            ip_address = ip_address.Remove(0, 1);
            txt4th.Text = ip_address;
            MySqlDataReader IP_Accounting = Program.Query("SELECT Accounting FROM dbstiqueue.tbladdress");
            while (IP_Accounting.Read())
            {
                ip_read = IP_Accounting.GetString(0);
                txt1stOld_Accounting.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt2ndOld_Accounting.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt3rdOld_Accounting.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt4thOld_Accounting.Text = ip_read;
            }
            IP_Accounting.Close();
            MySqlDataReader IP_Cashier = Program.Query("SELECT Cashier FROM dbstiqueue.tbladdress");
            while (IP_Cashier.Read())
            {
                ip_read = IP_Cashier.GetString(0);
                txt1stOld_Cashier.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt2ndOld_Cashier.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt3rdOld_Cashier.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt4thOld_Cashier.Text = ip_read;
            }
            IP_Cashier.Close();
            MySqlDataReader IP_Registrar = Program.Query("SELECT Registrar FROM dbstiqueue.tbladdress");
            while (IP_Registrar.Read())
            {
                ip_read = IP_Registrar.GetString(0);
                txt1stOld_Registrar.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt2ndOld_Registrar.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt3rdOld_Registrar.Text = ip_read.Substring(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, ip_read.IndexOf("."));
                ip_read = ip_read.Remove(0, 1);
                txt4thOld_Registrar.Text = ip_read;
            }
        }

        private void txt1stNew_Accounting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt2ndNew_Accounting.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt2ndNew_Accounting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt3rdNew_Accounting.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt3rdNew_Accounting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt4thNew_Accounting.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt4thNew_Accounting_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt1stNew_Cashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt2ndNew_Cashier.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt2ndNew_Cashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt3rdNew_Cashier.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt3rdNew_Cashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt4thNew_Cashier.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt4thNew_Cashier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt1stNew_Registrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt2ndNew_Registrar.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt2ndNew_Registrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt3rdNew_Registar.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt3rdNew_Registar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                txt4thNew_Registrar.Focus();
            }

            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt4thNew_Registrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (!(e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void txt1stNew_Accounting_TextChanged(object sender, EventArgs e)
        {
            if (txt1stNew_Accounting.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt1stNew_Accounting.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt1stNew_Accounting.Text = "";
                }
                else
                {
                    if (txt1stNew_Accounting.TextLength == txt1stNew_Accounting.MaxLength)
                    {
                        txt2ndNew_Accounting.Select(0, txt2ndNew_Accounting.MaxLength);
                        txt2ndNew_Accounting.Focus();
                    }
                }
            }
        }

        private void txt2ndNew_Accounting_TextChanged(object sender, EventArgs e)
        {
            if (txt2ndNew_Accounting.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt2ndNew_Accounting.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt1stNew_Accounting.Text = "";
                }
                else
                {
                    if (txt2ndNew_Accounting.TextLength == txt2ndNew_Accounting.MaxLength)
                    {
                        txt3rdNew_Accounting.Select(0, txt3rdNew_Accounting.MaxLength);
                        txt3rdNew_Accounting.Focus();
                    }
                }
            }
        }

        private void txt3rdNew_Accounting_TextChanged(object sender, EventArgs e)
        {
            if (txt3rdNew_Accounting.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt3rdNew_Accounting.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt3rdNew_Accounting.Text = "";
                }
                else
                {
                    if (txt3rdNew_Accounting.TextLength == txt3rdNew_Accounting.MaxLength)
                    {
                        txt4thNew_Accounting.Select(0, txt4thNew_Accounting.MaxLength);
                        txt4thNew_Accounting.Focus();
                    }
                }
            }
        }

        private void txt4thNew_Accounting_TextChanged(object sender, EventArgs e)
        {
            if (txt4thNew_Accounting.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt4thNew_Accounting.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt1stNew_Accounting.Text = "";
                }
            }
        }

        private void txt1stNew_Cashier_TextChanged(object sender, EventArgs e)
        {
            if (txt1stNew_Cashier.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt1stNew_Cashier.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt1stNew_Cashier.Text = "";
                }
                else
                {
                    if (txt1stNew_Cashier.TextLength == txt1stNew_Cashier.MaxLength)
                    {
                        txt2ndNew_Cashier.Select(0, txt2ndNew_Cashier.MaxLength);
                        txt2ndNew_Cashier.Focus();
                    }
                }
            }
        }

        private void txt2ndNew_Cashier_TextChanged(object sender, EventArgs e)
        {
            if (txt2ndNew_Cashier.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt2ndNew_Cashier.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt2ndNew_Cashier.Text = "";
                }
                else
                {
                    if (txt2ndNew_Cashier.TextLength == txt2ndNew_Cashier.MaxLength)
                    {
                        txt3rdNew_Cashier.Select(0, txt3rdNew_Cashier.MaxLength);
                        txt3rdNew_Cashier.Focus();
                    }
                }
            }
        }

        private void txt3rdNew_Cashier_TextChanged(object sender, EventArgs e)
        {
            if (txt3rdNew_Cashier.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt3rdNew_Cashier.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt3rdNew_Cashier.Text = "";
                }
                else
                {
                    if (txt3rdNew_Cashier.TextLength == txt3rdNew_Cashier.MaxLength)
                    {
                        txt4thNew_Cashier.Select(0, txt4thNew_Cashier.MaxLength);
                        txt4thNew_Cashier.Focus();
                    }
                }
            }
        }

        private void txt4thNew_Cashier_TextChanged(object sender, EventArgs e)
        {
            if (txt4thNew_Cashier.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt4thNew_Cashier.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt4thNew_Cashier.Text = "";
                }
            }
        }

        private void txt1stNew_Registrar_TextChanged(object sender, EventArgs e)
        {
            if (txt1stNew_Registrar.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt1stNew_Registrar.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt1stNew_Registrar.Text = "";
                }
                else
                {
                    if (txt1stNew_Registrar.TextLength == txt1stNew_Registrar.MaxLength)
                    {
                        txt2ndNew_Registrar.Select(0, txt2ndNew_Registrar.MaxLength);
                        txt2ndNew_Registrar.Focus();
                    }
                }
            }
        }

        private void txt2ndNew_Registrar_TextChanged(object sender, EventArgs e)
        {
            if (txt2ndNew_Registrar.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt2ndNew_Registrar.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt2ndNew_Registrar.Text = "";
                }
                else
                {
                    if (txt2ndNew_Registrar.TextLength == txt2ndNew_Registrar.MaxLength)
                    {
                        txt3rdNew_Registar.Select(0, txt3rdNew_Registar.MaxLength);
                        txt3rdNew_Registar.Focus();
                    }
                }
            }
        }

        private void txt3rdNew_Registar_TextChanged(object sender, EventArgs e)
        {
            if (txt3rdNew_Registar.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt3rdNew_Registar.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt3rdNew_Registar.Text = "";
                }
                else
                {
                    if (txt3rdNew_Registar.TextLength == txt3rdNew_Registar.MaxLength)
                    {
                        txt4thNew_Registrar.Select(0, txt4thNew_Registrar.MaxLength);
                        txt4thNew_Registrar.Focus();
                    }
                }
            }
        }

        private void txt4thNew_Registrar_TextChanged(object sender, EventArgs e)
        {
            if (txt4thNew_Registrar.Text.Trim() == "")
            {
                return;
            }
            else
            {
                if (int.Parse(txt4thNew_Registrar.Text) > 255)
                {
                    MessageBox.Show("Range is 0 - 255 only.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt4thNew_Registrar.Text = "";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txt1stNew_Accounting.Text.Trim() == "" || txt2ndNew_Accounting.Text.Trim() == "" || txt3rdNew_Accounting.Text.Trim() == "" || txt4thNew_Accounting.Text.Trim() == "") && (!(txt1stNew_Accounting.Text.Trim() == "" && txt2ndNew_Accounting.Text.Trim() == "" && txt3rdNew_Accounting.Text.Trim() == "" && txt4thNew_Accounting.Text.Trim() == "")))
            {
                MessageBox.Show("Incomplete Accounting IP Address.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt1stNew_Accounting.Focus();
            }
            else
            {
                if ((txt1stNew_Cashier.Text.Trim() == "" || txt2ndNew_Cashier.Text.Trim() == "" || txt3rdNew_Cashier.Text.Trim() == "" || txt4thNew_Cashier.Text.Trim() == "") && (!(txt1stNew_Cashier.Text.Trim() == "" && txt2ndNew_Cashier.Text.Trim() == "" && txt3rdNew_Cashier.Text.Trim() == "" && txt4thNew_Cashier.Text.Trim() == "")))
                {
                    MessageBox.Show("Incomplete Cashier IP Address.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt1stNew_Cashier.Focus();
                }
                else
                {
                    if ((txt1stNew_Registrar.Text.Trim() == "" || txt2ndNew_Registrar.Text.Trim() == "" || txt3rdNew_Registar.Text.Trim() == "" || txt4thNew_Registrar.Text.Trim() == "") && (!(txt1stNew_Registrar.Text.Trim() == "" && txt2ndNew_Registrar.Text.Trim() == "" && txt3rdNew_Registar.Text.Trim() == "" && txt4thNew_Registrar.Text.Trim() == "")))
                    {
                        MessageBox.Show("Incomplete Registrar IP Address.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt1stNew_Registrar.Focus();
                    }
                    else
                    {
                        if (txt1stNew_Accounting.Text != "127")
                        {
                            if (txt1stNew_Cashier.Text != "127")
                            {
                                if (txt1stNew_Registrar.Text != "127")
                                {
                                    string IPParse_Accounting = txt1stNew_Accounting.Text + "." + txt2ndNew_Accounting.Text + "." + txt3rdNew_Accounting.Text + "." + txt4thNew_Accounting.Text;
                                    if (IPParse_Accounting != "...")
                                    {
                                        Program.Query("UPDATE dbstiqueue.tbladdress SET Accounting='" + IPParse_Accounting + "'").Close();
                                    }
                                    string IPParse_Cashier = txt1stNew_Cashier.Text + "." + txt2ndNew_Cashier.Text + "." + txt3rdNew_Cashier.Text + "." + txt4thNew_Cashier.Text;
                                    if (IPParse_Cashier != "...")
                                    {
                                        Program.Query("UPDATE dbstiqueue.tbladdress SET Cashier='" + IPParse_Cashier + "'").Close();
                                    }
                                    string IPParse_Registrar = txt1stNew_Registrar.Text + "." + txt2ndNew_Registrar.Text + "." + txt3rdNew_Registar.Text + "." + txt4thNew_Registrar.Text;
                                    if (IPParse_Registrar != "...")
                                    {
                                        Program.Query("UPDATE dbstiqueue.tbladdress SET Registrar='" + IPParse_Registrar + "'").Close();
                                    }
                                    MessageBox.Show("IP Addresses successfully registered. Please restart application.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Application.Exit();
                                }
                                else
                                {
                                    MessageBox.Show("ERROR @ Registrar IP: 127 is the start of a loopback address and cannot be used.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    txt1stNew_Registrar.Select(0, txt2ndNew_Accounting.MaxLength);
                                    txt1stNew_Registrar.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("ERROR @ Cashier IP: 127 is the start of a loopback address and cannot be used.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                txt1stNew_Cashier.Select(0, txt2ndNew_Accounting.MaxLength);
                                txt1stNew_Cashier.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("ERROR @ Accounting IP: 127 is the start of a loopback address and cannot be used.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt1stNew_Accounting.Select(0, txt2ndNew_Accounting.MaxLength);
                            txt1stNew_Accounting.Focus();
                        }
                    }
                }
            }
        }

        private void txt1stNew_Accounting_Leave(object sender, EventArgs e)
        {
            if (txt1stNew_Accounting.Text.Trim() != "")
            {
                txt1stNew_Accounting.Text = (int.Parse(txt1stNew_Accounting.Text)).ToString();
            }
        }

        private void txt2ndNew_Accounting_Leave(object sender, EventArgs e)
        {
            if (txt2ndNew_Accounting.Text.Trim() != "")
            {
                txt2ndNew_Accounting.Text = (int.Parse(txt2ndNew_Accounting.Text)).ToString();
            }
        }

        private void txt3rdNew_Accounting_Leave(object sender, EventArgs e)
        {
            if (txt2ndNew_Accounting.Text.Trim() != "")
            {
                txt3rdNew_Accounting.Text = (int.Parse(txt3rdNew_Accounting.Text)).ToString();
            }
        }

        private void txt4thNew_Accounting_Leave(object sender, EventArgs e)
        {
            if (txt4thNew_Accounting.Text.Trim() != "")
            {
                txt4thNew_Accounting.Text = (int.Parse(txt4thNew_Accounting.Text)).ToString();
            }
        }

        private void txt1stNew_Cashier_Leave(object sender, EventArgs e)
        {
            if (txt1stNew_Cashier.Text.Trim() != "")
            {
                txt1stNew_Cashier.Text = (int.Parse(txt1stNew_Cashier.Text)).ToString();
            }
        }

        private void txt2ndNew_Cashier_Leave(object sender, EventArgs e)
        {
            if (txt2ndNew_Cashier.Text.Trim() != "")
            {
                txt2ndNew_Cashier.Text = (int.Parse(txt2ndNew_Cashier.Text)).ToString();
            }
        }

        private void txt3rdNew_Cashier_Leave(object sender, EventArgs e)
        {
            if (txt3rdNew_Cashier.Text.Trim() != "")
            {
                txt3rdNew_Accounting.Text = (int.Parse(txt3rdNew_Accounting.Text)).ToString();
            }
        }

        private void txt4thNew_Cashier_Leave(object sender, EventArgs e)
        {
            if (txt4thNew_Cashier.Text.Trim() != "")
            {
                txt4thNew_Accounting.Text = (int.Parse(txt4thNew_Accounting.Text)).ToString();
            }
        }

        private void txt1stNew_Registrar_Leave(object sender, EventArgs e)
        {
            if (txt1stNew_Registrar.Text.Trim() != "")
            {
                txt1stNew_Registrar.Text = (int.Parse(txt1stNew_Registrar.Text)).ToString();
            }
        }

        private void txt2ndNew_Registrar_Leave(object sender, EventArgs e)
        {
            if (txt2ndNew_Registrar.Text.Trim() != "")
            {
                txt2ndNew_Registrar.Text = (int.Parse(txt2ndNew_Registrar.Text)).ToString();
            }
        }

        private void txt3rdNew_Registar_Leave(object sender, EventArgs e)
        {
            if (txt3rdNew_Registar.Text.Trim() != "")
            {
                txt3rdNew_Registar.Text = (int.Parse(txt3rdNew_Registar.Text)).ToString();
            }
        }

        private void txt4thNew_Registrar_Leave(object sender, EventArgs e)
        {
            if (txt4thNew_Registrar.Text.Trim() != "")
            {
                txt4thNew_Accounting.Text = (int.Parse(txt4thNew_Accounting.Text)).ToString();
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
        }
    }
}
