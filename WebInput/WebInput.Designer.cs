namespace WebInput
{
    partial class frmWebInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebInput));
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.btnSwitch = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.TaskbarIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lblIP = new System.Windows.Forms.Label();
            this.MainStatusStrip = new System.Windows.Forms.StatusStrip();
            this.TCMCredit = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectedUserCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.TaskbarIconMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuToggle = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainStatusStrip.SuspendLayout();
            this.TaskbarIconMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(5, 19);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(125, 18);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Server Status:";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.Location = new System.Drawing.Point(177, 19);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(36, 18);
            this.lblServerStatus.TabIndex = 1;
            this.lblServerStatus.Text = "Off";
            // 
            // btnSwitch
            // 
            this.btnSwitch.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitch.Location = new System.Drawing.Point(12, 91);
            this.btnSwitch.Name = "btnSwitch";
            this.btnSwitch.Size = new System.Drawing.Size(166, 28);
            this.btnSwitch.TabIndex = 4;
            this.btnSwitch.Text = "Turn On";
            this.btnSwitch.UseVisualStyleBackColor = true;
            this.btnSwitch.Click += new System.EventHandler(this.btnSwitch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(184, 91);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(92, 28);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // TaskbarIcon
            // 
            this.TaskbarIcon.ContextMenuStrip = this.TaskbarIconMenu;
            this.TaskbarIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TaskbarIcon.Icon")));
            this.TaskbarIcon.Text = "Web Input Server";
            this.TaskbarIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TaskbarIconMenu_MouseClick);
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblIP.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIP.ForeColor = System.Drawing.Color.Navy;
            this.lblIP.Location = new System.Drawing.Point(5, 51);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(63, 18);
            this.lblIP.TabIndex = 7;
            this.lblIP.Text = "http://";
            this.lblIP.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblIP.Visible = false;
            this.lblIP.Click += new System.EventHandler(this.lblIP_Click);
            // 
            // MainStatusStrip
            // 
            this.MainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TCMCredit,
            this.ConnectedUserCount});
            this.MainStatusStrip.Location = new System.Drawing.Point(0, 129);
            this.MainStatusStrip.Name = "MainStatusStrip";
            this.MainStatusStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.MainStatusStrip.Size = new System.Drawing.Size(299, 22);
            this.MainStatusStrip.TabIndex = 8;
            this.MainStatusStrip.Text = "statusStrip1";
            // 
            // TCMCredit
            // 
            this.TCMCredit.ForeColor = System.Drawing.Color.Maroon;
            this.TCMCredit.LinkColor = System.Drawing.Color.Maroon;
            this.TCMCredit.Name = "TCMCredit";
            this.TCMCredit.Size = new System.Drawing.Size(89, 17);
            this.TCMCredit.Text = "TheyConfuse.me";
            this.TCMCredit.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.TCMCredit.Click += new System.EventHandler(this.TCMCredit_Click);
            // 
            // ConnectedUserCount
            // 
            this.ConnectedUserCount.Name = "ConnectedUserCount";
            this.ConnectedUserCount.Size = new System.Drawing.Size(0, 17);
            this.ConnectedUserCount.Visible = false;
            // 
            // TaskbarIconMenu
            // 
            this.TaskbarIconMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToggle,
            this.MenuExit});
            this.TaskbarIconMenu.Name = "TaskbarIconMenu";
            this.TaskbarIconMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // MenuToggle
            // 
            this.MenuToggle.Name = "MenuToggle";
            this.MenuToggle.Size = new System.Drawing.Size(117, 22);
            this.MenuToggle.Text = "&Turn On";
            this.MenuToggle.Click += new System.EventHandler(this.MenuToggle_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(117, 22);
            this.MenuExit.Text = "E&xit";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // frmWebInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 151);
            this.Controls.Add(this.MainStatusStrip);
            this.Controls.Add(this.lblIP);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSwitch);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblStatus);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(307, 178);
            this.MinimumSize = new System.Drawing.Size(307, 178);
            this.Name = "frmWebInput";
            this.Text = "Web Input Server";
            this.Load += new System.EventHandler(this.frmWebInput_Load);
            this.MainStatusStrip.ResumeLayout(false);
            this.MainStatusStrip.PerformLayout();
            this.TaskbarIconMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Button btnSwitch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon TaskbarIcon;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.StatusStrip MainStatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel TCMCredit;
        private System.Windows.Forms.ToolStripStatusLabel ConnectedUserCount;
        private System.Windows.Forms.ContextMenuStrip TaskbarIconMenu;
        private System.Windows.Forms.ToolStripMenuItem MenuToggle;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
    }
}

