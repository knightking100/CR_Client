using CR_Client.Enums;
using CR_Client.Packets.Messages.Client;
using CR_Client;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System;
using CR_Client.Cryptography;
using Newtonsoft.Json;
using CR_Client.Packets.Cryptography;

namespace CR_Client.PacketSender
{
    class ClientLoginSender
    {
        internal const int Packet_ID = (int)Emsg.ClientLogin;
        internal const bool id_unsigned = false;
        internal const int Protocol = 1;
        internal const int Key_Version = 2;
        internal const int Major_Version = 3;
        internal const int Minor_Version = 0;
        internal const int Build_Version = 377;
        internal const byte emptyByte1 = new byte();
        internal const byte emptyByte2 = new byte();
        private static byte preferredLanguage = new byte();
        private static byte advertisingEnabled = new byte();
        internal const string Hash = "622384571aafa79a8453424fb4907c5f1e4268ce";
        static List<byte> Packet = ClientLogin.BuildPacket(1, "622384571aafa79a8453424fb4907c5f1e4268ce", Major_Version,Minor_Version,Build_Version,Hash,"", "7ed2508c74ed4115", "","GT-S7270", "462e6d36-797e-4670-a5c3-b21ca6f9dfad","4.4.4","1","", "7ed2508c74ed4115", "en-US",emptyByte1,preferredLanguage,"",advertisingEnabled,"",2,"","","","",emptyByte2);
        public static void SendClientLogin(Socket sck)
        {
            //byte[] encryptedPacket = Crypto.Encrypt(Packet.ToArray(),Keys.NonceKey,Keys.PrivateKey,Keys.PublicKey);
            sck.Send(Packet.ToArray());
            //sck.Send(encryptedPacket);
        }
    }
}
