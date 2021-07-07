using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

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


        public async Task StartListening()
        {
            SetupLocalIp();
            ConfigureSocket();

            //Start receiving the packets asynchronously
            await ProcessPackets();
        }

        /// <summary>
        /// Use the socket to receive data. Simply loop until the socket is disposed.
        /// </summary>
        /// <returns></returns>
        private async Task ProcessPackets()
        {
            //Declare the buffer outside the loop so that do not recreate it every time we go around the loop.
            ArraySegment<byte> buffer = new ArraySegment<byte>(byteData);

            while (true)
            {
                try
                {
                    // At this point the socket will wait for data to arrive. Awaiting here means
                    // control is returned to the main UI until there is data to process.
                    // This is *not* the same as blocking, but we can use the same mental model
                    // as if it was a blocking call.
                    int bytesReceived = await mainSocket.ReceiveAsync(buffer, SocketFlags.None);
                    ParseData(byteData, bytesReceived);
                }
                catch (ObjectDisposedException)
                {
                    // This exception occurs when the application is stopping and the socket is closed.
                    // This signals that we should exit the loop.
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("OnReceive Exception: " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Configures the listening socket.
        /// </summary>
        private void ConfigureSocket()
        {
            //For sniffing the socket to capture the packets has to be a raw socket, with the
            //address family being of type internetwork, and protocol being IP
            mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

            //Bind the socket to the selected IP address
            mainSocket.Bind(new IPEndPoint(localIp, 0));
            subnetMask = $"{localIp.GetAddressBytes()[0]}.{localIp.GetAddressBytes()[1]}.{localIp.GetAddressBytes()[2]}.";

            //Set the socket  options
            mainSocket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.HeaderIncluded, true);

            byte[] True = new byte[] {1, 0, 0, 0};
            byte[] Out = new byte[] {1, 0, 0, 0}; //Capture outgoing packets

            //Socket.IOControl is analogous to the WSAIoctl method of Winsock 2
            // The current user must belong to the Administrators group on the local computer
            mainSocket.IOControl(IOControlCode.ReceiveAll, True, Out);
        }

        /// <summary>
        /// Set up a local IP address from the list of available addresses.
        /// The first available IPv4 is chosen as the local IP address.
        /// </summary>
        private void SetupLocalIp()
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
        }

        public void Stop()
        {
            mainSocket.Close();
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
