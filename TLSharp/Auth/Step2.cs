using System.Linq;
using System.Threading.Tasks;
using BigMath;
using LanguageExt;
using TLSharp.Rpc;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using TLSharp.Utils;
using static TLSharp.Utils.BtHelpers;

namespace TLSharp.Auth
{
    struct Step2Result
    {
        public ServerDhParams.OkTag ServerDhParams { get; }
        public Int256 NewNonce { get; }

        public Step2Result(Some<ServerDhParams.OkTag> serverDhParams, Int256 newNonce)
        {
            ServerDhParams = serverDhParams;
            NewNonce = newNonce;
        }
    }

    static class Step2
    {
        public static async Task<Step2Result> Do(Some<ResPq.Tag> someResPq, Int256 newNonce, Some<MtProtoPlainTransport> transport)
        {
            var resPq = someResPq.Value;

            Helpers.Assert(resPq.Pq.Count <= 8, "auth step2: pq is too big");
            var pq = new BigInteger(1, resPq.Pq.ToArray());
            var (pLong, qLong) = Factorizer.Factorize(pq.LongValue);
            var p = new BigInteger(pLong);
            var q = new BigInteger(qLong);

            var pqInnerData = new PqInnerData.Tag(
                pq: resPq.Pq,
                p: p.ToByteArrayUnsigned().ToArr(),
                q: q.ToByteArrayUnsigned().ToArr(),
                nonce: resPq.Nonce,
                serverNonce: resPq.ServerNonce,
                newNonce: newNonce
            );
            var pqInnerDataBts = Serialize((PqInnerData) pqInnerData);

            var fingerprint = resPq.ServerPublicKeyFingerprints.Find(x => x == TgServerRsaKey.Fingerprint)
                .IfNone(() => Helpers.FailedAssertion<long>(
                    $"auth step2: can not find a key for fingerprints: {string.Join(", ", resPq.ServerPublicKeyFingerprints.Map(x => x.ToString("x16")))}"
                ));
            var cipherText = Rsa.Encrypt(TgServerRsaKey.Key, pqInnerDataBts);

            var resp = await transport.Value.Call(new ReqDhParams(
                nonce: pqInnerData.Nonce,
                serverNonce: pqInnerData.ServerNonce,
                p: pqInnerData.P,
                q: pqInnerData.Q,
                publicKeyFingerprint: fingerprint,
                encryptedData: cipherText.ToArr()
            ));
            var res = resp.Match(
                failTag: x => Helpers.FailedAssertion<ServerDhParams.OkTag>("auth step2: server_DH_params_fail"),
                okTag: x => x
            );

            Helpers.Assert(res.Nonce == pqInnerData.Nonce, "auth step2: invalid nonce");
            Helpers.Assert(res.ServerNonce == pqInnerData.ServerNonce, "auth step2: invalid server nonce");

            return new Step2Result(res, newNonce);
        }
    }
}
