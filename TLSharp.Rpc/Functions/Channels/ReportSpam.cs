using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ReportSpam : ITlFunc<bool>, IEquatable<ReportSpam>, IComparable<ReportSpam>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputUser UserId { get; }
        public Arr<int> Id { get; }
        
        public ReportSpam(
            Some<T.InputChannel> channel,
            Some<T.InputUser> userId,
            Some<Arr<int>> id
        ) {
            Channel = channel;
            UserId = userId;
            Id = id;
        }
        
        
        (T.InputChannel, T.InputUser, Arr<int>) CmpTuple =>
            (Channel, UserId, Id);

        public bool Equals(ReportSpam other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReportSpam x && Equals(x);
        public static bool operator ==(ReportSpam x, ReportSpam y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReportSpam x, ReportSpam y) => !(x == y);

        public int CompareTo(ReportSpam other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReportSpam x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReportSpam x, ReportSpam y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReportSpam x, ReportSpam y) => x.CompareTo(y) < 0;
        public static bool operator >(ReportSpam x, ReportSpam y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReportSpam x, ReportSpam y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, UserId: {UserId}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfe087810);
            Write(Channel, bw, WriteSerializable);
            Write(UserId, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}