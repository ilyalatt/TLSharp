using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class SetBotUpdatesStatus : ITlFunc<bool>, IEquatable<SetBotUpdatesStatus>, IComparable<SetBotUpdatesStatus>, IComparable
    {
        public int PendingUpdatesCount { get; }
        public string Message { get; }
        
        public SetBotUpdatesStatus(
            int pendingUpdatesCount,
            Some<string> message
        ) {
            PendingUpdatesCount = pendingUpdatesCount;
            Message = message;
        }
        
        
        (int, string) CmpTuple =>
            (PendingUpdatesCount, Message);

        public bool Equals(SetBotUpdatesStatus other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SetBotUpdatesStatus x && Equals(x);
        public static bool operator ==(SetBotUpdatesStatus x, SetBotUpdatesStatus y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetBotUpdatesStatus x, SetBotUpdatesStatus y) => !(x == y);

        public int CompareTo(SetBotUpdatesStatus other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetBotUpdatesStatus x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetBotUpdatesStatus x, SetBotUpdatesStatus y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetBotUpdatesStatus x, SetBotUpdatesStatus y) => x.CompareTo(y) < 0;
        public static bool operator >(SetBotUpdatesStatus x, SetBotUpdatesStatus y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetBotUpdatesStatus x, SetBotUpdatesStatus y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(PendingUpdatesCount: {PendingUpdatesCount}, Message: {Message})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xec22cfcd);
            Write(PendingUpdatesCount, bw, WriteInt);
            Write(Message, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}