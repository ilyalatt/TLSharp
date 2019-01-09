﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using BigMath;
using LanguageExt;
using TLSharp.Utils;

namespace TLSharp.Auth
{
    public class AuthKey
    {
        public Arr<byte> Key { get; }
        public ulong KeyId { get; }
        public ulong AuxHash { get; }

        AuthKey(Arr<byte> key, ulong keyId, ulong auxHash)
        {
            Key = key;
            KeyId = keyId;
            AuxHash = auxHash;
        }

        public static AuthKey Deserialize(Arr<byte> key)
        {
            var (auxHash, keyId) = key.ToArray().Apply(Helpers.Sha1).Apply(BtHelpers.Deserialize(br =>
            {
                var a = br.ReadUInt64();
                br.ReadBytes(4);
                var b = br.ReadUInt64();
                return (a, b);
            }));
            return new AuthKey(key, keyId, auxHash);
        }

        internal static AuthKey FromGab(BigInteger gab) =>
            Deserialize(gab.ToByteArrayUnsigned());

        internal byte[] CalcNewNonceHash(byte[] newNonce, int number) => BtHelpers
            .UsingMemBinWriter(bw =>
            {
                bw.Write(newNonce);
                bw.Write((byte) number);
                bw.Write(AuxHash);
            })
            .Apply(Helpers.Sha1)
            .Apply(hash =>
            {
                var newNonceHash = new byte[16];
                Array.Copy(hash, 4, newNonceHash, 0, 16);
                return newNonceHash;
            });

        public override string ToString() => $"(KeyId: {KeyId:x16}, AuxHash: {AuxHash:x16}, Key: {BitConverter.ToString(Key.ToArray())})";
    }
}
