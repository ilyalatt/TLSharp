using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Users
{
    public sealed class GetUsers : ITlFunc<Arr<T.User>>, IEquatable<GetUsers>, IComparable<GetUsers>, IComparable
    {
        public Arr<T.InputUser> Id { get; }
        
        public GetUsers(
            Some<Arr<T.InputUser>> id
        ) {
            Id = id;
        }
        
        
        Arr<T.InputUser> CmpTuple =>
            Id;

        public bool Equals(GetUsers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetUsers x && Equals(x);
        public static bool operator ==(GetUsers x, GetUsers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetUsers x, GetUsers y) => !(x == y);

        public int CompareTo(GetUsers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetUsers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetUsers x, GetUsers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetUsers x, GetUsers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetUsers x, GetUsers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetUsers x, GetUsers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0d91a548);
            Write(Id, bw, WriteVector<T.InputUser>(WriteSerializable));
        }
        
        Arr<T.User> ITlFunc<Arr<T.User>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.User.Deserialize));
    }
}