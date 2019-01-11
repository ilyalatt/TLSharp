using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ImportAuthorization : ITlFunc<T.Auth.Authorization>, IEquatable<ImportAuthorization>, IComparable<ImportAuthorization>, IComparable
    {
        public int Id { get; }
        public Arr<byte> Bytes { get; }
        
        public ImportAuthorization(
            int id,
            Some<Arr<byte>> bytes
        ) {
            Id = id;
            Bytes = bytes;
        }
        
        
        (int, Arr<byte>) CmpTuple =>
            (Id, Bytes);

        public bool Equals(ImportAuthorization other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ImportAuthorization x && Equals(x);
        public static bool operator ==(ImportAuthorization x, ImportAuthorization y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ImportAuthorization x, ImportAuthorization y) => !(x == y);

        public int CompareTo(ImportAuthorization other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ImportAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ImportAuthorization x, ImportAuthorization y) => x.CompareTo(y) <= 0;
        public static bool operator <(ImportAuthorization x, ImportAuthorization y) => x.CompareTo(y) < 0;
        public static bool operator >(ImportAuthorization x, ImportAuthorization y) => x.CompareTo(y) > 0;
        public static bool operator >=(ImportAuthorization x, ImportAuthorization y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id}, Bytes: {Bytes})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe3ef9613);
            Write(Id, bw, WriteInt);
            Write(Bytes, bw, WriteBytes);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}