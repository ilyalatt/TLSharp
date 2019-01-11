using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Users
{
    public sealed class SetSecureValueErrors : ITlFunc<bool>, IEquatable<SetSecureValueErrors>, IComparable<SetSecureValueErrors>, IComparable
    {
        public T.InputUser Id { get; }
        public Arr<T.SecureValueError> Errors { get; }
        
        public SetSecureValueErrors(
            Some<T.InputUser> id,
            Some<Arr<T.SecureValueError>> errors
        ) {
            Id = id;
            Errors = errors;
        }
        
        
        (T.InputUser, Arr<T.SecureValueError>) CmpTuple =>
            (Id, Errors);

        public bool Equals(SetSecureValueErrors other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetSecureValueErrors x && Equals(x);
        public static bool operator ==(SetSecureValueErrors x, SetSecureValueErrors y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetSecureValueErrors x, SetSecureValueErrors y) => !(x == y);

        public int CompareTo(SetSecureValueErrors other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetSecureValueErrors x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetSecureValueErrors x, SetSecureValueErrors y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetSecureValueErrors x, SetSecureValueErrors y) => x.CompareTo(y) < 0;
        public static bool operator >(SetSecureValueErrors x, SetSecureValueErrors y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetSecureValueErrors x, SetSecureValueErrors y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id}, Errors: {Errors})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x90c894b5);
            Write(Id, bw, WriteSerializable);
            Write(Errors, bw, WriteVector<T.SecureValueError>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}