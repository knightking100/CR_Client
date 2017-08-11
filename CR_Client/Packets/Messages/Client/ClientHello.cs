using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CR_Client.Packets.Messages.Client
{
    public class ClientHello
    {
        public static List<byte> BuildPacket(ushort id, int protocol, int keyVersion, int majorVersion, int minorVersion, int build, string contentHash, int deviceType, int appStore)
        {
            List<byte> Packet = new List<byte>();
            Packet.AddUShort(id);
            Packet.Add(0);
            Packet.AddUShort(72);
            Packet.AddUShort(1);
            Packet.AddInt(protocol);
            Packet.AddInt(keyVersion);
            Packet.AddInt(majorVersion);
            Packet.AddInt(minorVersion);
            Packet.AddInt(build);
            Packet.AddString(contentHash);
            Packet.AddInt(deviceType);
            Packet.AddInt(appStore);
            return Packet;
        }
    }
}
