using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetNearestDc : Record<GetNearestDc>, ITlFunc<T.NearestDc>
    {

        
        public GetNearestDc(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1fb33026);

        }
        
        T.NearestDc ITlFunc<T.NearestDc>.DeserializeResult(BinaryReader br) =>
            Read(br, T.NearestDc.Deserialize);
    }
}