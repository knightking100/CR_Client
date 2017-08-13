using CR_Client.Enums;
using CR_Client.Packets.Cryptography;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Client.Packets
{
    public class MessageProcessor
    {
        public static byte[] ProcessOutgoing(byte[] message,int packetID)
        {
            byte[] cipher = Encryptor.Encrypt(message);
            var messageLength = BitConverter.GetBytes(cipher.Length);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(messageLength);
            }
            Stream stream = new MemoryStream();
            var writer = new MessageWriter(stream);
            writer.Write(packetID);
            writer.Write(messageLength, 1, 3);
            writer.Write(0);
            writer.Write(cipher);
            MemoryStream processedMessage = new MemoryStream();
            stream.CopyTo(processedMessage);
            return processedMessage.ToArray();
        }
    }
}
