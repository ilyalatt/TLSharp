using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetPrivacy : ITlFunc<T.Account.PrivacyRules>, IEquatable<GetPrivacy>, IComparable<GetPrivacy>, IComparable
    {
        public T.InputPrivacyKey Key { get; }
        
        public GetPrivacy(
            Some<T.InputPrivacyKey> key
        ) {
            Key = key;
        }
        
        
        T.InputPrivacyKey CmpTuple =>
            Key;

        public bool Equals(GetPrivacy other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetPrivacy x && Equals(x);
        public static bool operator ==(GetPrivacy x, GetPrivacy y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPrivacy x, GetPrivacy y) => !(x == y);

        public int CompareTo(GetPrivacy other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetPrivacy x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPrivacy x, GetPrivacy y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPrivacy x, GetPrivacy y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPrivacy x, GetPrivacy y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPrivacy x, GetPrivacy y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Key: {Key})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xdadbc950);
            Write(Key, bw, WriteSerializable);
        }
        
        T.Account.PrivacyRules ITlFunc<T.Account.PrivacyRules>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.PrivacyRules.Deserialize);
    }
}