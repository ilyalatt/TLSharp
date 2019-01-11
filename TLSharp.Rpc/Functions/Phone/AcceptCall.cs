using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class AcceptCall : ITlFunc<T.Phone.PhoneCall>, IEquatable<AcceptCall>, IComparable<AcceptCall>, IComparable
    {
        public T.InputPhoneCall Peer { get; }
        public Arr<byte> Gb { get; }
        public T.PhoneCallProtocol Protocol { get; }
        
        public AcceptCall(
            Some<T.InputPhoneCall> peer,
            Some<Arr<byte>> gb,
            Some<T.PhoneCallProtocol> protocol
        ) {
            Peer = peer;
            Gb = gb;
            Protocol = protocol;
        }
        
        
        (T.InputPhoneCall, Arr<byte>, T.PhoneCallProtocol) CmpTuple =>
            (Peer, Gb, Protocol);

        public bool Equals(AcceptCall other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is AcceptCall x && Equals(x);
        public static bool operator ==(AcceptCall x, AcceptCall y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AcceptCall x, AcceptCall y) => !(x == y);

        public int CompareTo(AcceptCall other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is AcceptCall x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AcceptCall x, AcceptCall y) => x.CompareTo(y) <= 0;
        public static bool operator <(AcceptCall x, AcceptCall y) => x.CompareTo(y) < 0;
        public static bool operator >(AcceptCall x, AcceptCall y) => x.CompareTo(y) > 0;
        public static bool operator >=(AcceptCall x, AcceptCall y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Gb: {Gb}, Protocol: {Protocol})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3bd2b4a0);
            Write(Peer, bw, WriteSerializable);
            Write(Gb, bw, WriteBytes);
            Write(Protocol, bw, WriteSerializable);
        }
        
        T.Phone.PhoneCall ITlFunc<T.Phone.PhoneCall>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Phone.PhoneCall.Deserialize);
    }
}