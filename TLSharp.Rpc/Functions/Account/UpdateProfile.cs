using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateProfile : ITlFunc<T.User>, IEquatable<UpdateProfile>, IComparable<UpdateProfile>, IComparable
    {
        public Option<string> FirstName { get; }
        public Option<string> LastName { get; }
        public Option<string> About { get; }
        
        public UpdateProfile(
            Option<string> firstName,
            Option<string> lastName,
            Option<string> about
        ) {
            FirstName = firstName;
            LastName = lastName;
            About = about;
        }
        
        
        (Option<string>, Option<string>, Option<string>) CmpTuple =>
            (FirstName, LastName, About);

        public bool Equals(UpdateProfile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is UpdateProfile x && Equals(x);
        public static bool operator ==(UpdateProfile x, UpdateProfile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdateProfile x, UpdateProfile y) => !(x == y);

        public int CompareTo(UpdateProfile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is UpdateProfile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdateProfile x, UpdateProfile y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdateProfile x, UpdateProfile y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdateProfile x, UpdateProfile y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdateProfile x, UpdateProfile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(FirstName: {FirstName}, LastName: {LastName}, About: {About})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x78515775);
            Write(MaskBit(0, FirstName) | MaskBit(1, LastName) | MaskBit(2, About), bw, WriteInt);
            Write(FirstName, bw, WriteOption<string>(WriteString));
            Write(LastName, bw, WriteOption<string>(WriteString));
            Write(About, bw, WriteOption<string>(WriteString));
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}