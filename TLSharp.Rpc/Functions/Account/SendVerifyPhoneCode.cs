using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SendVerifyPhoneCode : ITlFunc<T.Auth.SentCode>, IEquatable<SendVerifyPhoneCode>, IComparable<SendVerifyPhoneCode>, IComparable
    {
        public bool AllowFlashcall { get; }
        public string PhoneNumber { get; }
        public Option<bool> CurrentNumber { get; }
        
        public SendVerifyPhoneCode(
            bool allowFlashcall,
            Some<string> phoneNumber,
            Option<bool> currentNumber
        ) {
            AllowFlashcall = allowFlashcall;
            PhoneNumber = phoneNumber;
            CurrentNumber = currentNumber;
        }
        
        
        (bool, string, Option<bool>) CmpTuple =>
            (AllowFlashcall, PhoneNumber, CurrentNumber);

        public bool Equals(SendVerifyPhoneCode other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendVerifyPhoneCode x && Equals(x);
        public static bool operator ==(SendVerifyPhoneCode x, SendVerifyPhoneCode y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendVerifyPhoneCode x, SendVerifyPhoneCode y) => !(x == y);

        public int CompareTo(SendVerifyPhoneCode other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendVerifyPhoneCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendVerifyPhoneCode x, SendVerifyPhoneCode y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendVerifyPhoneCode x, SendVerifyPhoneCode y) => x.CompareTo(y) < 0;
        public static bool operator >(SendVerifyPhoneCode x, SendVerifyPhoneCode y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendVerifyPhoneCode x, SendVerifyPhoneCode y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(AllowFlashcall: {AllowFlashcall}, PhoneNumber: {PhoneNumber}, CurrentNumber: {CurrentNumber})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x823380b4);
            Write(MaskBit(0, AllowFlashcall) | MaskBit(0, CurrentNumber), bw, WriteInt);
            Write(PhoneNumber, bw, WriteString);
            Write(CurrentNumber, bw, WriteOption<bool>(WriteBool));
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}