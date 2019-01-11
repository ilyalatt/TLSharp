using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class AcceptTermsOfService : ITlFunc<bool>, IEquatable<AcceptTermsOfService>, IComparable<AcceptTermsOfService>, IComparable
    {
        public T.DataJson Id { get; }
        
        public AcceptTermsOfService(
            Some<T.DataJson> id
        ) {
            Id = id;
        }
        
        
        T.DataJson CmpTuple =>
            Id;

        public bool Equals(AcceptTermsOfService other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is AcceptTermsOfService x && Equals(x);
        public static bool operator ==(AcceptTermsOfService x, AcceptTermsOfService y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AcceptTermsOfService x, AcceptTermsOfService y) => !(x == y);

        public int CompareTo(AcceptTermsOfService other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is AcceptTermsOfService x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AcceptTermsOfService x, AcceptTermsOfService y) => x.CompareTo(y) <= 0;
        public static bool operator <(AcceptTermsOfService x, AcceptTermsOfService y) => x.CompareTo(y) < 0;
        public static bool operator >(AcceptTermsOfService x, AcceptTermsOfService y) => x.CompareTo(y) > 0;
        public static bool operator >=(AcceptTermsOfService x, AcceptTermsOfService y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xee72f79a);
            Write(Id, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}