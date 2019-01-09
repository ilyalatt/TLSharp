using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ImportBotAuthorization : Record<ImportBotAuthorization>, ITlFunc<T.Auth.Authorization>
    {
        public int Flags { get; }
        public int ApiId { get; }
        public string ApiHash { get; }
        public string BotAuthToken { get; }
        
        public ImportBotAuthorization(
            int flags,
            int apiId,
            Some<string> apiHash,
            Some<string> botAuthToken
        ) {
            Flags = flags;
            ApiId = apiId;
            ApiHash = apiHash;
            BotAuthToken = botAuthToken;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x67a3ff2c);
            Write(Flags, bw, WriteInt);
            Write(ApiId, bw, WriteInt);
            Write(ApiHash, bw, WriteString);
            Write(BotAuthToken, bw, WriteString);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}