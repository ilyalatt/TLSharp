using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class SendInvites : ITlFunc<bool>, IEquatable<SendInvites>, IComparable<SendInvites>, IComparable
    {
        public Arr<string> PhoneNumbers { get; }
        public string Message { get; }
        
        public SendInvites(
            Some<Arr<string>> phoneNumbers,
            Some<string> message
        ) {
            PhoneNumbers = phoneNumbers;
            Message = message;
        }
        
        
        (Arr<string>, string) CmpTuple =>
            (PhoneNumbers, Message);

        public bool Equals(SendInvites other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendInvites x && Equals(x);
        public static bool operator ==(SendInvites x, SendInvites y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendInvites x, SendInvites y) => !(x == y);

        public int CompareTo(SendInvites other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendInvites x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendInvites x, SendInvites y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendInvites x, SendInvites y) => x.CompareTo(y) < 0;
        public static bool operator >(SendInvites x, SendInvites y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendInvites x, SendInvites y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PhoneNumbers: {PhoneNumbers}, Message: {Message})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x771c1d97);
            Write(PhoneNumbers, bw, WriteVector<string>(WriteString));
            Write(Message, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}