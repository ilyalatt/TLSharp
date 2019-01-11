using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ToggleSignatures : ITlFunc<T.UpdatesType>, IEquatable<ToggleSignatures>, IComparable<ToggleSignatures>, IComparable
    {
        public T.InputChannel Channel { get; }
        public bool Enabled { get; }
        
        public ToggleSignatures(
            Some<T.InputChannel> channel,
            bool enabled
        ) {
            Channel = channel;
            Enabled = enabled;
        }
        
        
        (T.InputChannel, bool) CmpTuple =>
            (Channel, Enabled);

        public bool Equals(ToggleSignatures other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ToggleSignatures x && Equals(x);
        public static bool operator ==(ToggleSignatures x, ToggleSignatures y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ToggleSignatures x, ToggleSignatures y) => !(x == y);

        public int CompareTo(ToggleSignatures other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ToggleSignatures x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ToggleSignatures x, ToggleSignatures y) => x.CompareTo(y) <= 0;
        public static bool operator <(ToggleSignatures x, ToggleSignatures y) => x.CompareTo(y) < 0;
        public static bool operator >(ToggleSignatures x, ToggleSignatures y) => x.CompareTo(y) > 0;
        public static bool operator >=(ToggleSignatures x, ToggleSignatures y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Enabled: {Enabled})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1f69b606);
            Write(Channel, bw, WriteSerializable);
            Write(Enabled, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}