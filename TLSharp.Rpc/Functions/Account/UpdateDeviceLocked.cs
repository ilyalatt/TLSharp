using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateDeviceLocked : ITlFunc<bool>, IEquatable<UpdateDeviceLocked>, IComparable<UpdateDeviceLocked>, IComparable
    {
        public int Period { get; }
        
        public UpdateDeviceLocked(
            int period
        ) {
            Period = period;
        }
        
        
        int CmpTuple =>
            Period;

        public bool Equals(UpdateDeviceLocked other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is UpdateDeviceLocked x && Equals(x);
        public static bool operator ==(UpdateDeviceLocked x, UpdateDeviceLocked y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdateDeviceLocked x, UpdateDeviceLocked y) => !(x == y);

        public int CompareTo(UpdateDeviceLocked other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UpdateDeviceLocked x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdateDeviceLocked x, UpdateDeviceLocked y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdateDeviceLocked x, UpdateDeviceLocked y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdateDeviceLocked x, UpdateDeviceLocked y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdateDeviceLocked x, UpdateDeviceLocked y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Period: {Period})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x38df3532);
            Write(Period, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}