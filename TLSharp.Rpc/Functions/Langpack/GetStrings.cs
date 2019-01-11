using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Langpack
{
    public sealed class GetStrings : ITlFunc<Arr<T.LangPackString>>, IEquatable<GetStrings>, IComparable<GetStrings>, IComparable
    {
        public string LangCode { get; }
        public Arr<string> Keys { get; }
        
        public GetStrings(
            Some<string> langCode,
            Some<Arr<string>> keys
        ) {
            LangCode = langCode;
            Keys = keys;
        }
        
        
        (string, Arr<string>) CmpTuple =>
            (LangCode, Keys);

        public bool Equals(GetStrings other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetStrings x && Equals(x);
        public static bool operator ==(GetStrings x, GetStrings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetStrings x, GetStrings y) => !(x == y);

        public int CompareTo(GetStrings other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetStrings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetStrings x, GetStrings y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetStrings x, GetStrings y) => x.CompareTo(y) < 0;
        public static bool operator >(GetStrings x, GetStrings y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetStrings x, GetStrings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(LangCode: {LangCode}, Keys: {Keys})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2e1ee318);
            Write(LangCode, bw, WriteString);
            Write(Keys, bw, WriteVector<string>(WriteString));
        }
        
        Arr<T.LangPackString> ITlFunc<Arr<T.LangPackString>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.LangPackString.Deserialize));
    }
}