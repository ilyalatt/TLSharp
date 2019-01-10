﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BigMath;
using BigMath.Utils;
using LanguageExt;
using TLSharp.Rpc;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using TLSharp.Utils;
using static LanguageExt.Prelude;
using static TLSharp.Utils.BtHelpers;
using Aes = TLSharp.Rpc.Aes;

namespace TLSharp.Auth
{
    struct Step3Res
    {
        public AuthKey AuthKey { get; }
        public int TimeOffset { get; }

        public Step3Res(Some<AuthKey> authKey, int timeOffset)
        {
            AuthKey = authKey;
            TimeOffset = timeOffset;
        }
    }

    static class Step3
    {
        static Func<BinaryReader, T> SkipHashSum<T>(Func<BinaryReader, T> func) => br =>
        {
            br.ReadBytes(20);
            return func(br);
        };

        static byte[] ComputeHash(byte[] bts)
        {
            using (SHA1 sha1 = new SHA1Managed())
                return sha1.ComputeHash(bts, 0, bts.Length);
        }

        static byte[] WithHash(byte[] bts) => UsingMemBinWriter(bw =>
        {
            bw.Write(ComputeHash(bts));
            bw.Write(bts);
        });

        public static async Task<Step3Res> Do(
            Some<ServerDhParams.OkTag> someServerDhParams,
            Int256 newNonce,
            Some<MtProtoPlainTransport> transport
        )
        {
            var dhParams = someServerDhParams.Value;
            var key = Aes.GenerateKeyDataFromNonces(dhParams.ServerNonce.ToBytes(true), newNonce.ToBytes(true));
            var plaintextAnswer = Aes.DecryptAES(key, dhParams.EncryptedAnswer.ToArray());
            var dh = plaintextAnswer.Apply(Deserialize(SkipHashSum(ServerDhInnerData.Deserialize))).Match(identity);

            Helpers.Assert(dh.Nonce == dhParams.Nonce, "auth step3: invalid nonce in encrypted answer");
            Helpers.Assert(dh.ServerNonce == dhParams.ServerNonce, "auth step3: invalid server nonce in encrypted answer");

            var currentEpochTime = Helpers.GetCurrentEpochTime();
            var timeOffset = dh.ServerTime - currentEpochTime;

            var g = dh.G;
            var dhPrime = new BigInteger(1, dh.DhPrime.ToArray());
            var ga = new BigInteger(1, dh.Ga.ToArray());

            var b = new BigInteger(2048, new Random());
            var gb = BigInteger.ValueOf(g).ModPow(b, dhPrime);
            var gab = ga.ModPow(b, dhPrime);

            var dhInnerData = new ClientDhInnerData.Tag(
                nonce: dh.Nonce,
                serverNonce: dh.ServerNonce,
                retryId: 0,
                gb: gb.ToByteArrayUnsigned().ToArr()
            );
            var dhInnerDataBts = Serialize((ClientDhInnerData) dhInnerData);

            var dhInnerDataHashedBts = WithHash(dhInnerDataBts);
            var dhInnerDataHashedEncryptedBytes = Aes.EncryptAES(key, dhInnerDataHashedBts);

            var resp = await transport.Value.Call(new SetClientDhParams(
                nonce: dh.Nonce,
                serverNonce: dh.ServerNonce,
                encryptedData: dhInnerDataHashedEncryptedBytes.ToArr()
            ));
            var res = resp.Match(
                dhGenFailTag: _ => Helpers.FailedAssertion<SetClientDhParamsAnswer.DhGenOkTag>("auth step3: dh_gen_fail"),
                dhGenRetryTag: _ => Helpers.FailedAssertion<SetClientDhParamsAnswer.DhGenOkTag>("auth step3: dh_gen_retry"),
                dhGenOkTag: identity
            );

            var authKey = AuthKey.FromGab(gab);
            var newNonceHash = authKey.CalcNewNonceHash(newNonce.ToBytes(true), 1).ToInt128();
            Helpers.Assert(res.Nonce == dh.Nonce, "auth step3: invalid nonce");
            Helpers.Assert(res.ServerNonce == dh.ServerNonce, "auth step3: invalid server nonce");
            Helpers.Assert(res.NewNonceHash1 == newNonceHash, "auth step3: invalid new nonce hash");

            return new Step3Res(authKey, timeOffset);
        }
    }
}
