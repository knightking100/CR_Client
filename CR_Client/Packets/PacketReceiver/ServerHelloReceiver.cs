using CR_Client.Enums;
using CR_Client.Tools;
using System.Net.Sockets;
using System.Text;

namespace CR_Client.Packets.Messages.Server
{
    public class ServerHelloReceiver
    {
        public static string ReceivePacket(Socket sck)
        {
            string sessionKeyFilter = GlobalValues.SessionKeyFilter;
            byte[] receivedData = new byte[38];
            sck.Receive(receivedData);
            string toReturn = Encoding.ASCII.GetString(receivedData);
            string _toReturn = null;
            //PacketDumper.DumpEncrypted(Emsg.ServerHello.ToString(), receivedData);
            return _toReturn;
        }
    }
}
