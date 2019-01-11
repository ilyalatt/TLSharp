using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ToggleInvites : ITlFunc<T.UpdatesType>, IEquatable<ToggleInvites>, IComparable<ToggleInvites>, IComparable
    {
        public T.InputChannel Channel { get; }
        public bool Enabled { get; }
        
        public ToggleInvites(
            Some<T.InputChannel> channel,
            bool enabled
        ) {
            Channel = channel;
            Enabled = enabled;
        }
        
        
        (T.InputChannel, bool) CmpTuple =>
            (Channel, Enabled);

        public bool Equals(ToggleInvites other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ToggleInvites x && Equals(x);
        public static bool operator ==(ToggleInvites x, ToggleInvites y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ToggleInvites x, ToggleInvites y) => !(x == y);

        public int CompareTo(ToggleInvites other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ToggleInvites x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ToggleInvites x, ToggleInvites y) => x.CompareTo(y) <= 0;
        public static bool operator <(ToggleInvites x, ToggleInvites y) => x.CompareTo(y) < 0;
        public static bool operator >(ToggleInvites x, ToggleInvites y) => x.CompareTo(y) > 0;
        public static bool operator >=(ToggleInvites x, ToggleInvites y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Enabled: {Enabled})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x49609307);
            Write(Channel, bw, WriteSerializable);
            Write(Enabled, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}