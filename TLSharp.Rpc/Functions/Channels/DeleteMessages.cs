using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class DeleteMessages : ITlFunc<T.Messages.AffectedMessages>, IEquatable<DeleteMessages>, IComparable<DeleteMessages>, IComparable
    {
        public T.InputChannel Channel { get; }
        public Arr<int> Id { get; }
        
        public DeleteMessages(
            Some<T.InputChannel> channel,
            Some<Arr<int>> id
        ) {
            Channel = channel;
            Id = id;
        }
        
        
        (T.InputChannel, Arr<int>) CmpTuple =>
            (Channel, Id);

        public bool Equals(DeleteMessages other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is DeleteMessages x && Equals(x);
        public static bool operator ==(DeleteMessages x, DeleteMessages y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(DeleteMessages x, DeleteMessages y) => !(x == y);

        public int CompareTo(DeleteMessages other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is DeleteMessages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(DeleteMessages x, DeleteMessages y) => x.CompareTo(y) <= 0;
        public static bool operator <(DeleteMessages x, DeleteMessages y) => x.CompareTo(y) < 0;
        public static bool operator >(DeleteMessages x, DeleteMessages y) => x.CompareTo(y) > 0;
        public static bool operator >=(DeleteMessages x, DeleteMessages y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x84c1fd4e);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.AffectedMessages ITlFunc<T.Messages.AffectedMessages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedMessages.Deserialize);
    }
}