namespace WebInput
{
    partial class QRCode
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
            this.QRPic = new System.Windows.Forms.PictureBox();
            this.UnavailableNotice = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).BeginInit();
            this.SuspendLayout();
            // 
            // QRPic
            // 
            this.QRPic.Location = new System.Drawing.Point(12, 12);
            this.QRPic.Name = "QRPic";
            this.QRPic.Size = new System.Drawing.Size(165, 165);
            this.QRPic.TabIndex = 0;
            this.QRPic.TabStop = false;
            this.QRPic.Visible = false;
            // 
            // UnavailableNotice
            // 
            this.UnavailableNotice.AutoSize = true;
            this.UnavailableNotice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnavailableNotice.ForeColor = System.Drawing.Color.Red;
            this.UnavailableNotice.Location = new System.Drawing.Point(24, 58);
            this.UnavailableNotice.Name = "UnavailableNotice";
            this.UnavailableNotice.Size = new System.Drawing.Size(140, 48);
            this.UnavailableNotice.TabIndex = 1;
            this.UnavailableNotice.Text = "Turn on the service\r\n\r\nand try again.";
            this.UnavailableNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.UnavailableNotice.Visible = false;
            // 
            // QRCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(192, 191);
            this.Controls.Add(this.UnavailableNotice);
            this.Controls.Add(this.QRPic);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "QRCode";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scan QRCode";
            this.Load += new System.EventHandler(this.QRCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QRPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox QRPic;
        private System.Windows.Forms.Label UnavailableNotice;
    }
}