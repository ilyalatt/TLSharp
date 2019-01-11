using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class ConfirmCall : ITlFunc<T.Phone.PhoneCall>, IEquatable<ConfirmCall>, IComparable<ConfirmCall>, IComparable
    {
        public T.InputPhoneCall Peer { get; }
        public Arr<byte> Ga { get; }
        public long KeyFingerprint { get; }
        public T.PhoneCallProtocol Protocol { get; }
        
        public ConfirmCall(
            Some<T.InputPhoneCall> peer,
            Some<Arr<byte>> ga,
            long keyFingerprint,
            Some<T.PhoneCallProtocol> protocol
        ) {
            Peer = peer;
            Ga = ga;
            KeyFingerprint = keyFingerprint;
            Protocol = protocol;
        }
        
        
        (T.InputPhoneCall, Arr<byte>, long, T.PhoneCallProtocol) CmpTuple =>
            (Peer, Ga, KeyFingerprint, Protocol);

        public bool Equals(ConfirmCall other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ConfirmCall x && Equals(x);
        public static bool operator ==(ConfirmCall x, ConfirmCall y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ConfirmCall x, ConfirmCall y) => !(x == y);

        public int CompareTo(ConfirmCall other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ConfirmCall x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ConfirmCall x, ConfirmCall y) => x.CompareTo(y) <= 0;
        public static bool operator <(ConfirmCall x, ConfirmCall y) => x.CompareTo(y) < 0;
        public static bool operator >(ConfirmCall x, ConfirmCall y) => x.CompareTo(y) > 0;
        public static bool operator >=(ConfirmCall x, ConfirmCall y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Ga: {Ga}, KeyFingerprint: {KeyFingerprint}, Protocol: {Protocol})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2efe1722);
            Write(Peer, bw, WriteSerializable);
            Write(Ga, bw, WriteBytes);
            Write(KeyFingerprint, bw, WriteLong);
            Write(Protocol, bw, WriteSerializable);
        }
        
        T.Phone.PhoneCall ITlFunc<T.Phone.PhoneCall>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Phone.PhoneCall.Deserialize);
    }
}