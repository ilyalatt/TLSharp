using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SendVerifyEmailCode : ITlFunc<T.Account.SentEmailCode>, IEquatable<SendVerifyEmailCode>, IComparable<SendVerifyEmailCode>, IComparable
    {
        public string Email { get; }
        
        public SendVerifyEmailCode(
            Some<string> email
        ) {
            Email = email;
        }
        
        
        string CmpTuple =>
            Email;

        public bool Equals(SendVerifyEmailCode other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendVerifyEmailCode x && Equals(x);
        public static bool operator ==(SendVerifyEmailCode x, SendVerifyEmailCode y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendVerifyEmailCode x, SendVerifyEmailCode y) => !(x == y);

        public int CompareTo(SendVerifyEmailCode other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendVerifyEmailCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendVerifyEmailCode x, SendVerifyEmailCode y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendVerifyEmailCode x, SendVerifyEmailCode y) => x.CompareTo(y) < 0;
        public static bool operator >(SendVerifyEmailCode x, SendVerifyEmailCode y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendVerifyEmailCode x, SendVerifyEmailCode y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Email: {Email})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x7011509f);
            Write(Email, bw, WriteString);
        }
        
        T.Account.SentEmailCode ITlFunc<T.Account.SentEmailCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.SentEmailCode.Deserialize);
    }
}