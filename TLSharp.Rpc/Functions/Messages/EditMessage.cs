using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditMessage : ITlFunc<T.UpdatesType>, IEquatable<EditMessage>, IComparable<EditMessage>, IComparable
    {
        public bool NoWebpage { get; }
        public T.InputPeer Peer { get; }
        public int Id { get; }
        public Option<string> Message { get; }
        public Option<T.ReplyMarkup> ReplyMarkup { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        
        public EditMessage(
            bool noWebpage,
            Some<T.InputPeer> peer,
            int id,
            Option<string> message,
            Option<T.ReplyMarkup> replyMarkup,
            Option<Arr<T.MessageEntity>> entities
        ) {
            NoWebpage = noWebpage;
            Peer = peer;
            Id = id;
            Message = message;
            ReplyMarkup = replyMarkup;
            Entities = entities;
        }
        
        
        (bool, T.InputPeer, int, Option<string>, Option<T.ReplyMarkup>, Option<Arr<T.MessageEntity>>) CmpTuple =>
            (NoWebpage, Peer, Id, Message, ReplyMarkup, Entities);

        public bool Equals(EditMessage other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is EditMessage x && Equals(x);
        public static bool operator ==(EditMessage x, EditMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditMessage x, EditMessage y) => !(x == y);

        public int CompareTo(EditMessage other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EditMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditMessage x, EditMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditMessage x, EditMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(EditMessage x, EditMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditMessage x, EditMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(NoWebpage: {NoWebpage}, Peer: {Peer}, Id: {Id}, Message: {Message}, ReplyMarkup: {ReplyMarkup}, Entities: {Entities})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xce91e4ca);
            Write(MaskBit(1, NoWebpage) | MaskBit(11, Message) | MaskBit(2, ReplyMarkup) | MaskBit(3, Entities), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
            Write(Message, bw, WriteOption<string>(WriteString));
            Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}