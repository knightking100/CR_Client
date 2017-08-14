using CR_Client.Enums;
using CR_Client.Packets.Messages.Server;
using CR_Client.PacketSender;
using CR_Client.Tools;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CR_Client
{
    public partial class MainForm : Form
    {
        public static Socket sck = GlobalValues.sck;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            IPAddress[] IP = Dns.GetHostAddresses("game.clashroyaleapp.com"); ;
            string ip = "192.168.0.101";
            sck.Connect(ip, 9339);
            Console.WriteLine($"Connected IP is: {ip}");
        }

        private void btnHello_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Connected!");
            ClientHelloSender.SendClientHello(sck);
            Console.WriteLine($"Successfully sent {Emsg.ClientHello}.");
            string receivedData = ServerHelloReceiver.ReceivePacket(sck);
            string sessionkey = receivedData.Replace(GlobalValues.SessionKeyFilter, "");
            GlobalValues.SessionKey = sessionkey;
            Console.WriteLine($"Session key: {sessionkey}");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ClientLoginSender.SendClientLogin(sck);
            Console.WriteLine($"Successfully sent {Emsg.ClientLogin}.");
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            sck.Disconnect(false);
        }
        public static void ConnectToCRServer()
        {
            try
            {
                while (sck.Connected)
                {
                    Console.WriteLine("Disonnected!");
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
            catch (Exception e)
            {
                Console.WriteLine("Connection failed");
                Console.WriteLine(e.ToString());
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
    }
}
