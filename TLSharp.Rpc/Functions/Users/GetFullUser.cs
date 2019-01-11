using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Users
{
    public sealed class GetFullUser : ITlFunc<T.UserFull>, IEquatable<GetFullUser>, IComparable<GetFullUser>, IComparable
    {
        public T.InputUser Id { get; }
        
        public GetFullUser(
            Some<T.InputUser> id
        ) {
            Id = id;
        }
        
        
        T.InputUser CmpTuple =>
            Id;

        public bool Equals(GetFullUser other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetFullUser x && Equals(x);
        public static bool operator ==(GetFullUser x, GetFullUser y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetFullUser x, GetFullUser y) => !(x == y);

        public int CompareTo(GetFullUser other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetFullUser x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetFullUser x, GetFullUser y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetFullUser x, GetFullUser y) => x.CompareTo(y) < 0;
        public static bool operator >(GetFullUser x, GetFullUser y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetFullUser x, GetFullUser y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xca30a5b1);
            Write(Id, bw, WriteSerializable);
        }
        
        T.UserFull ITlFunc<T.UserFull>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UserFull.Deserialize);
    }
}