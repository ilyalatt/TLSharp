using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class GetUserPhotos : ITlFunc<T.Photos.Photos>, IEquatable<GetUserPhotos>, IComparable<GetUserPhotos>, IComparable
    {
        public T.InputUser UserId { get; }
        public int Offset { get; }
        public long MaxId { get; }
        public int Limit { get; }
        
        public GetUserPhotos(
            Some<T.InputUser> userId,
            int offset,
            long maxId,
            int limit
        ) {
            UserId = userId;
            Offset = offset;
            MaxId = maxId;
            Limit = limit;
        }
        
        
        (T.InputUser, int, long, int) CmpTuple =>
            (UserId, Offset, MaxId, Limit);

        public bool Equals(GetUserPhotos other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetUserPhotos x && Equals(x);
        public static bool operator ==(GetUserPhotos x, GetUserPhotos y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetUserPhotos x, GetUserPhotos y) => !(x == y);

        public int CompareTo(GetUserPhotos other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetUserPhotos x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetUserPhotos x, GetUserPhotos y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetUserPhotos x, GetUserPhotos y) => x.CompareTo(y) < 0;
        public static bool operator >(GetUserPhotos x, GetUserPhotos y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetUserPhotos x, GetUserPhotos y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(UserId: {UserId}, Offset: {Offset}, MaxId: {MaxId}, Limit: {Limit})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x91cd32a8);
            Write(UserId, bw, WriteSerializable);
            Write(Offset, bw, WriteInt);
            Write(MaxId, bw, WriteLong);
            Write(Limit, bw, WriteInt);
        }
        
        T.Photos.Photos ITlFunc<T.Photos.Photos>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Photos.Photos.Deserialize);
    }
}