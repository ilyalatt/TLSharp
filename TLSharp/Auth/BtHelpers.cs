using System;
using System.IO;
using BigMath;
using BigMath.Utils;
using TLSharp.Rpc;

namespace TLSharp.Auth
{
    static class BtHelpers
    {
        // TODO: enhance random

        public static Int128 GenNonce16()
        {
            var bts = new byte[16];
            new Random().NextBytes(bts);
            return bts.ToInt128();
        }

        public static Int256 GenNonce32()
        {
            var bts = new byte[32];
            new Random().NextBytes(bts);
            return bts.ToInt256();
        }

        public static byte[] UsingMemBinWriter(Action<BinaryWriter> serializer)
        {
            var ms = new MemoryStream();
            var bw = new BinaryWriter(ms);
            serializer(bw);
            return ms.ToArray();
        }

        public static byte[] Serialize(ITlType dto) =>
            UsingMemBinWriter(dto.Serialize);

        public static Func<byte[], T> Deserialize<T>(Func<BinaryReader, T> deserializer) => bts =>
        {
            var ms = new MemoryStream(bts);
            var br = new BinaryReader(ms);
            return deserializer(br);
        };
    }
}
