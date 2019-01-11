using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Langpack
{
    public sealed class GetLangPack : ITlFunc<T.LangPackDifference>, IEquatable<GetLangPack>, IComparable<GetLangPack>, IComparable
    {
        public string LangCode { get; }
        
        public GetLangPack(
            Some<string> langCode
        ) {
            LangCode = langCode;
        }
        
        
        string CmpTuple =>
            LangCode;

        public bool Equals(GetLangPack other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetLangPack x && Equals(x);
        public static bool operator ==(GetLangPack x, GetLangPack y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetLangPack x, GetLangPack y) => !(x == y);

        public int CompareTo(GetLangPack other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetLangPack x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetLangPack x, GetLangPack y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetLangPack x, GetLangPack y) => x.CompareTo(y) < 0;
        public static bool operator >(GetLangPack x, GetLangPack y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetLangPack x, GetLangPack y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(LangCode: {LangCode})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9ab5c58e);
            Write(LangCode, bw, WriteString);
        }
        
        T.LangPackDifference ITlFunc<T.LangPackDifference>.DeserializeResult(BinaryReader br) =>
            Read(br, T.LangPackDifference.Deserialize);
    }
}