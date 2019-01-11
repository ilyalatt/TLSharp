using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendInlineBotResult : ITlFunc<T.UpdatesType>, IEquatable<SendInlineBotResult>, IComparable<SendInlineBotResult>, IComparable
    {
        public bool Silent { get; }
        public bool Background { get; }
        public bool ClearDraft { get; }
        public T.InputPeer Peer { get; }
        public Option<int> ReplyToMsgId { get; }
        public long RandomId { get; }
        public long QueryId { get; }
        public string Id { get; }
        
        public SendInlineBotResult(
            bool silent,
            bool background,
            bool clearDraft,
            Some<T.InputPeer> peer,
            Option<int> replyToMsgId,
            long randomId,
            long queryId,
            Some<string> id
        ) {
            Silent = silent;
            Background = background;
            ClearDraft = clearDraft;
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            RandomId = randomId;
            QueryId = queryId;
            Id = id;
        }
        
        
        (bool, bool, bool, T.InputPeer, Option<int>, long, long, string) CmpTuple =>
            (Silent, Background, ClearDraft, Peer, ReplyToMsgId, RandomId, QueryId, Id);

        public bool Equals(SendInlineBotResult other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SendInlineBotResult x && Equals(x);
        public static bool operator ==(SendInlineBotResult x, SendInlineBotResult y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendInlineBotResult x, SendInlineBotResult y) => !(x == y);

        public int CompareTo(SendInlineBotResult other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SendInlineBotResult x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendInlineBotResult x, SendInlineBotResult y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendInlineBotResult x, SendInlineBotResult y) => x.CompareTo(y) < 0;
        public static bool operator >(SendInlineBotResult x, SendInlineBotResult y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendInlineBotResult x, SendInlineBotResult y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Silent: {Silent}, Background: {Background}, ClearDraft: {ClearDraft}, Peer: {Peer}, ReplyToMsgId: {ReplyToMsgId}, RandomId: {RandomId}, QueryId: {QueryId}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb16e06fe);
            Write(MaskBit(5, Silent) | MaskBit(6, Background) | MaskBit(7, ClearDraft) | MaskBit(0, ReplyToMsgId), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
            Write(RandomId, bw, WriteLong);
            Write(QueryId, bw, WriteLong);
            Write(Id, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}