using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Updates
{
    public sealed class GetState : Record<GetState>, ITlFunc<T.Updates.State>
    {

        
        public GetState(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xedd4882a);

        }
        
        T.Updates.State ITlFunc<T.Updates.State>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Updates.State.Deserialize);
    }
}