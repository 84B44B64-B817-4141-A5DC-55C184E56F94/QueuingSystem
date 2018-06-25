namespace STI_Queuing_System
{
    partial class frmMini
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMini));
            this.btnMain = new System.Windows.Forms.Button();
            this.tipMini = new System.Windows.Forms.ToolTip(this.components);
            this.btnQueue = new System.Windows.Forms.Button();
            this.btnCall = new System.Windows.Forms.Button();
            this.lblDisplay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnMain
            // 
            this.btnMain.BackColor = System.Drawing.Color.Transparent;
            this.btnMain.BackgroundImage = global::STI_Queuing_System.Properties.Resources.Left;
            this.btnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMain.Location = new System.Drawing.Point(1, 179);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(24, 20);
            this.btnMain.TabIndex = 0;
            this.btnMain.UseVisualStyleBackColor = false;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnQueue
            // 
            this.btnQueue.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQueue.Location = new System.Drawing.Point(21, 106);
            this.btnQueue.Name = "btnQueue";
            this.btnQueue.Size = new System.Drawing.Size(206, 31);
            this.btnQueue.TabIndex = 1;
            this.btnQueue.Text = "Start Queue / Start Timer";
            this.btnQueue.UseVisualStyleBackColor = true;
            this.btnQueue.Click += new System.EventHandler(this.btnQueue_Click);
            // 
            // btnCall
            // 
            this.btnCall.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCall.Location = new System.Drawing.Point(21, 143);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(206, 31);
            this.btnCall.TabIndex = 2;
            this.btnCall.Text = "Call Again";
            this.btnCall.UseVisualStyleBackColor = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // lblDisplay
            // 
            this.lblDisplay.Font = new System.Drawing.Font("Arial Rounded MT Bold", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplay.Location = new System.Drawing.Point(21, 6);
            this.lblDisplay.Name = "lblDisplay";
            this.lblDisplay.Size = new System.Drawing.Size(206, 97);
            this.lblDisplay.TabIndex = 16;
            this.lblDisplay.Text = "- - -";
            this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmMini
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Yellow;
            this.ClientSize = new System.Drawing.Size(250, 200);
            this.ControlBox = false;
            this.Controls.Add(this.lblDisplay);
            this.Controls.Add(this.btnCall);
            this.Controls.Add(this.btnQueue);
            this.Controls.Add(this.btnMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmMini";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMini_FormClosing);
            this.Load += new System.EventHandler(this.frmMini_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.ToolTip tipMini;
        private System.Windows.Forms.Button btnQueue;
        private System.Windows.Forms.Button btnCall;
        private System.Windows.Forms.Label lblDisplay;
    }
}