using Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CR_Proxy
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "CR Proxy";
            //ConnectToCRServer();
            ConnectToCRServerWithDns();
        }

        private static void ConnectToCRServerWithDns()
        {
            try
            {
                Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress[] IP = Dns.GetHostAddresses("192.168.0.101"); Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sck.Connect(IP[0], 9339);
                Console.WriteLine($"IP is: {IP[0]}");
                for (int i = 1; i > 0; i--)
                {
                    if (sck.Connected)
                    {
                        Console.WriteLine("Connected!");
                        List<byte> Packet = new List<byte>();
                        Packet.AddUShort(10100);
                        SendData(sck,Packet);
                    }
                }
                while (!sck.Connected)
                {
                    Console.WriteLine("Disonnected!");
                    Console.Read();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection failed");
                Console.WriteLine(e.ToString());
                Console.Read();
            }

        }

        private static void ConnectToCRServer()
        {
            try
            {
                Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sck.Connect("localhost", 9339);
                for (int i = 1; i > 0; i--)
                {
                    if (sck.Connected)
                    {
                        Console.WriteLine("Connected!");
                    }
                }
                while (!sck.Connected)
                {
                    Console.WriteLine("Disonnected!");
                    Console.Read();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Connection failed");
                Console.WriteLine(e.ToString());
                Console.Read();
            }
        }
        public static void SendData(Socket socket, List<byte> input)
        {
            byte[] key = "AC30DCBEA27E213407519BC05BE8E9D930E63F873858479946C144895FA3A26B".HexToByteArray();
            byte[] Input = input.ListByteToByteArray();
            byte[] Encrypted = RC4.Encrypt(key, Input);
            //byte[] Decrypted = RC4.Encrypt(key, Encrypted);
            //string output = Decrypted.ByteArrayToString();
            //Console.WriteLine(output);
            socket.Send(Encrypted);
            string consoleInput = Console.ReadLine();
            if(consoleInput == "connect")
            {
                ConnectToCRServerWithDns();
            }
            else
            {
                Environment.Exit(0);
            }
        }
        static byte[] HexToByteArray(this string hex)
        {
        return Enumerable.Range(0, hex.Length)
                    .Where(x => x % 2 == 0)
                    .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                    .ToArray();
        }
        static string ByteArrayToString(this byte[] input)
        {
            UnicodeEncoding unicode = new UnicodeEncoding();
            string output = unicode.GetString(input);
            return output;
        }
        static byte[] ListByteToByteArray(this List<byte> input)
        {
            byte[] output = input.ToArray();
            return output;
        }
    }

}
