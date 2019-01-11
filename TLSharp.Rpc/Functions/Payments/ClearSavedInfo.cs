using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class ClearSavedInfo : ITlFunc<bool>, IEquatable<ClearSavedInfo>, IComparable<ClearSavedInfo>, IComparable
    {
        public bool Credentials { get; }
        public bool Info { get; }
        
        public ClearSavedInfo(
            bool credentials,
            bool info
        ) {
            Credentials = credentials;
            Info = info;
        }
        
        
        (bool, bool) CmpTuple =>
            (Credentials, Info);

        public bool Equals(ClearSavedInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ClearSavedInfo x && Equals(x);
        public static bool operator ==(ClearSavedInfo x, ClearSavedInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ClearSavedInfo x, ClearSavedInfo y) => !(x == y);

        public int CompareTo(ClearSavedInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ClearSavedInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ClearSavedInfo x, ClearSavedInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(ClearSavedInfo x, ClearSavedInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(ClearSavedInfo x, ClearSavedInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(ClearSavedInfo x, ClearSavedInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Credentials: {Credentials}, Info: {Info})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd83d70c1);
            Write(MaskBit(0, Credentials) | MaskBit(1, Info), bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}