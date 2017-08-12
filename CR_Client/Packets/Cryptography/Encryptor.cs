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
        public static byte[] Encrypt(List<byte> Data)
        {
            Blake2BHasher Blake2B = new Blake2BHasher(new Blake2BConfig() { OutputSizeInBytes = 24});
            Blake2B.Update(Keys.kp.PublicKey);
            Blake2B.Update(Keys.PublicKey);
            byte[] Nonce = Blake2B.Finish();
            Crypto CryptoKeys = new Crypto();
            CryptoKeys.SNonce = new byte[24];
            CryptoKeys.RNonce = new byte[24];
            CryptoKeys.PublicKey = Keys.kp.PublicKey;
            byte[] Encrypted = SecretBox.Create(Data.ToArray(), Nonce, Keys.PublicKey);
            Encrypted = CryptoKeys.PublicKey.Concat(Encrypted).ToArray();
            Data.Clear();
            Data.AddRange(Encrypted);
            return Data.ToArray();
        }
    }
}
