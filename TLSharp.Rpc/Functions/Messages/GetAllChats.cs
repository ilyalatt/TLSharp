using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetAllChats : ITlFunc<T.Messages.Chats>, IEquatable<GetAllChats>, IComparable<GetAllChats>, IComparable
    {
        public Arr<int> ExceptIds { get; }
        
        public GetAllChats(
            Some<Arr<int>> exceptIds
        ) {
            ExceptIds = exceptIds;
        }
        
        
        Arr<int> CmpTuple =>
            ExceptIds;

        public bool Equals(GetAllChats other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetAllChats x && Equals(x);
        public static bool operator ==(GetAllChats x, GetAllChats y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAllChats x, GetAllChats y) => !(x == y);

        public int CompareTo(GetAllChats other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetAllChats x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAllChats x, GetAllChats y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAllChats x, GetAllChats y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAllChats x, GetAllChats y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAllChats x, GetAllChats y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ExceptIds: {ExceptIds})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xeba80ff0);
            Write(ExceptIds, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}