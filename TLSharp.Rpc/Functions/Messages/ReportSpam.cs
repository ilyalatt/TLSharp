using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReportSpam : ITlFunc<bool>, IEquatable<ReportSpam>, IComparable<ReportSpam>, IComparable
    {
        public T.InputPeer Peer { get; }
        
        public ReportSpam(
            Some<T.InputPeer> peer
        ) {
            Peer = peer;
        }
        
        
        T.InputPeer CmpTuple =>
            Peer;

        public bool Equals(ReportSpam other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ReportSpam x && Equals(x);
        public static bool operator ==(ReportSpam x, ReportSpam y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReportSpam x, ReportSpam y) => !(x == y);

        public int CompareTo(ReportSpam other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReportSpam x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReportSpam x, ReportSpam y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReportSpam x, ReportSpam y) => x.CompareTo(y) < 0;
        public static bool operator >(ReportSpam x, ReportSpam y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReportSpam x, ReportSpam y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xcf1592db);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}