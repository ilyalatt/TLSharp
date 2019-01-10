using System.Threading.Tasks;
using BigMath;
using LanguageExt;
using TLSharp.Rpc;
using TLSharp.Rpc.Functions;
using TLSharp.Rpc.Types;
using TLSharp.Utils;
using static LanguageExt.Prelude;

namespace TLSharp.Auth
{
    static class Step1
    {
        public static async Task<ResPq.Tag> Do(Int128 nonce, Some<MtProtoPlainTransport> transport)
        {
            var resp = await transport.Value.Call(new ReqPq(nonce));
            var res = resp.Match(identity);

            Helpers.Assert(res.Nonce == nonce, "auth step1: invalid nonce");
            return res;
        }
    }
}
