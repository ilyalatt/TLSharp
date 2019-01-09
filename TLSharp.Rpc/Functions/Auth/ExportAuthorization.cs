using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ExportAuthorization : Record<ExportAuthorization>, ITlFunc<T.Auth.ExportedAuthorization>
    {
        public int DcId { get; }
        
        public ExportAuthorization(
            int dcId
        ) {
            DcId = dcId;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe5bfffcd);
            Write(DcId, bw, WriteInt);
        }
        
        T.Auth.ExportedAuthorization ITlFunc<T.Auth.ExportedAuthorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.ExportedAuthorization.Deserialize);
    }
}