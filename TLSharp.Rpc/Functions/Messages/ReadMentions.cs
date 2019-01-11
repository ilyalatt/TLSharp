using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReadMentions : ITlFunc<T.Messages.AffectedHistory>, IEquatable<ReadMentions>, IComparable<ReadMentions>, IComparable
    {
        public T.InputPeer Peer { get; }
        
        public ReadMentions(
            Some<T.InputPeer> peer
        ) {
            Peer = peer;
        }
        
        
        T.InputPeer CmpTuple =>
            Peer;

        public bool Equals(ReadMentions other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReadMentions x && Equals(x);
        public static bool operator ==(ReadMentions x, ReadMentions y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReadMentions x, ReadMentions y) => !(x == y);

        public int CompareTo(ReadMentions other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReadMentions x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReadMentions x, ReadMentions y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReadMentions x, ReadMentions y) => x.CompareTo(y) < 0;
        public static bool operator >(ReadMentions x, ReadMentions y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReadMentions x, ReadMentions y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0f0189d3);
            Write(Peer, bw, WriteSerializable);
        }
        
        T.Messages.AffectedHistory ITlFunc<T.Messages.AffectedHistory>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedHistory.Deserialize);
    }
}