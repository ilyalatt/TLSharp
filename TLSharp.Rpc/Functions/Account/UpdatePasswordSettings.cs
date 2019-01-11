using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdatePasswordSettings : ITlFunc<bool>, IEquatable<UpdatePasswordSettings>, IComparable<UpdatePasswordSettings>, IComparable
    {
        public Arr<byte> CurrentPasswordHash { get; }
        public T.Account.PasswordInputSettings NewSettings { get; }
        
        public UpdatePasswordSettings(
            Some<Arr<byte>> currentPasswordHash,
            Some<T.Account.PasswordInputSettings> newSettings
        ) {
            CurrentPasswordHash = currentPasswordHash;
            NewSettings = newSettings;
        }
        
        
        (Arr<byte>, T.Account.PasswordInputSettings) CmpTuple =>
            (CurrentPasswordHash, NewSettings);

        public bool Equals(UpdatePasswordSettings other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is UpdatePasswordSettings x && Equals(x);
        public static bool operator ==(UpdatePasswordSettings x, UpdatePasswordSettings y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdatePasswordSettings x, UpdatePasswordSettings y) => !(x == y);

        public int CompareTo(UpdatePasswordSettings other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UpdatePasswordSettings x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdatePasswordSettings x, UpdatePasswordSettings y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdatePasswordSettings x, UpdatePasswordSettings y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdatePasswordSettings x, UpdatePasswordSettings y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdatePasswordSettings x, UpdatePasswordSettings y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(CurrentPasswordHash: {CurrentPasswordHash}, NewSettings: {NewSettings})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfa7c4b86);
            Write(CurrentPasswordHash, bw, WriteBytes);
            Write(NewSettings, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}