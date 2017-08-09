using CR_Client.Enums;
using CR_Client.Messages.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CR_Client.PacketSender
{
    class ClientHelloSender
    {
        internal const int Packet_ID = (int)Emsg.ClientHello;
        internal const int Protocol = 1;
        internal const int Key_Version = 2;
        internal const int Major_Version = 1507;
        internal const int Minor_Version = 5;
        internal const int Build_Version = 0;
        internal const string Hash = "";
        static List<byte> Packet = ClientHello.BuildPacket(Packet_ID, 1, Key_Version, Major_Version, Minor_Version, Build_Version, Hash, 2, 2);
        public static void SendClientHello(Socket sck)
        {
            sck.Send(Packet.ToArray());
        }
    }
}
