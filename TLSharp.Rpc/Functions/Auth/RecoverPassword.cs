using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class RecoverPassword : ITlFunc<T.Auth.Authorization>, IEquatable<RecoverPassword>, IComparable<RecoverPassword>, IComparable
    {
        public string Code { get; }
        
        public RecoverPassword(
            Some<string> code
        ) {
            Code = code;
        }
        
        
        string CmpTuple =>
            Code;

        public bool Equals(RecoverPassword other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is RecoverPassword x && Equals(x);
        public static bool operator ==(RecoverPassword x, RecoverPassword y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RecoverPassword x, RecoverPassword y) => !(x == y);

        public int CompareTo(RecoverPassword other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is RecoverPassword x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RecoverPassword x, RecoverPassword y) => x.CompareTo(y) <= 0;
        public static bool operator <(RecoverPassword x, RecoverPassword y) => x.CompareTo(y) < 0;
        public static bool operator >(RecoverPassword x, RecoverPassword y) => x.CompareTo(y) > 0;
        public static bool operator >=(RecoverPassword x, RecoverPassword y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Code: {Code})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4ea56e92);
            Write(Code, bw, WriteString);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}