using System;
using Sodium;

namespace CR_Client.Packets.Cryptography
{
    public class Crypto
    {
        public static byte[] Encrypt(byte[] data, byte[] nonce, byte[] privateKey, byte[] publicKey)
        {
            return PublicKeyBox.Create(data, nonce, privateKey, publicKey);
        }
        public static byte[] Decrypt(byte[] data, byte[] nonce, byte[] privateKey, byte[] publicKey)
        {
            return PublicKeyBox.Open(data, nonce, privateKey, publicKey);
        }
    }
}
