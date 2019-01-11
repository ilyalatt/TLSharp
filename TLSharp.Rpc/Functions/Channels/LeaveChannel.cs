using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class LeaveChannel : ITlFunc<T.UpdatesType>, IEquatable<LeaveChannel>, IComparable<LeaveChannel>, IComparable
    {
        public T.InputChannel Channel { get; }
        
        public LeaveChannel(
            Some<T.InputChannel> channel
        ) {
            Channel = channel;
        }
        
        
        T.InputChannel CmpTuple =>
            Channel;

        public bool Equals(LeaveChannel other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is LeaveChannel x && Equals(x);
        public static bool operator ==(LeaveChannel x, LeaveChannel y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(LeaveChannel x, LeaveChannel y) => !(x == y);

        public int CompareTo(LeaveChannel other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is LeaveChannel x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(LeaveChannel x, LeaveChannel y) => x.CompareTo(y) <= 0;
        public static bool operator <(LeaveChannel x, LeaveChannel y) => x.CompareTo(y) < 0;
        public static bool operator >(LeaveChannel x, LeaveChannel y) => x.CompareTo(y) > 0;
        public static bool operator >=(LeaveChannel x, LeaveChannel y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf836aa95);
            Write(Channel, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}