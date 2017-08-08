using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace CR_Client
{
    static class Program
    {
        internal const int Key_Version = 11;
        internal const int Major_Version = 3;
        internal const int Minor_Version = 377;
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
                sck.Connect(IP[0], 9339);
                Console.WriteLine($"IP is: {IP[0]}");
                for (int i = 1; i > 0; i--)
                {
                    if (sck.Connected)
                    {
                        Console.WriteLine("Connected!");
                        List<byte> Packet = new List<byte>();
                        Packet.AddUShort(10100);
                        Packet.Add(0);
                        Packet.AddUShort(72);
                        Packet.AddUShort(1);

                        Packet.AddInt(1);
                        Packet.AddInt(Key_Version);
                        Packet.AddInt(Major_Version);
                        Packet.AddInt(0);
                        Packet.AddInt(Minor_Version);
                        Packet.AddString("9e5bf715eec4b3a9706515c21f7b519713b2d906");//5.2.4
                        Packet.AddInt(2);
                        Packet.AddInt(2);
                        sck.Send(Packet.ToArray());
                        Console.WriteLine("Successfully sent.");
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
        /*internal static List<byte> ReceiveSync()
        {
            byte[] _Data = new byte[2048];

            ushort Length = 0, Version = 0;

            while (true)
            {
                try
                {
                    int _ReceivedBytes = sck.Receive(_Data);

                    if (_ReceivedBytes >= 7)
                    {
                        byte[] _Buffer = new byte[_ReceivedBytes];

                        Array.Copy(_Data, _Buffer, _ReceivedBytes);

                        using (Reader _Reader = new Reader(_Buffer))
                        {
                            if (Length == 0 && _Reader.ReadUInt16() == 20103)
                            {
                                _Reader.Seek(1, System.IO.SeekOrigin.Current);

                                Length = _Reader.ReadUInt16();
                                Version = _Reader.ReadUInt16();

                                list.Clear();

                                list.AddRange(_Reader.ReadAllBytes);
                            }
                            else
                            {
                                list.AddRange(_Buffer);

                                if (sck.Available == 0 && Length <= (list.Count / 7) - 610)
                                {
                                    sck.Shutdown(SocketShutdown.Both);
                                    sck.Close();

                                    break;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    break;
                }
            }
            return list;
        }*/
    }
}
