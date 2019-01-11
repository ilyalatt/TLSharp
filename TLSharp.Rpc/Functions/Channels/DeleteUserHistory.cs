using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class DeleteUserHistory : ITlFunc<T.Messages.AffectedHistory>, IEquatable<DeleteUserHistory>, IComparable<DeleteUserHistory>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        
        public DeleteUserHistory(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId
        ) {
            Channel = channel;
            UserId = userId;
        }
        
        
        (T.InputChannel, T.InputUser) CmpTuple =>
            (Channel, UserId);

        public bool Equals(DeleteUserHistory other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteUserHistory x && Equals(x);
        public static bool operator ==(DeleteUserHistory x, DeleteUserHistory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteUserHistory x, DeleteUserHistory y) => !(x == y);

        public int CompareTo(DeleteUserHistory other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteUserHistory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteUserHistory x, DeleteUserHistory y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteUserHistory x, DeleteUserHistory y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteUserHistory x, DeleteUserHistory y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteUserHistory x, DeleteUserHistory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, UserId: {UserId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd10dd71b);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
        }
        
        T.Messages.AffectedHistory ITlFunc<T.Messages.AffectedHistory>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedHistory.Deserialize);
    }
}