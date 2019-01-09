using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class ReceivedCall : Record<ReceivedCall>, ITlFunc<bool>
    {
        public T.InputPhoneCall Peer { get; }
        
        public ReceivedCall(
            Some<T.InputPhoneCall> peer
        ) {
            Peer = peer;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x17d54f61);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}