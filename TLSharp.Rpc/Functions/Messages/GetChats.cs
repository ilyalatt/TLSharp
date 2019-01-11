using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetChats : ITlFunc<T.Messages.Chats>, IEquatable<GetChats>, IComparable<GetChats>, IComparable
    {
        public Arr<int> Id { get; }
        
        public GetChats(
            Some<Arr<int>> id
        ) {
            Id = id;
        }
        
        
        Arr<int> CmpTuple =>
            Id;

        public bool Equals(GetChats other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetChats x && Equals(x);
        public static bool operator ==(GetChats x, GetChats y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetChats x, GetChats y) => !(x == y);

        public int CompareTo(GetChats other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetChats x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetChats x, GetChats y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetChats x, GetChats y) => x.CompareTo(y) < 0;
        public static bool operator >(GetChats x, GetChats y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetChats x, GetChats y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3c6aa187);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}