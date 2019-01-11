using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class UpdateProfilePhoto : ITlFunc<T.UserProfilePhoto>, IEquatable<UpdateProfilePhoto>, IComparable<UpdateProfilePhoto>, IComparable
    {
        public T.InputPhoto Id { get; }
        
        public UpdateProfilePhoto(
            Some<T.InputPhoto> id
        ) {
            Id = id;
        }
        
        
        T.InputPhoto CmpTuple =>
            Id;

        public bool Equals(UpdateProfilePhoto other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is UpdateProfilePhoto x && Equals(x);
        public static bool operator ==(UpdateProfilePhoto x, UpdateProfilePhoto y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdateProfilePhoto x, UpdateProfilePhoto y) => !(x == y);

        public int CompareTo(UpdateProfilePhoto other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is UpdateProfilePhoto x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdateProfilePhoto x, UpdateProfilePhoto y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdateProfilePhoto x, UpdateProfilePhoto y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdateProfilePhoto x, UpdateProfilePhoto y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdateProfilePhoto x, UpdateProfilePhoto y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf0bb5152);
            Write(Id, bw, WriteSerializable);
        }
        
        T.UserProfilePhoto ITlFunc<T.UserProfilePhoto>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UserProfilePhoto.Deserialize);
    }
}