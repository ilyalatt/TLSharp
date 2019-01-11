using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ExportCard : ITlFunc<Arr<int>>, IEquatable<ExportCard>, IComparable<ExportCard>, IComparable
    {

        
        public ExportCard(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(ExportCard other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ExportCard x && Equals(x);
        public static bool operator ==(ExportCard x, ExportCard y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ExportCard x, ExportCard y) => !(x == y);

        public int CompareTo(ExportCard other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ExportCard x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportCard x, ExportCard y) => x.CompareTo(y) <= 0;
        public static bool operator <(ExportCard x, ExportCard y) => x.CompareTo(y) < 0;
        public static bool operator >(ExportCard x, ExportCard y) => x.CompareTo(y) > 0;
        public static bool operator >=(ExportCard x, ExportCard y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x84e53737);

        }
        
        Arr<int> ITlFunc<Arr<int>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadInt));
    }
}