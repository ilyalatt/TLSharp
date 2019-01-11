using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class UpdatePinnedMessage : ITlFunc<T.UpdatesType>, IEquatable<UpdatePinnedMessage>, IComparable<UpdatePinnedMessage>, IComparable
    {
        public bool Silent { get; }
        public T.InputChannel Channel { get; }
        public int Id { get; }
        
        public UpdatePinnedMessage(
            bool silent,
            Some<T.InputChannel> channel,
            int id
        ) {
            Silent = silent;
            Channel = channel;
            Id = id;
        }
        
        
        (bool, T.InputChannel, int) CmpTuple =>
            (Silent, Channel, Id);

        public bool Equals(UpdatePinnedMessage other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is UpdatePinnedMessage x && Equals(x);
        public static bool operator ==(UpdatePinnedMessage x, UpdatePinnedMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UpdatePinnedMessage x, UpdatePinnedMessage y) => !(x == y);

        public int CompareTo(UpdatePinnedMessage other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UpdatePinnedMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UpdatePinnedMessage x, UpdatePinnedMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(UpdatePinnedMessage x, UpdatePinnedMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(UpdatePinnedMessage x, UpdatePinnedMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(UpdatePinnedMessage x, UpdatePinnedMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Silent: {Silent}, Channel: {Channel}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xa72ded52);
            Write(MaskBit(0, Silent), bw, WriteInt);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}