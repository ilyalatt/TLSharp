using System;
using System.Linq;
using System.Threading.Tasks;
using BigMath;
using LanguageExt;
using TLSharp.Crypto;
using TLSharp.Network;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using static LanguageExt.Prelude;
using static TLSharp.Auth.BtHelpers;

namespace TLSharp.Auth
{
    struct Step2Response
    {
        public ServerDhParams.OkTag ServerDhParams { get; }
        public Int256 NewNonce { get; }

        public Step2Response(Some<ServerDhParams.OkTag> serverDhParams, Int256 newNonce)
        {
            ServerDhParams = serverDhParams;
            NewNonce = newNonce;
        }
    }

    static class Step2
    {
        public static async Task<Step2Response> Do(Some<ResPq.Tag> someResPq, Int256 newNonce, Some<MtProtoPlainSender> transport)
        {
            var resPq = someResPq.Value;

            var pq = Factorizator.Factorize(new BigInteger(1, resPq.Pq.ToArray()));
            var pqInnerData = new PqInnerData.Tag(
                pq: resPq.Pq,
                p: pq.Min.ToByteArrayUnsigned().ToArr(),
                q: pq.Max.ToByteArrayUnsigned().ToArr(),
                nonce: resPq.Nonce,
                serverNonce: resPq.ServerNonce,
                newNonce: newNonce
            );
            var pqInnerDataBts = Serialize((PqInnerData) pqInnerData);

            var (fingerprint, cipherText) =
                resPq.ServerPublicKeyFingerprints.Map(x => (x, x
                    .Apply(BitConverter.GetBytes)
                    .Apply(BitConverter.ToString)
                    .Replace("-", "")
                    .Apply(fingerprintStr => RSA.Encrypt(fingerprintStr, pqInnerDataBts, 0, pqInnerDataBts.Length))
                ))
                .Choose(t => t.Item2.Apply(Optional).Map(x2 => (t.Item1, x2)))
                .HeadOrNone()
                .IfNone(() => throw new InvalidOperationException(
                    $"not found valid key for fingerprints: {string.Join(", ", resPq.ServerPublicKeyFingerprints)}")
                );

            var resp = await transport.Value.Call(new ReqDhParams(
                nonce: pqInnerData.Nonce,
                serverNonce: pqInnerData.ServerNonce,
                p: pqInnerData.P,
                q: pqInnerData.Q,
                publicKeyFingerprint: fingerprint,
                encryptedData: cipherText.ToArr()
            ));
            var res = resp.Match(
                failTag: x => throw new InvalidOperationException("server_DH_params_fail: TODO"),
                okTag: x => x
            );

            if (res.Nonce != pqInnerData.Nonce) throw new InvalidOperationException("invalid nonce from server");
            if (res.ServerNonce != pqInnerData.ServerNonce) throw new InvalidOperationException("invalid nonce from server");

            return new Step2Response(res, newNonce);
        }
    }
}
