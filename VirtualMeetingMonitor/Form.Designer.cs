namespace VirtualMeetingMonitor
{
    partial class Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.onAirOnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onAirOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.meetingTxt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.startedTxt = new System.Windows.Forms.Label();
            this.EnedTxt = new System.Windows.Forms.Label();
            this.IpTxt = new System.Windows.Forms.Label();
            this.InboundTxt = new System.Windows.Forms.Label();
            this.OutboundTxt = new System.Windows.Forms.Label();
            this.TotalTxt = new System.Windows.Forms.Label();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onAirOnToolStripMenuItem,
            this.onAirOffToolStripMenuItem,
            this.openLogToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip1";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 92);
            // 
            // onAirOnToolStripMenuItem
            // 
            this.onAirOnToolStripMenuItem.Name = "onAirOnToolStripMenuItem";
            this.onAirOnToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.onAirOnToolStripMenuItem.Text = "On Air - On";
            this.onAirOnToolStripMenuItem.Click += new System.EventHandler(this.onAirOnToolStripMenuItem_Click);
            // 
            // onAirOffToolStripMenuItem
            // 
            this.onAirOffToolStripMenuItem.Name = "onAirOffToolStripMenuItem";
            this.onAirOffToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.onAirOffToolStripMenuItem.Text = "On Air - Off";
            this.onAirOffToolStripMenuItem.Click += new System.EventHandler(this.onAirOffToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // meetingTxt
            // 
            this.meetingTxt.AutoSize = true;
            this.meetingTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.meetingTxt.Location = new System.Drawing.Point(77, 11);
            this.meetingTxt.Name = "meetingTxt";
            this.meetingTxt.Size = new System.Drawing.Size(38, 13);
            this.meetingTxt.TabIndex = 1;
            this.meetingTxt.Text = "Zoom";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Meeting:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Started:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 3;
            this.label5.Text = "Ended:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "IP:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(273, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "UDP Packts";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(261, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Inbound:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(251, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 16);
            this.label9.TabIndex = 7;
            this.label9.Text = "Outbound:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(278, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 16);
            this.label10.TabIndex = 8;
            this.label10.Text = "Total:";
            // 
            // startedTxt
            // 
            this.startedTxt.AutoSize = true;
            this.startedTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startedTxt.Location = new System.Drawing.Point(77, 42);
            this.startedTxt.Name = "startedTxt";
            this.startedTxt.Size = new System.Drawing.Size(95, 13);
            this.startedTxt.TabIndex = 9;
            this.startedTxt.Text = "02/24 11:29:56";
            // 
            // EnedTxt
            // 
            this.EnedTxt.AutoSize = true;
            this.EnedTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnedTxt.Location = new System.Drawing.Point(77, 70);
            this.EnedTxt.Name = "EnedTxt";
            this.EnedTxt.Size = new System.Drawing.Size(95, 13);
            this.EnedTxt.TabIndex = 10;
            this.EnedTxt.Text = "02/24 11:29:56";
            // 
            // IpTxt
            // 
            this.IpTxt.AutoSize = true;
            this.IpTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IpTxt.Location = new System.Drawing.Point(77, 99);
            this.IpTxt.Name = "IpTxt";
            this.IpTxt.Size = new System.Drawing.Size(89, 13);
            this.IpTxt.TabIndex = 11;
            this.IpTxt.Text = "147.124.99.96";
            // 
            // InboundTxt
            // 
            this.InboundTxt.AutoSize = true;
            this.InboundTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InboundTxt.Location = new System.Drawing.Point(326, 40);
            this.InboundTxt.Name = "InboundTxt";
            this.InboundTxt.Size = new System.Drawing.Size(28, 13);
            this.InboundTxt.TabIndex = 12;
            this.InboundTxt.Text = "200";
            // 
            // OutboundTxt
            // 
            this.OutboundTxt.AutoSize = true;
            this.OutboundTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutboundTxt.Location = new System.Drawing.Point(326, 70);
            this.OutboundTxt.Name = "OutboundTxt";
            this.OutboundTxt.Size = new System.Drawing.Size(28, 13);
            this.OutboundTxt.TabIndex = 13;
            this.OutboundTxt.Text = "222";
            // 
            // TotalTxt
            // 
            this.TotalTxt.AutoSize = true;
            this.TotalTxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalTxt.Location = new System.Drawing.Point(326, 100);
            this.TotalTxt.Name = "TotalTxt";
            this.TotalTxt.Size = new System.Drawing.Size(28, 13);
            this.TotalTxt.TabIndex = 14;
            this.TotalTxt.Text = "422";
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.openLogToolStripMenuItem.Text = "Open Log";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(366, 129);
            this.Controls.Add(this.TotalTxt);
            this.Controls.Add(this.OutboundTxt);
            this.Controls.Add(this.InboundTxt);
            this.Controls.Add(this.IpTxt);
            this.Controls.Add(this.EnedTxt);
            this.Controls.Add(this.startedTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.meetingTxt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Virtual Meeting Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem onAirOnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onAirOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.Label meetingTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label startedTxt;
        private System.Windows.Forms.Label EnedTxt;
        private System.Windows.Forms.Label IpTxt;
        private System.Windows.Forms.Label InboundTxt;
        private System.Windows.Forms.Label OutboundTxt;
        private System.Windows.Forms.Label TotalTxt;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
    }
}

