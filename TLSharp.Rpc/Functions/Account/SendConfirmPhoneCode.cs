using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SendConfirmPhoneCode : ITlFunc<T.Auth.SentCode>, IEquatable<SendConfirmPhoneCode>, IComparable<SendConfirmPhoneCode>, IComparable
    {
        public bool AllowFlashcall { get; }
        public string Hash { get; }
        public Option<bool> CurrentNumber { get; }
        
        public SendConfirmPhoneCode(
            bool allowFlashcall,
            Some<string> hash,
            Option<bool> currentNumber
        ) {
            AllowFlashcall = allowFlashcall;
            Hash = hash;
            CurrentNumber = currentNumber;
        }
        
        
        (bool, string, Option<bool>) CmpTuple =>
            (AllowFlashcall, Hash, CurrentNumber);

        public bool Equals(SendConfirmPhoneCode other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SendConfirmPhoneCode x && Equals(x);
        public static bool operator ==(SendConfirmPhoneCode x, SendConfirmPhoneCode y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendConfirmPhoneCode x, SendConfirmPhoneCode y) => !(x == y);

        public int CompareTo(SendConfirmPhoneCode other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SendConfirmPhoneCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendConfirmPhoneCode x, SendConfirmPhoneCode y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendConfirmPhoneCode x, SendConfirmPhoneCode y) => x.CompareTo(y) < 0;
        public static bool operator >(SendConfirmPhoneCode x, SendConfirmPhoneCode y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendConfirmPhoneCode x, SendConfirmPhoneCode y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(AllowFlashcall: {AllowFlashcall}, Hash: {Hash}, CurrentNumber: {CurrentNumber})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1516d7bd);
            Write(MaskBit(0, AllowFlashcall) | MaskBit(0, CurrentNumber), bw, WriteInt);
            Write(Hash, bw, WriteString);
            Write(CurrentNumber, bw, WriteOption<bool>(WriteBool));
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}