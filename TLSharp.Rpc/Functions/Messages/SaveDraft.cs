using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SaveDraft : ITlFunc<bool>, IEquatable<SaveDraft>, IComparable<SaveDraft>, IComparable
    {
        public bool NoWebpage { get; }
        public Option<int> ReplyToMsgId { get; }
        public T.InputPeer Peer { get; }
        public string Message { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        
        public SaveDraft(
            bool noWebpage,
            Option<int> replyToMsgId,
            Some<T.InputPeer> peer,
            Some<string> message,
            Option<Arr<T.MessageEntity>> entities
        ) {
            NoWebpage = noWebpage;
            ReplyToMsgId = replyToMsgId;
            Peer = peer;
            Message = message;
            Entities = entities;
        }
        
        
        (bool, Option<int>, T.InputPeer, string, Option<Arr<T.MessageEntity>>) CmpTuple =>
            (NoWebpage, ReplyToMsgId, Peer, Message, Entities);

        public bool Equals(SaveDraft other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SaveDraft x && Equals(x);
        public static bool operator ==(SaveDraft x, SaveDraft y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveDraft x, SaveDraft y) => !(x == y);

        public int CompareTo(SaveDraft other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SaveDraft x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveDraft x, SaveDraft y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveDraft x, SaveDraft y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveDraft x, SaveDraft y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveDraft x, SaveDraft y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(NoWebpage: {NoWebpage}, ReplyToMsgId: {ReplyToMsgId}, Peer: {Peer}, Message: {Message}, Entities: {Entities})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbc39e14b);
            Write(MaskBit(1, NoWebpage) | MaskBit(0, ReplyToMsgId) | MaskBit(3, Entities), bw, WriteInt);
            Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
            Write(Peer, bw, WriteSerializable);
            Write(Message, bw, WriteString);
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}