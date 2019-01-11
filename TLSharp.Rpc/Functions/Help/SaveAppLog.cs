using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class SaveAppLog : ITlFunc<bool>, IEquatable<SaveAppLog>, IComparable<SaveAppLog>, IComparable
    {
        public Arr<T.InputAppEvent> Events { get; }
        
        public SaveAppLog(
            Some<Arr<T.InputAppEvent>> events
        ) {
            Events = events;
        }
        
        
        Arr<T.InputAppEvent> CmpTuple =>
            Events;

        public bool Equals(SaveAppLog other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SaveAppLog x && Equals(x);
        public static bool operator ==(SaveAppLog x, SaveAppLog y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveAppLog x, SaveAppLog y) => !(x == y);

        public int CompareTo(SaveAppLog other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SaveAppLog x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveAppLog x, SaveAppLog y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveAppLog x, SaveAppLog y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveAppLog x, SaveAppLog y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveAppLog x, SaveAppLog y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Events: {Events})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x6f02f748);
            Write(Events, bw, WriteVector<T.InputAppEvent>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}