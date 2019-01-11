using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SetPrivacy : ITlFunc<T.Account.PrivacyRules>, IEquatable<SetPrivacy>, IComparable<SetPrivacy>, IComparable
    {
        public T.InputPrivacyKey Key { get; }
        public Arr<T.InputPrivacyRule> Rules { get; }
        
        public SetPrivacy(
            Some<T.InputPrivacyKey> key,
            Some<Arr<T.InputPrivacyRule>> rules
        ) {
            Key = key;
            Rules = rules;
        }
        
        
        (T.InputPrivacyKey, Arr<T.InputPrivacyRule>) CmpTuple =>
            (Key, Rules);

        public bool Equals(SetPrivacy other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SetPrivacy x && Equals(x);
        public static bool operator ==(SetPrivacy x, SetPrivacy y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetPrivacy x, SetPrivacy y) => !(x == y);

        public int CompareTo(SetPrivacy other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetPrivacy x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetPrivacy x, SetPrivacy y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetPrivacy x, SetPrivacy y) => x.CompareTo(y) < 0;
        public static bool operator >(SetPrivacy x, SetPrivacy y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetPrivacy x, SetPrivacy y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Key: {Key}, Rules: {Rules})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc9f81ce8);
            Write(Key, bw, WriteSerializable);
            Write(Rules, bw, WriteVector<T.InputPrivacyRule>(WriteSerializable));
        }
        
        T.Account.PrivacyRules ITlFunc<T.Account.PrivacyRules>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.PrivacyRules.Deserialize);
    }
}