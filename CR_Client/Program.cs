using CR_Client.Messages.Client;
using CR_Client.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using CR_Client.PacketSender;

namespace CR_Client
{
    static class Program
    {

        //internal static Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        internal static List<byte> list = new List<byte>();

        static void Main(string[] args)
        {
            Console.Title = "CR Client";
            ConnectToCRServer();
        }

        private static void ConnectToCRServer()
        {
            try
            {
                Socket sck = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress[] IP = Dns.GetHostAddresses("game.clashroyaleapp.com");;
                IPAddress ip = IPAddress.Parse("192.168.0.101");
                sck.Connect(ip, 9339);
                Console.WriteLine($"IP is: {ip}");
                for (int i = 1; i > 0; i--)
                {
                    if (sck.Connected)
                    {
                        Console.WriteLine("Connected!");
                        ClientHelloSender.SendClientHello(sck);
                        Console.WriteLine($"Successfully sent.{Emsg.ClientHello}");
                        Console.WriteLine("");
                        //Reader _Reader = new Reader(ReceiveSync().ToArray());
                        //string response = _Reader.ReadString();
                        //Console.WriteLine($"Response from server {response}");
                        string consoleInput = Console.ReadLine();
                        if (consoleInput == "connect")
                        {
                            ConnectToCRServer();
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
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
    }
}
