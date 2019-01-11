using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReportEncryptedSpam : ITlFunc<bool>, IEquatable<ReportEncryptedSpam>, IComparable<ReportEncryptedSpam>, IComparable
    {
        public T.InputEncryptedChat Peer { get; }
        
        public ReportEncryptedSpam(
            Some<T.InputEncryptedChat> peer
        ) {
            Peer = peer;
        }
        
        
        T.InputEncryptedChat CmpTuple =>
            Peer;

        public bool Equals(ReportEncryptedSpam other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ReportEncryptedSpam x && Equals(x);
        public static bool operator ==(ReportEncryptedSpam x, ReportEncryptedSpam y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReportEncryptedSpam x, ReportEncryptedSpam y) => !(x == y);

        public int CompareTo(ReportEncryptedSpam other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ReportEncryptedSpam x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReportEncryptedSpam x, ReportEncryptedSpam y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReportEncryptedSpam x, ReportEncryptedSpam y) => x.CompareTo(y) < 0;
        public static bool operator >(ReportEncryptedSpam x, ReportEncryptedSpam y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReportEncryptedSpam x, ReportEncryptedSpam y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4b0c8c0f);
            Write(Peer, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}