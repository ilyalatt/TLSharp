using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetChannels : ITlFunc<T.Messages.Chats>, IEquatable<GetChannels>, IComparable<GetChannels>, IComparable
    {
        public Arr<T.InputChannel> Id { get; }
        
        public GetChannels(
            Some<Arr<T.InputChannel>> id
        ) {
            Id = id;
        }
        
        
        Arr<T.InputChannel> CmpTuple =>
            Id;

        public bool Equals(GetChannels other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetChannels x && Equals(x);
        public static bool operator ==(GetChannels x, GetChannels y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetChannels x, GetChannels y) => !(x == y);

        public int CompareTo(GetChannels other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetChannels x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetChannels x, GetChannels y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetChannels x, GetChannels y) => x.CompareTo(y) < 0;
        public static bool operator >(GetChannels x, GetChannels y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetChannels x, GetChannels y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x0a7f6bbb);
            Write(Id, bw, WriteVector<T.InputChannel>(WriteSerializable));
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}