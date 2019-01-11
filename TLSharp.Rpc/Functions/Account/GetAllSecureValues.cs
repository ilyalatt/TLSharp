using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetAllSecureValues : ITlFunc<Arr<T.SecureValue>>, IEquatable<GetAllSecureValues>, IComparable<GetAllSecureValues>, IComparable
    {

        
        public GetAllSecureValues(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetAllSecureValues other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetAllSecureValues x && Equals(x);
        public static bool operator ==(GetAllSecureValues x, GetAllSecureValues y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAllSecureValues x, GetAllSecureValues y) => !(x == y);

        public int CompareTo(GetAllSecureValues other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetAllSecureValues x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAllSecureValues x, GetAllSecureValues y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAllSecureValues x, GetAllSecureValues y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAllSecureValues x, GetAllSecureValues y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAllSecureValues x, GetAllSecureValues y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb288bc7d);

        }
        
        Arr<T.SecureValue> ITlFunc<Arr<T.SecureValue>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.SecureValue.Deserialize));
    }
}