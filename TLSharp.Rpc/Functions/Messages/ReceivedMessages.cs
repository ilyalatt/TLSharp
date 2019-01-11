using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ReceivedMessages : ITlFunc<Arr<T.ReceivedNotifyMessage>>, IEquatable<ReceivedMessages>, IComparable<ReceivedMessages>, IComparable
    {
        public int MaxId { get; }
        
        public ReceivedMessages(
            int maxId
        ) {
            MaxId = maxId;
        }
        
        
        int CmpTuple =>
            MaxId;

        public bool Equals(ReceivedMessages other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ReceivedMessages x && Equals(x);
        public static bool operator ==(ReceivedMessages x, ReceivedMessages y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ReceivedMessages x, ReceivedMessages y) => !(x == y);

        public int CompareTo(ReceivedMessages other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ReceivedMessages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ReceivedMessages x, ReceivedMessages y) => x.CompareTo(y) <= 0;
        public static bool operator <(ReceivedMessages x, ReceivedMessages y) => x.CompareTo(y) < 0;
        public static bool operator >(ReceivedMessages x, ReceivedMessages y) => x.CompareTo(y) > 0;
        public static bool operator >=(ReceivedMessages x, ReceivedMessages y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(MaxId: {MaxId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x05a954c0);
            Write(MaxId, bw, WriteInt);
        }
        
        Arr<T.ReceivedNotifyMessage> ITlFunc<Arr<T.ReceivedNotifyMessage>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(T.ReceivedNotifyMessage.Deserialize));
    }
}