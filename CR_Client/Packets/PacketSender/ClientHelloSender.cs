using CR_Client.Enums;
using CR_Client.Packets.Messages.Client;
using CR_Client.Tools;
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
        internal const int Key_Version = 11;
        internal const int Major_Version = 3;
        internal const int Minor_Version = 0;
        internal const int Build_Version = 377;
        internal const string Hash = "a4e1c4d3eb2e38c13b7cff4962938abfc4b65a0c";
        internal const int DeviceType = (int)DeviceInfo.DeviceType.Android;
        internal const int AppStore = (int)DeviceInfo.AppStore.playStore;
        static List<byte> Packet = ClientHello.BuildPacket(Packet_ID, 1, Key_Version, Major_Version, Minor_Version, Build_Version, Hash, DeviceType, AppStore);
        public static void SendClientHello(Socket sck)
        {
            //PacketDumper.DumpDecrypted(Emsg.ClientHello.ToString(), Packet.ToArray());
            sck.Send(Packet.ToArray());
        }
    }
}
