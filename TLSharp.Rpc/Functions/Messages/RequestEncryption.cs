using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class RequestEncryption : ITlFunc<T.EncryptedChat>, IEquatable<RequestEncryption>, IComparable<RequestEncryption>, IComparable
    {
        public T.InputUser UserId { get; }
        public int RandomId { get; }
        public Arr<byte> Ga { get; }
        
        public RequestEncryption(
            Some<T.InputUser> userId,
            int randomId,
            Some<Arr<byte>> ga
        ) {
            UserId = userId;
            RandomId = randomId;
            Ga = ga;
        }
        
        
        (T.InputUser, int, Arr<byte>) CmpTuple =>
            (UserId, RandomId, Ga);

        public bool Equals(RequestEncryption other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is RequestEncryption x && Equals(x);
        public static bool operator ==(RequestEncryption x, RequestEncryption y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RequestEncryption x, RequestEncryption y) => !(x == y);

        public int CompareTo(RequestEncryption other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is RequestEncryption x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RequestEncryption x, RequestEncryption y) => x.CompareTo(y) <= 0;
        public static bool operator <(RequestEncryption x, RequestEncryption y) => x.CompareTo(y) < 0;
        public static bool operator >(RequestEncryption x, RequestEncryption y) => x.CompareTo(y) > 0;
        public static bool operator >=(RequestEncryption x, RequestEncryption y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(UserId: {UserId}, RandomId: {RandomId}, Ga: {Ga})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf64daf43);
            Write(UserId, bw, WriteSerializable);
            Write(RandomId, bw, WriteInt);
            Write(Ga, bw, WriteBytes);
        }
        
        T.EncryptedChat ITlFunc<T.EncryptedChat>.DeserializeResult(BinaryReader br) =>
            Read(br, T.EncryptedChat.Deserialize);
    }
}