using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class DeletePhotos : ITlFunc<Arr<long>>, IEquatable<DeletePhotos>, IComparable<DeletePhotos>, IComparable
    {
        public Arr<T.InputPhoto> Id { get; }
        
        public DeletePhotos(
            Some<Arr<T.InputPhoto>> id
        ) {
            Id = id;
        }
        
        
        Arr<T.InputPhoto> CmpTuple =>
            Id;

        public bool Equals(DeletePhotos other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeletePhotos x && Equals(x);
        public static bool operator ==(DeletePhotos x, DeletePhotos y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeletePhotos x, DeletePhotos y) => !(x == y);

        public int CompareTo(DeletePhotos other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeletePhotos x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeletePhotos x, DeletePhotos y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeletePhotos x, DeletePhotos y) => x.CompareTo(y) < 0;
        public static bool operator >(DeletePhotos x, DeletePhotos y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeletePhotos x, DeletePhotos y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x87cf7f2f);
            Write(Id, bw, WriteVector<T.InputPhoto>(WriteSerializable));
        }
        
        Arr<long> ITlFunc<Arr<long>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadLong));
    }
}