using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class TogglePreHistoryHidden : ITlFunc<T.UpdatesType>, IEquatable<TogglePreHistoryHidden>, IComparable<TogglePreHistoryHidden>, IComparable
    {
        public T.InputChannel Channel { get; }
        public bool Enabled { get; }
        
        public TogglePreHistoryHidden(
            Some<T.InputChannel> channel,
            bool enabled
        ) {
            Channel = channel;
            Enabled = enabled;
        }
        
        
        (T.InputChannel, bool) CmpTuple =>
            (Channel, Enabled);

        public bool Equals(TogglePreHistoryHidden other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is TogglePreHistoryHidden x && Equals(x);
        public static bool operator ==(TogglePreHistoryHidden x, TogglePreHistoryHidden y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(TogglePreHistoryHidden x, TogglePreHistoryHidden y) => !(x == y);

        public int CompareTo(TogglePreHistoryHidden other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is TogglePreHistoryHidden x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(TogglePreHistoryHidden x, TogglePreHistoryHidden y) => x.CompareTo(y) <= 0;
        public static bool operator <(TogglePreHistoryHidden x, TogglePreHistoryHidden y) => x.CompareTo(y) < 0;
        public static bool operator >(TogglePreHistoryHidden x, TogglePreHistoryHidden y) => x.CompareTo(y) > 0;
        public static bool operator >=(TogglePreHistoryHidden x, TogglePreHistoryHidden y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Enabled: {Enabled})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xeabbb94c);
            Write(Channel, bw, WriteSerializable);
            Write(Enabled, bw, WriteBool);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}