using System;
using System.Threading.Tasks;
using BigMath;
using LanguageExt;
using TLSharp.Network;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using static LanguageExt.Prelude;

namespace TLSharp.Auth
{
    static class Step1
    {
        public static async Task<ResPq.Tag> Do(Int128 nonce, Some<MtProtoPlainSender> transport)
        {
            var resp = await transport.Value.Call(new ReqPq(nonce));
            var res = resp.Match(identity);

            if (res.Nonce != nonce) throw new InvalidOperationException("invalid nonce from server");
            return res;
        }
    }
}
