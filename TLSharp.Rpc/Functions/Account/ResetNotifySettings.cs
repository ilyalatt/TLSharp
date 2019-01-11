using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class ResetNotifySettings : ITlFunc<bool>, IEquatable<ResetNotifySettings>, IComparable<ResetNotifySettings>, IComparable
    {

        
        public ResetNotifySettings(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(ResetNotifySettings other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ResetNotifySettings x && Equals(x);
        public static bool operator ==(ResetNotifySettings x, ResetNotifySettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ResetNotifySettings x, ResetNotifySettings y) => !(x == y);

        public int CompareTo(ResetNotifySettings other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ResetNotifySettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ResetNotifySettings x, ResetNotifySettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(ResetNotifySettings x, ResetNotifySettings y) => x.CompareTo(y) < 0;
        public static bool operator >(ResetNotifySettings x, ResetNotifySettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(ResetNotifySettings x, ResetNotifySettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xdb7e1747);

        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}