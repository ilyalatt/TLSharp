using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ReportPeer : ITlFunc<bool>, IEquatable<ReportPeer>, IComparable<ReportPeer>, IComparable
    {
        public T.InputPeer Peer { get; }
        public T.ReportReason Reason { get; }
        
        public ReportPeer(
            Some<T.InputPeer> peer,
            Some<T.ReportReason> reason
        ) {
            Peer = peer;
            Reason = reason;
        }
        
        
        (T.InputPeer, T.ReportReason) CmpTuple =>
            (Peer, Reason);

        public bool Equals(ReportPeer other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ReportPeer x && Equals(x);
        public static bool operator ==(ReportPeer x, ReportPeer y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReportPeer x, ReportPeer y) => !(x == y);

        public int CompareTo(ReportPeer other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReportPeer x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReportPeer x, ReportPeer y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReportPeer x, ReportPeer y) => x.CompareTo(y) < 0;
        public static bool operator >(ReportPeer x, ReportPeer y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReportPeer x, ReportPeer y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Reason: {Reason})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xae189d5f);
            Write(Peer, bw, WriteSerializable);
            Write(Reason, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}