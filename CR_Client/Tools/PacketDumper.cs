using CR_Client.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Client.Tools
{
    public class PacketDumper
    {
        public static void Dump(string packetName,byte[] data)
        {
            string path = Environment.CurrentDirectory + $"/Packets/{packetName}.txt";
            string Data = Encoding.ASCII.GetString(data);
            File.AppendAllText(path, Data);
        }
    }
}
