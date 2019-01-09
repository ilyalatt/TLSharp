using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class SetCallRating : Record<SetCallRating>, ITlFunc<T.UpdatesType>
    {
        public T.InputPhoneCall Peer { get; }
        public int Rating { get; }
        public string Comment { get; }
        
        public SetCallRating(
            Some<T.InputPhoneCall> peer,
            int rating,
            Some<string> comment
        ) {
            Peer = peer;
            Rating = rating;
            Comment = comment;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1c536a34);
            Write(Peer, bw, WriteSerializable);
            Write(Rating, bw, WriteInt);
            Write(Comment, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}