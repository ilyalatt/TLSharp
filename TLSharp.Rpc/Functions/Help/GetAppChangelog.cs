using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetAppChangelog : Record<GetAppChangelog>, ITlFunc<T.UpdatesType>
    {
        public string PrevAppVersion { get; }
        
        public GetAppChangelog(
            Some<string> prevAppVersion
        ) {
            PrevAppVersion = prevAppVersion;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9010ef6f);
            Write(PrevAppVersion, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}