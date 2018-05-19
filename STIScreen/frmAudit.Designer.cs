namespace STI_Queuing_System
{
    partial class frmAudit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAudit));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.radAll = new System.Windows.Forms.RadioButton();
            this.radMonth = new System.Windows.Forms.RadioButton();
            this.radDate = new System.Windows.Forms.RadioButton();
            this.monDate = new System.Windows.Forms.MonthCalendar();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotalRow = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvData = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblUser = new System.Windows.Forms.Label();
            this.lblExport = new System.Windows.Forms.Label();
            this.proExport = new System.Windows.Forms.ProgressBar();
            this.timMonitor = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.monDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTotalRow);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lsvData);
            this.groupBox1.Location = new System.Drawing.Point(17, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(864, 495);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.proExport);
            this.groupBox2.Controls.Add(this.lblExport);
            this.groupBox2.Controls.Add(this.btnExport);
            this.groupBox2.Controls.Add(this.radAll);
            this.groupBox2.Controls.Add(this.radMonth);
            this.groupBox2.Controls.Add(this.radDate);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(621, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 237);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            this.groupBox2.Visible = false;
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(17, 186);
            this.btnExport.Margin = new System.Windows.Forms.Padding(4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(193, 44);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // radAll
            // 
            this.radAll.AutoSize = true;
            this.radAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAll.Location = new System.Drawing.Point(17, 86);
            this.radAll.Name = "radAll";
            this.radAll.Size = new System.Drawing.Size(91, 21);
            this.radAll.TabIndex = 2;
            this.radAll.Text = "Everything";
            this.radAll.UseVisualStyleBackColor = true;
            this.radAll.CheckedChanged += new System.EventHandler(this.radAll_CheckedChanged);
            // 
            // radMonth
            // 
            this.radMonth.AutoSize = true;
            this.radMonth.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radMonth.Location = new System.Drawing.Point(17, 59);
            this.radMonth.Name = "radMonth";
            this.radMonth.Size = new System.Drawing.Size(186, 21);
            this.radMonth.TabIndex = 1;
            this.radMonth.Text = "by Selected Month && Year";
            this.radMonth.UseVisualStyleBackColor = true;
            this.radMonth.CheckedChanged += new System.EventHandler(this.radMonth_CheckedChanged);
            // 
            // radDate
            // 
            this.radDate.AutoSize = true;
            this.radDate.Checked = true;
            this.radDate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radDate.Location = new System.Drawing.Point(17, 32);
            this.radDate.Name = "radDate";
            this.radDate.Size = new System.Drawing.Size(127, 21);
            this.radDate.TabIndex = 0;
            this.radDate.TabStop = true;
            this.radDate.Text = "by Selected Date";
            this.radDate.UseVisualStyleBackColor = true;
            this.radDate.CheckedChanged += new System.EventHandler(this.radDate_CheckedChanged);
            // 
            // monDate
            // 
            this.monDate.Location = new System.Drawing.Point(621, 26);
            this.monDate.Margin = new System.Windows.Forms.Padding(12);
            this.monDate.MaxSelectionCount = 1;
            this.monDate.Name = "monDate";
            this.monDate.TabIndex = 18;
            this.monDate.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monDate_DateChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(861, 670);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Total";
            // 
            // txtTotalRow
            // 
            this.txtTotalRow.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalRow.Location = new System.Drawing.Point(923, 664);
            this.txtTotalRow.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalRow.MaxLength = 5;
            this.txtTotalRow.Name = "txtTotalRow";
            this.txtTotalRow.ReadOnly = true;
            this.txtTotalRow.Size = new System.Drawing.Size(75, 23);
            this.txtTotalRow.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(723, 668);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "-";
            // 
            // lsvData
            // 
            this.lsvData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvData.FullRowSelect = true;
            this.lsvData.GridLines = true;
            this.lsvData.Location = new System.Drawing.Point(9, 26);
            this.lsvData.Margin = new System.Windows.Forms.Padding(4);
            this.lsvData.MultiSelect = false;
            this.lsvData.Name = "lsvData";
            this.lsvData.Size = new System.Drawing.Size(596, 461);
            this.lsvData.TabIndex = 9;
            this.lsvData.UseCompatibleStateImageBehavior = false;
            this.lsvData.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Ticket Number";
            this.columnHeader1.Width = 112;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Transaction Length";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 207;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Transaction Date";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 133;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Transaction Time";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 138;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(839, -5);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(0, 17);
            this.lblUser.TabIndex = 1;
            this.lblUser.Visible = false;
            // 
            // lblExport
            // 
            this.lblExport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExport.Location = new System.Drawing.Point(6, 129);
            this.lblExport.Name = "lblExport";
            this.lblExport.Size = new System.Drawing.Size(215, 22);
            this.lblExport.TabIndex = 20;
            this.lblExport.Text = "Export Data is being prepared...";
            this.lblExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExport.Visible = false;
            // 
            // proExport
            // 
            this.proExport.Location = new System.Drawing.Point(17, 159);
            this.proExport.Name = "proExport";
            this.proExport.Size = new System.Drawing.Size(193, 23);
            this.proExport.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.proExport.TabIndex = 21;
            this.proExport.Visible = false;
            // 
            // timMonitor
            // 
            this.timMonitor.Enabled = true;
            this.timMonitor.Interval = 1000;
            this.timMonitor.Tick += new System.EventHandler(this.timMonitor_Tick);
            // 
            // frmAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(894, 510);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmAudit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audit Trail";
            this.Load += new System.EventHandler(this.frmAudit_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTotalRow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lsvData;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.MonthCalendar monDate;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        public System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radAll;
        private System.Windows.Forms.RadioButton radMonth;
        private System.Windows.Forms.RadioButton radDate;
        private System.Windows.Forms.ProgressBar proExport;
        private System.Windows.Forms.Label lblExport;
        private System.Windows.Forms.Timer timMonitor;
    }
}