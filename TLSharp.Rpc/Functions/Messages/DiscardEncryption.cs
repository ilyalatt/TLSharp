using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DiscardEncryption : ITlFunc<bool>, IEquatable<DiscardEncryption>, IComparable<DiscardEncryption>, IComparable
    {
        public int ChatId { get; }
        
        public DiscardEncryption(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        
        int CmpTuple =>
            ChatId;

        public bool Equals(DiscardEncryption other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DiscardEncryption x && Equals(x);
        public static bool operator ==(DiscardEncryption x, DiscardEncryption y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DiscardEncryption x, DiscardEncryption y) => !(x == y);

        public int CompareTo(DiscardEncryption other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DiscardEncryption x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DiscardEncryption x, DiscardEncryption y) => x.CompareTo(y) <= 0;
        public static bool operator <(DiscardEncryption x, DiscardEncryption y) => x.CompareTo(y) < 0;
        public static bool operator >(DiscardEncryption x, DiscardEncryption y) => x.CompareTo(y) > 0;
        public static bool operator >=(DiscardEncryption x, DiscardEncryption y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xedd923c5);
            Write(ChatId, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}