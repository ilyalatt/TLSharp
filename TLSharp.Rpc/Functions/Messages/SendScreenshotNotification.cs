using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendScreenshotNotification : ITlFunc<T.UpdatesType>, IEquatable<SendScreenshotNotification>, IComparable<SendScreenshotNotification>, IComparable
    {
        public T.InputPeer Peer { get; }
        public int ReplyToMsgId { get; }
        public long RandomId { get; }
        
        public SendScreenshotNotification(
            Some<T.InputPeer> peer,
            int replyToMsgId,
            long randomId
        ) {
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            RandomId = randomId;
        }
        
        
        (T.InputPeer, int, long) CmpTuple =>
            (Peer, ReplyToMsgId, RandomId);

        public bool Equals(SendScreenshotNotification other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendScreenshotNotification x && Equals(x);
        public static bool operator ==(SendScreenshotNotification x, SendScreenshotNotification y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendScreenshotNotification x, SendScreenshotNotification y) => !(x == y);

        public int CompareTo(SendScreenshotNotification other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendScreenshotNotification x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendScreenshotNotification x, SendScreenshotNotification y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendScreenshotNotification x, SendScreenshotNotification y) => x.CompareTo(y) < 0;
        public static bool operator >(SendScreenshotNotification x, SendScreenshotNotification y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendScreenshotNotification x, SendScreenshotNotification y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, ReplyToMsgId: {ReplyToMsgId}, RandomId: {RandomId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc97df020);
            Write(Peer, bw, WriteSerializable);
            Write(ReplyToMsgId, bw, WriteInt);
            Write(RandomId, bw, WriteLong);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}