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
        public static void DumpEncrypted(string packetName,byte[] data)
        {
            string path = Environment.CurrentDirectory;
            string file = path + $"/Packets/Encrypted/{packetName}.txt";
            File.SetAttributes(file, FileAttributes.Normal);
            string Data = Encoding.ASCII.GetString(data);
            try
            {
                File.AppendAllText(path, Data);
            }
            catch
            {
                Directory.CreateDirectory(path);
                File.Create(file);
                File.AppendAllText(path, Data);
            }
        }
        public static void DumpDecrypted(string packetName, byte[] data)
        {
            string path = Environment.CurrentDirectory;
            string file = path + $"/Packets/Decrypted/{packetName}.txt";
            File.SetAttributes(file, FileAttributes.Normal);
            string Data = Encoding.ASCII.GetString(data);
            try
            {
                File.AppendAllText(path, Data);
            }
            catch
            {
                Directory.CreateDirectory(path);
                File.Create(file);
                File.AppendAllText(path, Data);
            }
        }
    }
}
