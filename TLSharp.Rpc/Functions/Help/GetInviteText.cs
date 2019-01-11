using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetInviteText : ITlFunc<T.Help.InviteText>, IEquatable<GetInviteText>, IComparable<GetInviteText>, IComparable
    {

        
        public GetInviteText(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetInviteText other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetInviteText x && Equals(x);
        public static bool operator ==(GetInviteText x, GetInviteText y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetInviteText x, GetInviteText y) => !(x == y);

        public int CompareTo(GetInviteText other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetInviteText x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetInviteText x, GetInviteText y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetInviteText x, GetInviteText y) => x.CompareTo(y) < 0;
        public static bool operator >(GetInviteText x, GetInviteText y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetInviteText x, GetInviteText y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4d392343);

        }
        
        T.Help.InviteText ITlFunc<T.Help.InviteText>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.InviteText.Deserialize);
    }
}