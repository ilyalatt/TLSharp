using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class BindTempAuthKey : ITlFunc<bool>, IEquatable<BindTempAuthKey>, IComparable<BindTempAuthKey>, IComparable
    {
        public long PermAuthKeyId { get; }
        public long Nonce { get; }
        public int ExpiresAt { get; }
        public Arr<byte> EncryptedMessage { get; }
        
        public BindTempAuthKey(
            long permAuthKeyId,
            long nonce,
            int expiresAt,
            Some<Arr<byte>> encryptedMessage
        ) {
            PermAuthKeyId = permAuthKeyId;
            Nonce = nonce;
            ExpiresAt = expiresAt;
            EncryptedMessage = encryptedMessage;
        }
        
        
        (long, long, int, Arr<byte>) CmpTuple =>
            (PermAuthKeyId, Nonce, ExpiresAt, EncryptedMessage);

        public bool Equals(BindTempAuthKey other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is BindTempAuthKey x && Equals(x);
        public static bool operator ==(BindTempAuthKey x, BindTempAuthKey y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(BindTempAuthKey x, BindTempAuthKey y) => !(x == y);

        public int CompareTo(BindTempAuthKey other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is BindTempAuthKey x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(BindTempAuthKey x, BindTempAuthKey y) => x.CompareTo(y) <= 0;
        public static bool operator <(BindTempAuthKey x, BindTempAuthKey y) => x.CompareTo(y) < 0;
        public static bool operator >(BindTempAuthKey x, BindTempAuthKey y) => x.CompareTo(y) > 0;
        public static bool operator >=(BindTempAuthKey x, BindTempAuthKey y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PermAuthKeyId: {PermAuthKeyId}, Nonce: {Nonce}, ExpiresAt: {ExpiresAt}, EncryptedMessage: {EncryptedMessage})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcdd42a05);
            Write(PermAuthKeyId, bw, WriteLong);
            Write(Nonce, bw, WriteLong);
            Write(ExpiresAt, bw, WriteInt);
            Write(EncryptedMessage, bw, WriteBytes);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}