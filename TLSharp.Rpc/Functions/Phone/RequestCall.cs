using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class RequestCall : ITlFunc<T.Phone.PhoneCall>, IEquatable<RequestCall>, IComparable<RequestCall>, IComparable
    {
        public T.InputUser UserId { get; }
        public int RandomId { get; }
        public Arr<byte> GaHash { get; }
        public T.PhoneCallProtocol Protocol { get; }
        
        public RequestCall(
            Some<T.InputUser> userId,
            int randomId,
            Some<Arr<byte>> gaHash,
            Some<T.PhoneCallProtocol> protocol
        ) {
            UserId = userId;
            RandomId = randomId;
            GaHash = gaHash;
            Protocol = protocol;
        }
        
        
        (T.InputUser, int, Arr<byte>, T.PhoneCallProtocol) CmpTuple =>
            (UserId, RandomId, GaHash, Protocol);

        public bool Equals(RequestCall other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is RequestCall x && Equals(x);
        public static bool operator ==(RequestCall x, RequestCall y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RequestCall x, RequestCall y) => !(x == y);

        public int CompareTo(RequestCall other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is RequestCall x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RequestCall x, RequestCall y) => x.CompareTo(y) <= 0;
        public static bool operator <(RequestCall x, RequestCall y) => x.CompareTo(y) < 0;
        public static bool operator >(RequestCall x, RequestCall y) => x.CompareTo(y) > 0;
        public static bool operator >=(RequestCall x, RequestCall y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(UserId: {UserId}, RandomId: {RandomId}, GaHash: {GaHash}, Protocol: {Protocol})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5b95b3d4);
            Write(UserId, bw, WriteSerializable);
            Write(RandomId, bw, WriteInt);
            Write(GaHash, bw, WriteBytes);
            Write(Protocol, bw, WriteSerializable);
        }
        
        T.Phone.PhoneCall ITlFunc<T.Phone.PhoneCall>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Phone.PhoneCall.Deserialize);
    }
}