using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class ReceivedCall : ITlFunc<bool>, IEquatable<ReceivedCall>, IComparable<ReceivedCall>, IComparable
    {
        public T.InputPhoneCall Peer { get; }
        
        public ReceivedCall(
            Some<T.InputPhoneCall> peer
        ) {
            Peer = peer;
        }
        
        
        T.InputPhoneCall CmpTuple =>
            Peer;

        public bool Equals(ReceivedCall other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReceivedCall x && Equals(x);
        public static bool operator ==(ReceivedCall x, ReceivedCall y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReceivedCall x, ReceivedCall y) => !(x == y);

        public int CompareTo(ReceivedCall other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReceivedCall x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReceivedCall x, ReceivedCall y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReceivedCall x, ReceivedCall y) => x.CompareTo(y) < 0;
        public static bool operator >(ReceivedCall x, ReceivedCall y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReceivedCall x, ReceivedCall y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x17d54f61);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}