using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class JoinChannel : ITlFunc<T.UpdatesType>, IEquatable<JoinChannel>, IComparable<JoinChannel>, IComparable
    {
        public T.InputChannel Channel { get; }
        
        public JoinChannel(
            Some<T.InputChannel> channel
        ) {
            Channel = channel;
        }
        
        
        T.InputChannel CmpTuple =>
            Channel;

        public bool Equals(JoinChannel other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is JoinChannel x && Equals(x);
        public static bool operator ==(JoinChannel x, JoinChannel y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(JoinChannel x, JoinChannel y) => !(x == y);

        public int CompareTo(JoinChannel other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is JoinChannel x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(JoinChannel x, JoinChannel y) => x.CompareTo(y) <= 0;
        public static bool operator <(JoinChannel x, JoinChannel y) => x.CompareTo(y) < 0;
        public static bool operator >(JoinChannel x, JoinChannel y) => x.CompareTo(y) > 0;
        public static bool operator >=(JoinChannel x, JoinChannel y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x24b524c5);
            Write(Channel, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}