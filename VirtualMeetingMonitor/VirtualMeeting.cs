using System;

namespace VirtualMeetingMonitor
{
    

    class VirtualMeeting
    {
        string[] ZoomIps = { "3.7.", "3.21.", "3.22.", "3.23.", "3.25.", "3.80.", "3.96.", "3.101.", "3.104.", "3.120.", "3.127.", "3.208.",
                             "3.211.", "3.235.", "4.34.", "4.35.", "8.5.", "13.52.", "18.157.", "18.205.", "50.239.", "52.61.", "52.81.",
                             "52.202.", "52.215.", "64.125.", "64.211.", "65.39.", "69.174.", "99.79.", "101.36.", "103.122.", "111.33.",
                             "115.110.", "115.114.", "120.29.", "129.151.", "129.159.", "130.61.", "134.224.", "140.238.", "144.195.", "147.124.",
                             "149.137.", "152.67.", "158.101.", "160.1.", "161.189.", "161.199.", "162.12.", "162.255.", "165.254.", "168.138.",
                             "170.114.", "173.231.", "192.204.", "193.122.", "193.123.", "198.251.", "202.177.", "204.80.", "204.141.", "207.226.",
                             "209.9.", "209.9.", "213.19.", "213.244.", "221.122.", "221.123." };

        string[] MSTeamsIps = { "13.107.", "52.112.", "52.120.", "52.114.", "52.113.", "52.115." };

        string[] WebExIps = { "62.109.", "64.68.", "66.114.", "66.163.", "69.26.", "114.29.", "150.253.", "170.72.", "170.133.", "173.39.", "173.243.",
                              "207.182.", "209.197.", "210.4.", "216.151." };

        string[] DiscordIps = { "162.245.", "213.179." };

        private string MeetingIp = "";
        private bool InMeeting = false;
        private int UdpTotal = 0;
        private int UdpInbound = 0;
        private int UdpOutbound = 0;
        private int Seconds = 0;
        private int ThreshHoldPackets = 1;
        private int ThreshHoldSeconds = 5;

        public delegate void Notify();  // delegate

        public event Notify OnMeetingStarted;
        public event Notify OnMeetingEnded;

        public void ReceivedUDP(IPHeader ipHeader)
        {
            UdpTotal++;
            if (ipHeader.InBound())
            {
                MeetingIp = ipHeader.SourceAddress.ToString();
                UdpInbound++;
            }
            else
            {
                MeetingIp = ipHeader.DestinationAddress.ToString();
                UdpOutbound++;
            }
        }

        public void CheckMeetingStatus()
        {
            Console.WriteLine("udpCount: " + UdpTotal);

            if (UdpTotal >= ThreshHoldPackets)
            {
                Seconds = 0;
                if (InMeeting == false )
                {
                    InMeeting = true;
                    OnMeetingStarted?.Invoke();
                }
            }
            else
            {
                Seconds++;
                if (InMeeting == true && Seconds >= ThreshHoldSeconds)
                {
                    InMeeting = false;
                    OnMeetingEnded?.Invoke();
                }
            }
            RestUdpCounts();
        }

        public string GetMeetingType()
        {
            string RetVal = "Unknown";

            if (IsTeamsMeeting())
            { 
                RetVal = "Teams";
            }
            else if ( IsWebExMeeting())
            {
                RetVal = "WebEx";
            }
            else if ( IsZoomMeeting() )
            {
                RetVal = "Zoom";
            }
            else if (IsDiscordMeeting() )
            {
                RetVal = "Discord";
            }
            return RetVal;
        }

        public bool IsTeamsMeeting()
        {
            bool retVal = false;
            for (int i = 0; i < MSTeamsIps.Length; i++)
            {
                if (MeetingIp.StartsWith(MSTeamsIps[i]))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        public bool IsWebExMeeting()
        {
            bool retVal = false;
            for (int i = 0; i < WebExIps.Length; i++)
            {
                if (MeetingIp.StartsWith(WebExIps[i]))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        public bool IsZoomMeeting()
        {
            bool retVal = false;
            for (int i = 0; i < ZoomIps.Length; i++)
            {
                if (MeetingIp.StartsWith(ZoomIps[i]))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        public bool IsDiscordMeeting()
        {
            bool retVal = false;
            for (int i = 0; i < DiscordIps.Length; i++)
            {
                if (MeetingIp.StartsWith(DiscordIps[i]))
                {
                    retVal = true;
                    break;
                }
            }
            return retVal;
        }

        public string GetIP()
        {
            return MeetingIp;
        }

        public int GetUdpTotal()
        {
            return UdpTotal;
        }

        public int GetUdpInbound()
        {
            return UdpInbound;
        }

        public int GetUdpOutbound()
        {
            return UdpOutbound;
        }

        private void RestUdpCounts()
        {
            UdpInbound = 0;
            UdpOutbound = 0;
            UdpTotal = 0;
        }

    }
}
