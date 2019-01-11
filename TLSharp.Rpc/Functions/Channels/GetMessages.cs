using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetMessages : ITlFunc<T.Messages.Messages>, IEquatable<GetMessages>, IComparable<GetMessages>, IComparable
    {
        public T.InputChannel Channel { get; }
        public Arr<T.InputMessage> Id { get; }
        
        public GetMessages(
            Some<T.InputChannel> channel,
            Some<Arr<T.InputMessage>> id
        ) {
            Channel = channel;
            Id = id;
        }
        
        
        (T.InputChannel, Arr<T.InputMessage>) CmpTuple =>
            (Channel, Id);

        public bool Equals(GetMessages other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetMessages x && Equals(x);
        public static bool operator ==(GetMessages x, GetMessages y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetMessages x, GetMessages y) => !(x == y);

        public int CompareTo(GetMessages other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetMessages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetMessages x, GetMessages y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetMessages x, GetMessages y) => x.CompareTo(y) < 0;
        public static bool operator >(GetMessages x, GetMessages y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetMessages x, GetMessages y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xad8c9a23);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteVector<T.InputMessage>(WriteSerializable));
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}