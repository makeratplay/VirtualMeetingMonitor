using System;
using System.IO;
using System.Net;

namespace VirtualMeetingMonitor
{
    class IPHeader
    {
        //IP Header fields
        private readonly byte Protocol;                 //Eight bits for the underlying protocol
        private readonly uint SourceIPAddress;        //Thirty two bits for the source IP Address
        private readonly uint DestinationIPAddress;   //Thirty two bits for destination IP Address
                                                 

        private readonly IPAddress localIp;

        public IPHeader(byte[] byBuffer, int nReceived, IPAddress localIp)
        {
            this.localIp = localIp;

            try
            {
                //Create MemoryStream out of the received bytes
                MemoryStream memoryStream = new MemoryStream(byBuffer, 0, nReceived);
                //Next we create a BinaryReader out of the MemoryStream
                BinaryReader binaryReader = new BinaryReader(memoryStream);

                //The first eight bits of the IP header contain the version and
                //header length so we read them
                _ = binaryReader.ReadByte();

                //The next eight bits contain the Differentiated services
                _ = binaryReader.ReadByte();

                //Next sixteen bits hold the total length of the datagram
                _ = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next sixteen have the identification bytes
                _ = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next sixteen bits contain the flags and fragmentation offset
                _ = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next eight bits have the TTL value
                _ = binaryReader.ReadByte();

                //Next eight represnts the protocol encapsulated in the datagram
                Protocol = binaryReader.ReadByte();

                //Next sixteen bits contain the checksum of the header
                _ = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next thirty two bits have the source IP address
                SourceIPAddress = (uint)(binaryReader.ReadInt32());

                //Next thirty two hold the destination IP address
                DestinationIPAddress = (uint)(binaryReader.ReadInt32());
            }
            catch (Exception )
            {
            }
        }

        public bool IsTCP()
        {
            return Protocol == 6;
        }

        public bool IsUDP()
        {
            return Protocol == 17;
        }

        public IPAddress SourceAddress
        {
            get
            {
                return new IPAddress(SourceIPAddress);
            }
        }

        public IPAddress DestinationAddress
        {
            get
            {
                return new IPAddress(DestinationIPAddress);
            }
        }

        public bool IsMulticast()
        {
            bool retVal = false;
            // Addresses starting with a number between 224 and 239 are used for IP multicast
            if (DestinationAddress.GetAddressBytes()[0] >= 224 && DestinationAddress.GetAddressBytes()[0] <= 239)
            {
                retVal = true;
            }
            return retVal;
        }

        public bool IsBroadcast()
        {
            bool retVal = false;
            // Addresses 255.255.255.255 is broadcast
            if (DestinationAddress.ToString() == "255.255.255.255")
            {
                retVal = true;
            }
            return retVal;
        }

        public bool InBound()
        {
            bool retVal = false;
            if (DestinationAddress.ToString() == localIp.ToString())
            {
                retVal = true;
            }
            return retVal;
        }
    }
}
