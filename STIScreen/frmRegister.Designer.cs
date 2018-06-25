namespace STI_Queuing_System
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            this.btnSave = new System.Windows.Forms.Button();
            this.radAccounting = new System.Windows.Forms.RadioButton();
            this.radRegistrar = new System.Windows.Forms.RadioButton();
            this.radCashier = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_MAC = new System.Windows.Forms.Label();
            this.lbl_IPAddress = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(12, 150);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // radAccounting
            // 
            this.radAccounting.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radAccounting.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radAccounting.Location = new System.Drawing.Point(6, 30);
            this.radAccounting.Name = "radAccounting";
            this.radAccounting.Size = new System.Drawing.Size(130, 34);
            this.radAccounting.TabIndex = 4;
            this.radAccounting.Text = "Accounting";
            this.radAccounting.UseVisualStyleBackColor = true;
            this.radAccounting.CheckedChanged += new System.EventHandler(this.radAccounting_CheckedChanged);
            // 
            // radRegistrar
            // 
            this.radRegistrar.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radRegistrar.Location = new System.Drawing.Point(6, 60);
            this.radRegistrar.Name = "radRegistrar";
            this.radRegistrar.Size = new System.Drawing.Size(130, 34);
            this.radRegistrar.TabIndex = 5;
            this.radRegistrar.Text = "Registrar";
            this.radRegistrar.UseVisualStyleBackColor = true;
            this.radRegistrar.CheckedChanged += new System.EventHandler(this.radRegistrar_CheckedChanged);
            // 
            // radCashier
            // 
            this.radCashier.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCashier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radCashier.Location = new System.Drawing.Point(6, 90);
            this.radCashier.Name = "radCashier";
            this.radCashier.Size = new System.Drawing.Size(130, 34);
            this.radCashier.TabIndex = 6;
            this.radCashier.Text = "Cashier";
            this.radCashier.UseVisualStyleBackColor = true;
            this.radCashier.CheckedChanged += new System.EventHandler(this.radCashier_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radCashier);
            this.groupBox1.Controls.Add(this.radRegistrar);
            this.groupBox1.Controls.Add(this.radAccounting);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(149, 132);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose user";
            // 
            // lbl_MAC
            // 
            this.lbl_MAC.AutoSize = true;
            this.lbl_MAC.Location = new System.Drawing.Point(117, -4);
            this.lbl_MAC.Name = "lbl_MAC";
            this.lbl_MAC.Size = new System.Drawing.Size(34, 13);
            this.lbl_MAC.TabIndex = 8;
            this.lbl_MAC.Text = "temp";
            this.lbl_MAC.Visible = false;
            // 
            // lbl_IPAddress
            // 
            this.lbl_IPAddress.AutoSize = true;
            this.lbl_IPAddress.Location = new System.Drawing.Point(77, -4);
            this.lbl_IPAddress.Name = "lbl_IPAddress";
            this.lbl_IPAddress.Size = new System.Drawing.Size(34, 13);
            this.lbl_IPAddress.TabIndex = 9;
            this.lbl_IPAddress.Text = "temp";
            this.lbl_IPAddress.Visible = false;
            // 
            // frmRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(176, 191);
            this.Controls.Add(this.lbl_IPAddress);
            this.Controls.Add(this.lbl_MAC);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRegister_FormClosed);
            this.Load += new System.EventHandler(this.frmRegister_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton radAccounting;
        private System.Windows.Forms.RadioButton radRegistrar;
        private System.Windows.Forms.RadioButton radCashier;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.Label lbl_MAC;
        public System.Windows.Forms.Label lbl_IPAddress;
    }
}