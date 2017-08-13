using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blake2Sharp;
using Sodium;

namespace CR_Client.Packets.Cryptography
{
    public class Encryptor
    {
        public static byte[] Encrypt(byte[] Data)
        {
            byte[] Nonce = Keys.NonceKey;
            Crypto CryptoKeys = new Crypto();
            CryptoKeys.SNonce = new byte[24];
            CryptoKeys.RNonce = new byte[24];
            CryptoKeys.PublicKey = Keys.kp.PublicKey;
            byte[] Encrypted = SecretBox.Create(Data.ToArray(), Nonce, Keys.PublicKey);
            Encrypted = CryptoKeys.PublicKey.Concat(Encrypted).ToArray();
            return Encrypted;
        }
    }
}
