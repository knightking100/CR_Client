using Sodium;
using System;
using System.Linq;
using Blake2Sharp;

namespace CR_Client.Packets.Cryptography
{
    internal class Keys
    {
        internal static readonly KeyPair kp = KeyPairGenerator.Generate();
        internal static readonly byte[] PrivateKey = HexToByteArray("1891d401fadb51d25d3a9174d472a9f691a45b974285d47729c45c6538070d85");
        //internal static readonly byte[] PublicKey = HexToByteArray("ac30dcbea27e213407519bc05be8e9d930e63f873858479946c144895fa3a26b");
        internal static readonly byte[] PublicKey = HexToByteArray("72f1a4a4c48e44da0c42310f800e96624e6dc6a641a9d41c3b5039d8dfadc27e");
        private static Hasher Blake2b = Blake2B.Create(new Blake2BConfig() { OutputSizeInBytes = 24 });
        public static readonly byte[] NonceKey = GenerateNonce();
        internal static byte[] HexToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }
        public static byte[] GenerateNonce()
        {
            Blake2b.Init();
            Blake2b.Update(kp.PublicKey);
            Blake2b.Update(PublicKey);
            byte[] output = Blake2b.Finish();
            return output;
        }
    }
}
