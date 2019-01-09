using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetPinnedDialogs : Record<GetPinnedDialogs>, ITlFunc<T.Messages.PeerDialogs>
    {

        
        public GetPinnedDialogs(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe254d64e);

        }
        
        T.Messages.PeerDialogs ITlFunc<T.Messages.PeerDialogs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.PeerDialogs.Deserialize);
    }
}