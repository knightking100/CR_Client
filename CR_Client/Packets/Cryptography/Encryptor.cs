using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blake2Sharp;
using TweetNaCl;

namespace CR_Client.Packets.Cryptography
{
    public class Encryptor
    {
        public static byte[] Encrypt(byte[] Data)
        {
            byte[] Packet = Encoding.ASCII.GetBytes(GlobalValues.SessionKey).Concat((Keys.RNonceKey)).Concat((Data)).ToArray();
            byte[] Nonce = Keys.NonceKey;
            Crypto CryptoKeys = new Crypto();
            CryptoKeys.SNonce = new byte[24];
            CryptoKeys.RNonce = new byte[24];
            CryptoKeys.PublicKey = Keys.kp.PublicKey;
            byte[] AfterNm = TweetNaCl.TweetNaCl.CryptoBoxAfternm(Packet, Keys.NonceKey, Keys.PrecomputedSharedKey);
            byte[] Encrypted = Keys.kp.PrivateKey.Concat(AfterNm).ToArray();
            return Encrypted;
        }
    }
}
