using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class SendCode : ITlFunc<T.Auth.SentCode>, IEquatable<SendCode>, IComparable<SendCode>, IComparable
    {
        public bool AllowFlashcall { get; }
        public string PhoneNumber { get; }
        public Option<bool> CurrentNumber { get; }
        public int ApiId { get; }
        public string ApiHash { get; }
        
        public SendCode(
            bool allowFlashcall,
            Some<string> phoneNumber,
            Option<bool> currentNumber,
            int apiId,
            Some<string> apiHash
        ) {
            AllowFlashcall = allowFlashcall;
            PhoneNumber = phoneNumber;
            CurrentNumber = currentNumber;
            ApiId = apiId;
            ApiHash = apiHash;
        }
        
        
        (bool, string, Option<bool>, int, string) CmpTuple =>
            (AllowFlashcall, PhoneNumber, CurrentNumber, ApiId, ApiHash);

        public bool Equals(SendCode other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SendCode x && Equals(x);
        public static bool operator ==(SendCode x, SendCode y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendCode x, SendCode y) => !(x == y);

        public int CompareTo(SendCode other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SendCode x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendCode x, SendCode y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendCode x, SendCode y) => x.CompareTo(y) < 0;
        public static bool operator >(SendCode x, SendCode y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendCode x, SendCode y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(AllowFlashcall: {AllowFlashcall}, PhoneNumber: {PhoneNumber}, CurrentNumber: {CurrentNumber}, ApiId: {ApiId}, ApiHash: {ApiHash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x86aef0ec);
            Write(MaskBit(0, AllowFlashcall) | MaskBit(0, CurrentNumber), bw, WriteInt);
            Write(PhoneNumber, bw, WriteString);
            Write(CurrentNumber, bw, WriteOption<bool>(WriteBool));
            Write(ApiId, bw, WriteInt);
            Write(ApiHash, bw, WriteString);
        }
        
        T.Auth.SentCode ITlFunc<T.Auth.SentCode>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.SentCode.Deserialize);
    }
}