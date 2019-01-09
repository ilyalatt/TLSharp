using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetStatuses : Record<GetStatuses>, ITlFunc<Arr<T.ContactStatus>>
    {

        
        public GetStatuses(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc4a353ee);

        }
        
        Arr<T.ContactStatus> ITlFunc<Arr<T.ContactStatus>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.ContactStatus.Deserialize));
    }
}