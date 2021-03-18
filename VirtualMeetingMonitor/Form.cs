using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VirtualMeetingMonitor
{
    public partial class Form : System.Windows.Forms.Form
    {
        private OnAirSign onAirSign = new OnAirSign();
        private Network network = new Network();
        private VirtualMeeting meeting = new VirtualMeeting();
        Timer timer = new Timer();
        string LogFileName = "meetings.txt";



        public Form()
        {
            InitializeComponent();

            notifyIcon.Text = this.Text;
            notifyIcon.ContextMenuStrip = contextMenuStrip;

            timer.Interval = 1000;
            timer.Enabled = true;
            timer.Tick += new System.EventHandler(OnTimerEvent);

            network.OutsideUDPTafficeReceived += Network_OutsideUDPTafficeReceived;
            network.StartListening();

            meeting.OnMeetingStarted += Meeting_OnMeetingStarted;
            meeting.OnMeetingEnded += Meeting_OnMeetingEnded;

            // init the UI text
            meetingTxt.Text = "";
            startedTxt.Text = "";
            IpTxt.Text = "";
            EnedTxt.Text = "";
            InboundTxt.Text = "";
            OutboundTxt.Text = "";
            TotalTxt.Text = "";
            this.BackColor = Color.DarkGray;
        }

        private void Network_OutsideUDPTafficeReceived(IPHeader ipHeader)
        {
            meeting.ReceivedUDP(ipHeader);
        }

        private void Meeting_OnMeetingStarted()
        {
            byte red = 0;
            byte green = 255;
            byte blue = 255;

            if (meeting.IsTeamsMeeting())
            {
                red = 0;
                green = 0;
                blue = 255;
            }
            else if (meeting.IsWebExMeeting())
            {
                red = 0;
                green = 255;
                blue = 0;
            }
            else if (meeting.IsZoomMeeting())
            {
                red = 255;
                green = 0;
                blue = 0;
            }

            onAirSign.TurnOn(red, green, blue);
            LogMeeting("Started");
            this.BackColor = Color.Green;

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));

            meetingTxt.Text = meeting.GetMeetingType();
            startedTxt.Text = DateTime.Now.ToString("MM/dd H:mm:ss");
            IpTxt.Text = meeting.GetIP();
            EnedTxt.Text = "";
        }

        private void Meeting_OnMeetingEnded()
        {
            onAirSign.TurnOff();
            LogMeeting("Ended  ");
            this.BackColor = Color.DarkGray;

            EnedTxt.Text = DateTime.Now.ToString("MM/dd H:mm:ss");

            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
        }

        private void LogMeeting(string Msg)
        {
            string logEntry = $"{DateTime.Now:MM/dd H:mm:ss}: {Msg} - {meeting.GetIP()} {meeting.GetMeetingType()}";
            using (StreamWriter w = File.AppendText( LogFileName ))
            {
                w.WriteLine(logEntry);
            }
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Show();
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
        }

        private void onAirOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onAirSign.TurnOn(0, 255, 255);
        }

        private void onAirOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            onAirSign.TurnOff();
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            InboundTxt.Text = meeting.GetUdpInbound().ToString();
            OutboundTxt.Text = meeting.GetUdpOutbound().ToString();
            TotalTxt.Text = meeting.GetUdpTotal().ToString();
            meeting.CheckMeetingStatus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            network.Stop();
        }

        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo pi = new ProcessStartInfo(LogFileName);
            pi.Arguments = Path.GetFileName(LogFileName);
            pi.UseShellExecute = true;
            pi.WorkingDirectory = Path.GetDirectoryName(LogFileName);
            pi.FileName = LogFileName;
            pi.Verb = "EDIT";

            System.Diagnostics.Process.Start(pi);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                //notifyIcon.Visible = true;
            }
        }
    }
}
