using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadEncryptedHistory : ITlFunc<bool>, IEquatable<ReadEncryptedHistory>, IComparable<ReadEncryptedHistory>, IComparable
    {
        public T.InputEncryptedChat Peer { get; }
        public int MaxDate { get; }
        
        public ReadEncryptedHistory(
            Some<T.InputEncryptedChat> peer,
            int maxDate
        ) {
            Peer = peer;
            MaxDate = maxDate;
        }
        
        
        (T.InputEncryptedChat, int) CmpTuple =>
            (Peer, MaxDate);

        public bool Equals(ReadEncryptedHistory other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReadEncryptedHistory x && Equals(x);
        public static bool operator ==(ReadEncryptedHistory x, ReadEncryptedHistory y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReadEncryptedHistory x, ReadEncryptedHistory y) => !(x == y);

        public int CompareTo(ReadEncryptedHistory other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReadEncryptedHistory x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReadEncryptedHistory x, ReadEncryptedHistory y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReadEncryptedHistory x, ReadEncryptedHistory y) => x.CompareTo(y) < 0;
        public static bool operator >(ReadEncryptedHistory x, ReadEncryptedHistory y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReadEncryptedHistory x, ReadEncryptedHistory y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, MaxDate: {MaxDate})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x7f4b690a);
            Write(Peer, bw, WriteSerializable);
            Write(MaxDate, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}