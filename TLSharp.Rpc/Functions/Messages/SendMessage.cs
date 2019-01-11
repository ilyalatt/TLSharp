using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendMessage : ITlFunc<T.UpdatesType>, IEquatable<SendMessage>, IComparable<SendMessage>, IComparable
    {
        public bool NoWebpage { get; }
        public bool Silent { get; }
        public bool Background { get; }
        public bool ClearDraft { get; }
        public T.InputPeer Peer { get; }
        public Option<int> ReplyToMsgId { get; }
        public string Message { get; }
        public long RandomId { get; }
        public Option<T.ReplyMarkup> ReplyMarkup { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        
        public SendMessage(
            bool noWebpage,
            bool silent,
            bool background,
            bool clearDraft,
            Some<T.InputPeer> peer,
            Option<int> replyToMsgId,
            Some<string> message,
            long randomId,
            Option<T.ReplyMarkup> replyMarkup,
            Option<Arr<T.MessageEntity>> entities
        ) {
            NoWebpage = noWebpage;
            Silent = silent;
            Background = background;
            ClearDraft = clearDraft;
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            Message = message;
            RandomId = randomId;
            ReplyMarkup = replyMarkup;
            Entities = entities;
        }
        
        
        (bool, bool, bool, bool, T.InputPeer, Option<int>, string, long, Option<T.ReplyMarkup>, Option<Arr<T.MessageEntity>>) CmpTuple =>
            (NoWebpage, Silent, Background, ClearDraft, Peer, ReplyToMsgId, Message, RandomId, ReplyMarkup, Entities);

        public bool Equals(SendMessage other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SendMessage x && Equals(x);
        public static bool operator ==(SendMessage x, SendMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendMessage x, SendMessage y) => !(x == y);

        public int CompareTo(SendMessage other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SendMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendMessage x, SendMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendMessage x, SendMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(SendMessage x, SendMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendMessage x, SendMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(NoWebpage: {NoWebpage}, Silent: {Silent}, Background: {Background}, ClearDraft: {ClearDraft}, Peer: {Peer}, ReplyToMsgId: {ReplyToMsgId}, Message: {Message}, RandomId: {RandomId}, ReplyMarkup: {ReplyMarkup}, Entities: {Entities})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfa88427a);
            Write(MaskBit(1, NoWebpage) | MaskBit(5, Silent) | MaskBit(6, Background) | MaskBit(7, ClearDraft) | MaskBit(0, ReplyToMsgId) | MaskBit(2, ReplyMarkup) | MaskBit(3, Entities), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
            Write(Message, bw, WriteString);
            Write(RandomId, bw, WriteLong);
            Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}