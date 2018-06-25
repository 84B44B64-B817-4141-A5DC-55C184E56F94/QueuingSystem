namespace STI_Queuing_System
{
    partial class frmDisplay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDisplay));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCashTime = new System.Windows.Forms.Label();
            this.lblCashier = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblRegTime = new System.Windows.Forms.Label();
            this.lblRegistrar = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblAccTime = new System.Windows.Forms.Label();
            this.lblAccounting = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblNews = new System.Windows.Forms.Label();
            this.timerNews = new System.Windows.Forms.Timer(this.components);
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerBlink = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lblCashTime);
            this.groupBox1.Controls.Add(this.lblCashier);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Bernard MT Condensed", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 540);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Window 3";
            // 
            // lblCashTime
            // 
            this.lblCashTime.Font = new System.Drawing.Font("Bernard MT Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashTime.Location = new System.Drawing.Point(0, 491);
            this.lblCashTime.Name = "lblCashTime";
            this.lblCashTime.Size = new System.Drawing.Size(440, 46);
            this.lblCashTime.TabIndex = 24;
            this.lblCashTime.Text = "00:00:00.00";
            this.lblCashTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCashTime.Visible = false;
            // 
            // lblCashier
            // 
            this.lblCashier.Font = new System.Drawing.Font("Arial Rounded MT Bold", 140.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashier.Location = new System.Drawing.Point(0, 162);
            this.lblCashier.Name = "lblCashier";
            this.lblCashier.Size = new System.Drawing.Size(440, 375);
            this.lblCashier.TabIndex = 13;
            this.lblCashier.Text = "---";
            this.lblCashier.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(0, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(440, 96);
            this.label1.TabIndex = 12;
            this.label1.Text = "Cashier";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblRegTime);
            this.groupBox2.Controls.Add(this.lblRegistrar);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Bernard MT Condensed", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(463, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(440, 540);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Window 2";
            // 
            // lblRegTime
            // 
            this.lblRegTime.Font = new System.Drawing.Font("Bernard MT Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegTime.Location = new System.Drawing.Point(6, 491);
            this.lblRegTime.Name = "lblRegTime";
            this.lblRegTime.Size = new System.Drawing.Size(440, 46);
            this.lblRegTime.TabIndex = 26;
            this.lblRegTime.Text = "00:00:00.00";
            this.lblRegTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblRegTime.Visible = false;
            // 
            // lblRegistrar
            // 
            this.lblRegistrar.Font = new System.Drawing.Font("Arial Rounded MT Bold", 140.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegistrar.Location = new System.Drawing.Point(6, 162);
            this.lblRegistrar.Name = "lblRegistrar";
            this.lblRegistrar.Size = new System.Drawing.Size(428, 375);
            this.lblRegistrar.TabIndex = 14;
            this.lblRegistrar.Text = "---";
            this.lblRegistrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Lucida Bright", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(1, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(434, 96);
            this.label2.TabIndex = 13;
            this.label2.Text = "Registrar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.lblAccTime);
            this.groupBox3.Controls.Add(this.lblAccounting);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("Bernard MT Condensed", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(914, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(440, 540);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Window 1";
            // 
            // lblAccTime
            // 
            this.lblAccTime.Font = new System.Drawing.Font("Bernard MT Condensed", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccTime.Location = new System.Drawing.Point(1, 491);
            this.lblAccTime.Name = "lblAccTime";
            this.lblAccTime.Size = new System.Drawing.Size(440, 46);
            this.lblAccTime.TabIndex = 28;
            this.lblAccTime.Text = "00:00:00.00";
            this.lblAccTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAccTime.Visible = false;
            // 
            // lblAccounting
            // 
            this.lblAccounting.Font = new System.Drawing.Font("Arial Rounded MT Bold", 140.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccounting.Location = new System.Drawing.Point(0, 162);
            this.lblAccounting.Name = "lblAccounting";
            this.lblAccounting.Size = new System.Drawing.Size(434, 375);
            this.lblAccounting.TabIndex = 15;
            this.lblAccounting.Text = "---";
            this.lblAccounting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Lucida Bright", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(0, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(434, 96);
            this.label3.TabIndex = 22;
            this.label3.Text = "Accounting";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblClock
            // 
            this.lblClock.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClock.BackColor = System.Drawing.Color.Transparent;
            this.lblClock.Font = new System.Drawing.Font("Elephant", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClock.ForeColor = System.Drawing.Color.Black;
            this.lblClock.Location = new System.Drawing.Point(12, 654);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(1342, 88);
            this.lblClock.TabIndex = 2;
            this.lblClock.Text = "00:00";
            this.lblClock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.LightCyan;
            this.pictureBox1.Location = new System.Drawing.Point(-2, 558);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1373, 69);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // lblNews
            // 
            this.lblNews.AutoSize = true;
            this.lblNews.BackColor = System.Drawing.Color.LightCyan;
            this.lblNews.Font = new System.Drawing.Font("Lucida Fax", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNews.Location = new System.Drawing.Point(1360, 569);
            this.lblNews.Name = "lblNews";
            this.lblNews.Size = new System.Drawing.Size(3963, 43);
            this.lblNews.TabIndex = 4;
            this.lblNews.Text = resources.GetString("lblNews.Text");
            // 
            // timerNews
            // 
            this.timerNews.Enabled = true;
            this.timerNews.Interval = 30;
            this.timerNews.Tick += new System.EventHandler(this.timerNews_Tick);
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerBlink
            // 
            this.timerBlink.Enabled = true;
            this.timerBlink.Tick += new System.EventHandler(this.timerBlink_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 47);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.lblNews);
            this.Controls.Add(this.lblClock);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STI QUEUEING SYSTEM";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblNews;
        private System.Windows.Forms.Timer timerNews;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCashier;
        private System.Windows.Forms.Label lblRegistrar;
        private System.Windows.Forms.Label lblAccounting;
        private System.Windows.Forms.Label lblCashTime;
        private System.Windows.Forms.Label lblRegTime;
        private System.Windows.Forms.Label lblAccTime;
        private System.Windows.Forms.Timer timerBlink;
        private System.Windows.Forms.Button button1;
    }
}

