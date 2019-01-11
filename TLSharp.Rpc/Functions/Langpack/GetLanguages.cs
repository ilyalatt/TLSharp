using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Langpack
{
    public sealed class GetLanguages : ITlFunc<Arr<T.LangPackLanguage>>, IEquatable<GetLanguages>, IComparable<GetLanguages>, IComparable
    {

        
        public GetLanguages(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetLanguages other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetLanguages x && Equals(x);
        public static bool operator ==(GetLanguages x, GetLanguages y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetLanguages x, GetLanguages y) => !(x == y);

        public int CompareTo(GetLanguages other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetLanguages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetLanguages x, GetLanguages y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetLanguages x, GetLanguages y) => x.CompareTo(y) < 0;
        public static bool operator >(GetLanguages x, GetLanguages y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetLanguages x, GetLanguages y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x800fd57d);

        }
        
        Arr<T.LangPackLanguage> ITlFunc<Arr<T.LangPackLanguage>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.LangPackLanguage.Deserialize));
    }
}