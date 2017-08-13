using Blake2Sharp;
using CR_Client.Cryptography.Others;
using Sodium;
using System.Text;

namespace CR_Client.Packets.Cryptography
{
    public class KeyGenerator
    {
        public static KeyPair GenerateKeyPair()
        {
            var kp = PublicKeyBox.GenerateKeyPair();
            return kp;
        }
    }
}
