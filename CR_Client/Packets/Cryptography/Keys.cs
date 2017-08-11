using Sodium;
using System;
using System.Linq;

namespace CR_Client.Packets.Cryptography
{
    internal class Keys
    {
        internal static readonly byte[] PrivateKey = SecretBox.GenerateKey();
        internal static readonly byte[] PublicKey = HexToByteArray("ac30dcbea27e213407519bc05be8e9d930e63f873858479946c144895fa3a26b");
        internal static readonly KeyPair kp = new KeyPair(PrivateKey, PublicKey);
        public static readonly byte[] NonceKey = PublicKeyBox.GenerateNonce();
        internal static byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
    }
}
