using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetFullChannel : ITlFunc<T.Messages.ChatFull>, IEquatable<GetFullChannel>, IComparable<GetFullChannel>, IComparable
    {
        public T.InputChannel Channel { get; }
        
        public GetFullChannel(
            Some<T.InputChannel> channel
        ) {
            Channel = channel;
        }
        
        
        T.InputChannel CmpTuple =>
            Channel;

        public bool Equals(GetFullChannel other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetFullChannel x && Equals(x);
        public static bool operator ==(GetFullChannel x, GetFullChannel y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFullChannel x, GetFullChannel y) => !(x == y);

        public int CompareTo(GetFullChannel other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetFullChannel x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFullChannel x, GetFullChannel y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFullChannel x, GetFullChannel y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFullChannel x, GetFullChannel y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFullChannel x, GetFullChannel y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x08736a09);
            Write(Channel, bw, WriteSerializable);
        }
        
        T.Messages.ChatFull ITlFunc<T.Messages.ChatFull>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.ChatFull.Deserialize);
    }
}