using System.Threading.Tasks;
using TLSharp.Network;

namespace TLSharp.Auth
{
    static class Authenticator
    {
        public static async Task<Step3Response> DoAuthentication(TcpTransport transport)
        {
            var sender = new MtProtoPlainSender(transport);

            var step1Response = await Step1.Do(BtHelpers.GenNonce16(), sender);
            var step2Response = await Step2.Do(step1Response, BtHelpers.GenNonce32(), sender);
            var step3Response = await Step3.Do(step2Response.ServerDhParams, step2Response.NewNonce, sender);

            return step3Response;
        }
    }
}
