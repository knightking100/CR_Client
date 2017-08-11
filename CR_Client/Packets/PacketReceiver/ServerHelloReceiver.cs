using System.Net.Sockets;
using System.Text;

namespace CR_Client.Packets.Messages.Server
{
    public class ServerHelloReceiver
    {
        public static string ReceivePacket(Socket sck)
        {
            string sessionKeyFilter = "N?\0\0\u001c\0\0\0\0\0\u0018";
            byte[] receivedData = new byte[38];
            sck.Receive(receivedData);
            string toReturn = Encoding.ASCII.GetString(receivedData);
            string _toReturn = null;
            if(toReturn.Contains(sessionKeyFilter))
            {
                _toReturn = toReturn.Replace(sessionKeyFilter,"");
            }
            else
            {
                _toReturn = toReturn;
            }
            return _toReturn;
        }
    }
}
