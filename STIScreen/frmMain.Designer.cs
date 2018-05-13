namespace STI_Queuing_System
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnQueue = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.menMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.auditTrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerIPAddressesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTransactTime = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.lblCall = new System.Windows.Forms.Label();
            this.lblCallCount = new System.Windows.Forms.Label();
            this.timClock = new System.Windows.Forms.Timer(this.components);
            this.lblClock = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grbMain = new System.Windows.Forms.GroupBox();
            this.menMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnQueue
            // 
            this.btnQueue.Location = new System.Drawing.Point(62, 121);
            this.btnQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(201, 59);
            this.btnQueue.TabIndex = 0;
            this.btnQueue.Text = "Start Queue / Start Timer";
            this.btnQueue.UseVisualStyleBackColor = true;
            this.btnQueue.Click += new System.EventHandler(this.btnQueue_Click);
            // 
            // btnCall
            // 
            this.btnCall.Enabled = false;
            this.btnCall.Location = new System.Drawing.Point(62, 188);
            this.btnCall.Margin = new System.Windows.Forms.Padding(4);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(201, 59);
            this.btnCall.TabIndex = 1;
            this.btnCall.Text = "Call Again";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Visible = false;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // menMain
            // 
            this.menMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menMain.Location = new System.Drawing.Point(0, 0);
            this.menMain.Name = "menMain";
            this.menMain.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menMain.Size = new System.Drawing.Size(699, 25);
            this.menMain.TabIndex = 3;
            this.menMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 19);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.auditTrailToolStripMenuItem,
            this.registerIPAddressesToolStripMenuItem});
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(88, 19);
            this.maintenanceToolStripMenuItem.Text = "&Maintenance";
            // 
            // auditTrailToolStripMenuItem
            // 
            this.auditTrailToolStripMenuItem.Name = "auditTrailToolStripMenuItem";
            this.auditTrailToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.auditTrailToolStripMenuItem.Text = "&Audit Trail";
            // 
            // registerIPAddressesToolStripMenuItem
            // 
            this.registerIPAddressesToolStripMenuItem.Name = "registerIPAddressesToolStripMenuItem";
            this.registerIPAddressesToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.registerIPAddressesToolStripMenuItem.Text = "&Register IP Addresses";
            this.registerIPAddressesToolStripMenuItem.Click += new System.EventHandler(this.registerIPAddressesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutProgramToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(44, 19);
            this.aboutToolStripMenuItem.Text = "&Help";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.helpToolStripMenuItem.Text = "&View Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutProgramToolStripMenuItem
            // 
            this.aboutProgramToolStripMenuItem.Name = "aboutProgramToolStripMenuItem";
            this.aboutProgramToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.aboutProgramToolStripMenuItem.Text = "&About Queuing System";
            this.aboutProgramToolStripMenuItem.Click += new System.EventHandler(this.aboutProgramToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTransactTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblDisplay);
            this.groupBox1.Location = new System.Drawing.Point(360, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 327);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Currently Displayed";
            // 
            // lblTransactTime
            // 
            this.lblTransactTime.Location = new System.Drawing.Point(6, 301);
            this.lblTransactTime.Name = "lblTransactTime";
            this.lblTransactTime.Size = new System.Drawing.Size(312, 23);
            this.lblTransactTime.TabIndex = 17;
            this.lblTransactTime.Text = "0:00:00.00";
            this.lblTransactTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 278);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 23);
            this.label1.TabIndex = 16;
            this.label1.Text = "Average Transaction Time";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Arial Rounded MT Bold", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(6, 21);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(312, 257);
            this.lblDisplay.TabIndex = 15;
            this.lblDisplay.Text = "- - -";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCall
            // 
            this.lblCall.AutoSize = true;
            this.lblCall.Location = new System.Drawing.Point(72, 251);
            this.lblCall.Name = "lblCall";
            this.lblCall.Size = new System.Drawing.Size(146, 17);
            this.lblCall.TabIndex = 5;
            this.lblCall.Text = "Number of Calls Made:";
            this.lblCall.Visible = false;
            // 
            // lblCallCount
            // 
            this.lblCallCount.AutoSize = true;
            this.lblCallCount.Location = new System.Drawing.Point(233, 251);
            this.lblCallCount.Name = "lblCallCount";
            this.lblCallCount.Size = new System.Drawing.Size(15, 17);
            this.lblCallCount.TabIndex = 6;
            this.lblCallCount.Text = "0";
            this.lblCallCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCallCount.Visible = false;
            // 
            // timClock
            // 
            this.timClock.Enabled = true;
            this.timClock.Tick += new System.EventHandler(this.timClock_Tick);
            // 
            // lblClock
            // 
            this.lblClock.Location = new System.Drawing.Point(6, 353);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(342, 17);
            this.lblClock.TabIndex = 7;
            this.lblClock.Text = "label3";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(653, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(0, 17);
            this.lblAddress.TabIndex = 8;
            this.lblAddress.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(366, 353);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 9;
            // 
            // grbMain
            // 
            this.grbMain.Controls.Add(this.lblStatus);
            this.grbMain.Controls.Add(this.btnQueue);
            this.grbMain.Controls.Add(this.btnCall);
            this.grbMain.Controls.Add(this.lblClock);
            this.grbMain.Controls.Add(this.groupBox1);
            this.grbMain.Controls.Add(this.lblCallCount);
            this.grbMain.Controls.Add(this.lblCall);
            this.grbMain.Location = new System.Drawing.Point(4, 32);
            this.grbMain.Name = "grbMain";
            this.grbMain.Size = new System.Drawing.Size(692, 381);
            this.grbMain.TabIndex = 11;
            this.grbMain.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(699, 415);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.menMain);
            this.Controls.Add(this.grbMain);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menMain;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menMain.ResumeLayout(false);
            this.menMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grbMain.ResumeLayout(false);
            this.grbMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQueue;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.MenuStrip menMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditTrailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDisplay;
        private System.Windows.Forms.Label lblTransactTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCall;
        private System.Windows.Forms.Label lblCallCount;
        private System.Windows.Forms.Timer timClock;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.ToolStripMenuItem registerIPAddressesToolStripMenuItem;
        public System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grbMain;
    }
}