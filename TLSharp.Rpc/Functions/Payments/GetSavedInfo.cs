using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class GetSavedInfo : Record<GetSavedInfo>, ITlFunc<T.Payments.SavedInfo>
    {

        
        public GetSavedInfo(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x227d824b);

        }
        
        T.Payments.SavedInfo ITlFunc<T.Payments.SavedInfo>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Payments.SavedInfo.Deserialize);
    }
}