using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class DestroyAuthKey : Record<DestroyAuthKey>, ITlFunc<T.DestroyAuthKeyRes>
    {

        
        public DestroyAuthKey(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd1435160);

        }
        
        T.DestroyAuthKeyRes ITlFunc<T.DestroyAuthKeyRes>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DestroyAuthKeyRes.Deserialize);
    }
}