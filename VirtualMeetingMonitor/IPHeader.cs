using System;
using System.IO;
using System.Net;

namespace VirtualMeetingMonitor
{
    class IPHeader
    {
        //IP Header fields
        private byte VersionAndHeaderLength;   //Eight bits for version and header length
        private byte DifferentiatedServices;   //Eight bits for differentiated services (TOS)
        private ushort TotalLength;            //Sixteen bits for total length of the datagram (header + message)
        private ushort Identification;         //Sixteen bits for identification
        private ushort FlagsAndOffset;         //Sixteen bits for flags and fragmentation offset
        private byte TTL;                      //Eight bits for TTL (Time To Live)
        private readonly byte Protocol;                 //Eight bits for the underlying protocol
        private short Checksum;                //Sixteen bits containing the checksum of the header (checksum can be negative so taken as short)
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
                VersionAndHeaderLength = binaryReader.ReadByte();

                //The next eight bits contain the Differentiated services
                DifferentiatedServices = binaryReader.ReadByte();

                //Next sixteen bits hold the total length of the datagram
                TotalLength = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next sixteen have the identification bytes
                Identification = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next sixteen bits contain the flags and fragmentation offset
                FlagsAndOffset = (ushort)IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next eight bits have the TTL value
                TTL = binaryReader.ReadByte();

                //Next eight represnts the protocol encapsulated in the datagram
                Protocol = binaryReader.ReadByte();

                //Next sixteen bits contain the checksum of the header
                Checksum = IPAddress.NetworkToHostOrder(binaryReader.ReadInt16());

                //Next thirty two bits have the source IP address
                SourceIPAddress = (uint)(binaryReader.ReadInt32());

                //Next thirty two hold the destination IP address
                DestinationIPAddress = (uint)(binaryReader.ReadInt32());
            }
            catch (Exception )
            {
            }
        }

        public bool IsTCP() => Protocol == 6;

        public bool IsUDP() => Protocol == 17;

        public IPAddress SourceAddress => new IPAddress(SourceIPAddress);

        public IPAddress DestinationAddress => new IPAddress(DestinationIPAddress);

        public bool IsMulticast() => DestinationAddress.GetAddressBytes()[0] >= 224 && DestinationAddress.GetAddressBytes()[0] <= 239;
        
        public bool IsBroadcast() => DestinationAddress.ToString() == "255.255.255.255";

        public bool InBound() => DestinationAddress.ToString() == localIp.ToString();
    }
}
