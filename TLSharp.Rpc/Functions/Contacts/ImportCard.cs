using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ImportCard : ITlFunc<T.User>, IEquatable<ImportCard>, IComparable<ImportCard>, IComparable
    {
        public Arr<int> ExportCard { get; }
        
        public ImportCard(
            Some<Arr<int>> exportCard
        ) {
            ExportCard = exportCard;
        }
        
        
        Arr<int> CmpTuple =>
            ExportCard;

        public bool Equals(ImportCard other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ImportCard x && Equals(x);
        public static bool operator ==(ImportCard x, ImportCard y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ImportCard x, ImportCard y) => !(x == y);

        public int CompareTo(ImportCard other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ImportCard x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ImportCard x, ImportCard y) => x.CompareTo(y) <= 0;
        public static bool operator <(ImportCard x, ImportCard y) => x.CompareTo(y) < 0;
        public static bool operator >(ImportCard x, ImportCard y) => x.CompareTo(y) > 0;
        public static bool operator >=(ImportCard x, ImportCard y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ExportCard: {ExportCard})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4fe196fe);
            Write(ExportCard, bw, WriteVector<int>(WriteInt));
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}