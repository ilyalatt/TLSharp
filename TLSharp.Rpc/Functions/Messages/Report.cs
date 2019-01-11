using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class Report : ITlFunc<bool>, IEquatable<Report>, IComparable<Report>, IComparable
    {
        public T.InputPeer Peer { get; }
        public Arr<int> Id { get; }
        public T.ReportReason Reason { get; }
        
        public Report(
            Some<T.InputPeer> peer,
            Some<Arr<int>> id,
            Some<T.ReportReason> reason
        ) {
            Peer = peer;
            Id = id;
            Reason = reason;
        }
        
        
        (T.InputPeer, Arr<int>, T.ReportReason) CmpTuple =>
            (Peer, Id, Reason);

        public bool Equals(Report other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is Report x && Equals(x);
        public static bool operator ==(Report x, Report y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Report x, Report y) => !(x == y);

        public int CompareTo(Report other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is Report x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Report x, Report y) => x.CompareTo(y) <= 0;
        public static bool operator <(Report x, Report y) => x.CompareTo(y) < 0;
        public static bool operator >(Report x, Report y) => x.CompareTo(y) > 0;
        public static bool operator >=(Report x, Report y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Id: {Id}, Reason: {Reason})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xbd82b658);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
            Write(Reason, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}