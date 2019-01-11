using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateStatus : ITlFunc<bool>, IEquatable<UpdateStatus>, IComparable<UpdateStatus>, IComparable
    {
        public bool Offline { get; }
        
        public UpdateStatus(
            bool offline
        ) {
            Offline = offline;
        }
        
        
        bool CmpTuple =>
            Offline;

        public bool Equals(UpdateStatus other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is UpdateStatus x && Equals(x);
        public static bool operator ==(UpdateStatus x, UpdateStatus y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdateStatus x, UpdateStatus y) => !(x == y);

        public int CompareTo(UpdateStatus other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UpdateStatus x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdateStatus x, UpdateStatus y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdateStatus x, UpdateStatus y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdateStatus x, UpdateStatus y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdateStatus x, UpdateStatus y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Offline: {Offline})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x6628562c);
            Write(Offline, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}