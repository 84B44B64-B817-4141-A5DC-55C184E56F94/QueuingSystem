using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace STI_Queuing_System
{
    public partial class frmAudit : Form
    {
        string user, transactDate, exportType = "Date", read;
        Thread export;

        public frmAudit()
        {
            InitializeComponent();
        }

        private void frmAudit_Load(object sender, EventArgs e)
        {
            user = lblUser.Text;
            monDate.TodayDate = DateTime.Now;
            transactDate = DateTime.Now.ToString("yyyy-MM-dd");
            getInfo();
        }

        private void monDate_DateChanged(object sender, DateRangeEventArgs e)
        {
            transactDate = monDate.SelectionRange.Start.ToString("yyyy-MM-dd");
            getInfo();
        }

        private void radDate_CheckedChanged(object sender, EventArgs e)
        {
            if (radDate.Checked == true)
            {
                radAll.Checked = false;
                radMonth.Checked = false;
                exportType = "Date";
            }
        }

        private void radMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radMonth.Checked == true)
            {
                radAll.Checked = false;
                radDate.Checked = false;
                exportType = "Month";
            }
        }

        private void radAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radAll.Checked == true)
            {
                radDate.Checked = false;
                radMonth.Checked = false;
                exportType = "All";
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (radDate.Checked == true)
            {
                if (MessageBox.Show("Start Exporting [by Selected Date]?","System",MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("Data export will now start. Feel free to continue on your work while the data is being prepared.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblExport.Visible = true;
                    proExport.Visible = true;
                    btnExport.Enabled = false;

                    ToExcel();
                    //export = new Thread(ToExcel);
                   // export.Start();
                }
            }
            else if (radMonth.Checked == true)
            {
                if (MessageBox.Show("Start Exporting [by Selected Month & Year]?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("Data export will now start. Feel free to continue on your work while the data is being prepared.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblExport.Visible = true;
                    proExport.Visible = true;
                    btnExport.Enabled = false;

                    export = new Thread(toExcel);
                    export.Start();
                }
            }
            else if (radAll.Checked == true)
            {
                if (MessageBox.Show("Start Exporting [Everything]?", "System", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("Data export will now start. Feel free to continue on your work while the data is being prepared.", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblExport.Visible = true;
                    proExport.Visible = true;
                    btnExport.Enabled = false;

                    export = new Thread(toExcel);
                    export.Start();
                }
            }
        }

        private void timMonitor_Tick(object sender, EventArgs e)
        {

        }

        private void ToExcel()
        {
            Excel.Application app = new Excel.Application();
            app.Visible = false;
            Excel.Workbook wb = app.Workbooks.Add(1);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Worksheets[1];
            int i = 1;
            int i2 = 1;
            foreach (ListViewItem lvi in lsvData.Items)
            {
                i = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                {
                    ws.Cells[i2, i] = lvs.Text;
                    i++;
                }
                i2++;
            }
        }

        private void toExcel()
        {
            switch (exportType)
            {
                case "Date":
                    {
                        string sql = null;
                        string data = null;
                        int i = 0;
                        int j = 0;
                        Excel.Application xlApp;
                        Excel.Workbook xlWorkBook;
                        Excel.Worksheet xlWorkSheet;
                        object misValue = System.Reflection.Missing.Value;
                        xlApp = new Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Add(misValue);
                        xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                        string line;
                        StreamReader file = new StreamReader("config.ini");
                        while ((line = file.ReadLine()) != null)
                        {
                            read = line;
                            line = line.Remove(4, line.Length - 4);
                            if (line == "ip_a")
                            {
                                read = read.Remove(0, 11);
                            }
                        }
                        MySqlConnection conn = new MySqlConnection("datasource=" + read + ";port=3306;username=root;password=mySQL09122016");
                        conn.Open();
                        switch (user)
                        {
                            case "Accounting":
                                {
                                    sql = "SELECT * FROM dbstiqueue.tblaudit where TransactDate like '" + transactDate + "' and Window like '" + "1" + "'";
                                    break;
                                }
                            case "Registrar":
                                {
                                    sql = "SELECT * FROM dbstiqueue.tblaudit where TransactDate like '" + transactDate + "' and Window like '" + "2" + "'";
                                    break;
                                }
                            case "Cashier":
                                {
                                    sql = "SELECT * FROM dbstiqueue.tblaudit where TransactDate like '" + transactDate + "' and Window like '" + "3" + "'";
                                    break;
                                }
                            default:
                                {
                                    MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                        }
                        MySqlDataAdapter dscmd = new MySqlDataAdapter(sql, conn);
                        DataSet ds = new DataSet();
                        dscmd.Fill(ds);
                        for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                        {
                            for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                            {
                                data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                                xlWorkSheet.Cells[i + 1, j + 1] = data;
                            }
                        }
                        string auditdate = DateTime.Now.ToString("yyyyMMddHHmmss");
                        xlWorkBook.SaveAs("audit_" + auditdate + ".xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                        xlWorkBook.Close(true, misValue, misValue);
                        xlApp.Quit();
                        releaseObject(xlWorkSheet);
                        releaseObject(xlWorkBook);
                        releaseObject(xlApp);
                        conn.Close();
                        MessageBox.Show("Excel file created at My Documents", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        System.Diagnostics.Process.Start("explorer.exe", "::{450d8fba-ad25-11d0-98a8-0800361b1103}");
                        break;
                    }
                case "Month":
                    {
                        break;
                    }
                case "All":
                    {
                        break;
                    }
                default:
                    {
                        MessageBox.Show("ERROR: Unknown user.", "System", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
            }
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occurred while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void getInfo()
        {
            lsvData.Items.Clear();
            switch (user)
            {
                case "Accounting":
                    {
                        MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblaudit where Window like '" + "1" + "' and transactDate like '" + transactDate + "'");
                        while (loader.Read())
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.SubItems.Add(loader.GetString(1));
                            if (loader.GetString(3) == "0")
                            {
                                lst.SubItems.Add(loader.GetString(2) + ".00");
                            }
                            else
                            {
                                lst.SubItems.Add(loader.GetString(2) + loader.GetString(3).Substring(loader.GetString(3).LastIndexOf('.')));
                            }
                            var date = Convert.ToDateTime(loader.GetString(4)).ToString("MMM dd yyyy");
                            var time = Convert.ToDateTime(loader.GetString(5)).ToString("hh:mm:ss tt");
                            lst.SubItems.Add(date);
                            lst.SubItems.Add(time);
                            lsvData.Items.Add(lst);
                        }
                        loader.Close();
                        break;
                    }
                case "Registrar":
                    {
                        MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblaudit where Window like '" + "2" + "' and transactDate like '" + transactDate + "'");
                        while (loader.Read())
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.SubItems.Add(loader.GetString(1));
                            if (loader.GetString(3) == "0")
                            {
                                lst.SubItems.Add(loader.GetString(2) + ".00");
                            }
                            else
                            {
                                lst.SubItems.Add(loader.GetString(2) + loader.GetString(3).Substring(loader.GetString(3).LastIndexOf('.')));
                            }
                            var date = Convert.ToDateTime(loader.GetString(4)).ToString("MMM dd yyyy");
                            var time = Convert.ToDateTime(loader.GetString(5)).ToString("hh:mm:ss tt");
                            lst.SubItems.Add(date);
                            lst.SubItems.Add(time);
                            lsvData.Items.Add(lst);
                        }
                        loader.Close();
                        break;
                    }
                case "Cashier":
                    {
                        MySqlDataReader loader = Program.Query("Select * from dbstiqueue.tblaudit where Window like '" + "3" + "' and transactDate like '" + transactDate + "'");
                        while (loader.Read())
                        {
                            ListViewItem lst = new ListViewItem();
                            lst.SubItems.Add(loader.GetString(1));
                            if (loader.GetString(3) == "0")
                            {
                                lst.SubItems.Add(loader.GetString(2) + ".00");
                            }
                            else
                            {
                                lst.SubItems.Add(loader.GetString(2) + loader.GetString(3).Substring(loader.GetString(3).LastIndexOf('.')));
                            }
                            var date = Convert.ToDateTime(loader.GetString(4)).ToString("MMM dd yyyy");
                            var time = Convert.ToDateTime(loader.GetString(5)).ToString("hh:mm:ss tt");
                            lst.SubItems.Add(date);
                            lst.SubItems.Add(time);
                            lsvData.Items.Add(lst);
                        }
                        loader.Close();
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
