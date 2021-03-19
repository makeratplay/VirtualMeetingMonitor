using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;

namespace VirtualMeetingMonitor
{
    class Network
    {
        private Socket mainSocket;
        private IPAddress localIp;
        private string subnetMask = "";
        private readonly byte[] byteData = new byte[65507];

        public delegate void Notify(IPHeader ipHeader);  // delegate

        public event Notify OutsideUDPTafficeReceived;


        public void StartListening()
        {

            IPHostEntry HosyEntry = Dns.GetHostEntry((Dns.GetHostName()));
            if (HosyEntry.AddressList.Any())
            {
                foreach (IPAddress ip in HosyEntry.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        localIp = ip;
                        break;
                    }
                }
            }

            //For sniffing the socket to capture the packets has to be a raw socket, with the
            //address family being of type internetwork, and protocol being IP
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

            //Bind the socket to the selected IP address
            mainSocket.Bind(new IPEndPoint(localIp, 0));
            subnetMask = $"{localIp.GetAddressBytes()[0]}.{localIp.GetAddressBytes()[1]}.{localIp.GetAddressBytes()[2]}.";

            //Set the socket  options
            mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            byte[] True = new byte[] { 1, 0, 0, 0 };
            byte[] Out = new byte[] { 1, 0, 0, 0 }; //Capture outgoing packets

            //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
            // The current user must belong to the Administrators group on the local computer
            mainSocket.IOControl(IOControlCode.ReceiveAll, True, Out);

            //Start receiving the packets asynchronously
            mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, null);
        }

        public void Stop()
        {
            mainSocket.Close();
        }

        private void OnReceive(IAsyncResult ar)
        {
            try
            {
                int nReceived = mainSocket.EndReceive(ar);
                ParseData(byteData, nReceived);
            }
            catch (Exception ex)
            {
                Console.WriteLine("OnReceive Exception: " + ex.Message);
            }

            try
            {
                //Another call to BeginReceive so that we continue to receive the incoming packets
                mainSocket.BeginReceive(byteData, 0, byteData.Length, SocketFlags.None, OnReceive, null);
            }
            catch (ObjectDisposedException)
            {
            }
        }

        private void ParseData(byte[] byteData, int nReceived)
        {
            IPHeader ipHeader = new IPHeader(byteData, nReceived, localIp);
            if (isOutsideUDPTaffice(ipHeader))
            {
                OutsideUDPTafficeReceived?.Invoke(ipHeader);
            }
        }


        private bool isOutsideUDPTaffice(IPHeader ipHeader)
        {
            bool retVal = false;
            if (ipHeader.IsUDP() && !ipHeader.IsMulticast() && !ipHeader.IsBroadcast())
            {
                if (ipHeader.SourceAddress.Equals(localIp) || ipHeader.DestinationAddress.Equals(localIp))
                {
                    if (ipHeader.SourceAddress.ToString().StartsWith(subnetMask) == false || ipHeader.DestinationAddress.ToString().StartsWith(subnetMask) == false)
                    {
                        retVal = true;
                    }
                }
            }
            return retVal;
        }


    }
}
