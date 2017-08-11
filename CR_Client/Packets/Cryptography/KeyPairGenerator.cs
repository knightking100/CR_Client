using Sodium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CR_Client.Packets.Cryptography
{
    public class KeyPairGenerator
    {
        public static KeyPair Generate()
        {
            var kp = PublicKeyBox.GenerateKeyPair();
            return kp;
        }
    }
}
