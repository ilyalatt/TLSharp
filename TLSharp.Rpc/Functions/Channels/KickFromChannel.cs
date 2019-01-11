using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class KickFromChannel : ITlFunc<T.UpdatesType>, IEquatable<KickFromChannel>, IComparable<KickFromChannel>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        public bool Kicked { get; }
        
        public KickFromChannel(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            bool kicked
        ) {
            Channel = channel;
            UserId = userId;
            Kicked = kicked;
        }
        
        
        (T.InputChannel, T.InputUser, bool) CmpTuple =>
            (Channel, UserId, Kicked);

        public bool Equals(KickFromChannel other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is KickFromChannel x && Equals(x);
        public static bool operator ==(KickFromChannel x, KickFromChannel y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(KickFromChannel x, KickFromChannel y) => !(x == y);

        public int CompareTo(KickFromChannel other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is KickFromChannel x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(KickFromChannel x, KickFromChannel y) => x.CompareTo(y) <= 0;
        public static bool operator <(KickFromChannel x, KickFromChannel y) => x.CompareTo(y) < 0;
        public static bool operator >(KickFromChannel x, KickFromChannel y) => x.CompareTo(y) > 0;
        public static bool operator >=(KickFromChannel x, KickFromChannel y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, UserId: {UserId}, Kicked: {Kicked})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa672de14);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Kicked, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}