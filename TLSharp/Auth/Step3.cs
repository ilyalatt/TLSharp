using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BigMath;
using BigMath.Utils;
using LanguageExt;
using TLSharp.Crypto;
using TLSharp.Network;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using TLSharp.Utils;
using static LanguageExt.Prelude;
using static TLSharp.Auth.BtHelpers;

namespace TLSharp.Auth
{
    struct Step3Response
    {
        public AuthKey AuthKey { get; }
        public int TimeOffset { get; }

        public Step3Response(Some<AuthKey> authKey, int timeOffset)
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

        public static async Task<Step3Response> Do(
            Some<ServerDhParams.OkTag> someServerDhParams,
            Int256 newNonce,
            Some<MtProtoPlainSender> transport
        )
        {
            var dhParams = someServerDhParams.Value;
            var key = AES.GenerateKeyDataFromNonces(dhParams.ServerNonce.ToBytes(true), newNonce.ToBytes(true));
            var plaintextAnswer = AES.DecryptAES(key, dhParams.EncryptedAnswer.ToArray());
            var dh = plaintextAnswer.Apply(Deserialize(SkipHashSum(ServerDhInnerData.Deserialize))).Match(identity);

            if (dh.Nonce != dhParams.Nonce) throw new InvalidOperationException("invalid nonce in encrypted answer");
            if (dh.ServerNonce != dhParams.ServerNonce) throw new InvalidOperationException("invalid server nonce in encrypted answer");

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
            var dhInnerDataHashedEncryptedBytes = AES.EncryptAES(key, dhInnerDataHashedBts);

            var resp = await transport.Value.Call(new SetClientDhParams(
                nonce: dh.Nonce,
                serverNonce: dh.ServerNonce,
                encryptedData: dhInnerDataHashedEncryptedBytes.ToArr()
            ));
            var res = resp.Match(
                dhGenFailTag: _ => throw new NotImplementedException("dh_gen_fail"),
                dhGenRetryTag: _ => throw new NotImplementedException("dh_gen_retry"),
                dhGenOkTag: identity
            );

            var authKey = AuthKey.FromGab(gab);
            var newNonceHash = authKey.CalcNewNonceHash(newNonce.ToBytes(true), 1).ToInt128();
            if (res.Nonce != dh.Nonce) throw new InvalidOperationException("invalid nonce");
            if (res.ServerNonce != dh.ServerNonce) throw new InvalidOperationException("invalid server nonce");
            if (res.NewNonceHash1 != newNonceHash) throw new InvalidOperationException("invalid new nonce hash");

            return new Step3Response(authKey, timeOffset);
        }
    }
}
