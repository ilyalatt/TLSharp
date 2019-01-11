using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetMessages : ITlFunc<T.Messages.Messages>, IEquatable<GetMessages>, IComparable<GetMessages>, IComparable
    {
        public Arr<int> Id { get; }
        
        public GetMessages(
            Some<Arr<int>> id
        ) {
            Id = id;
        }
        
        
        Arr<int> CmpTuple =>
            Id;

        public bool Equals(GetMessages other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetMessages x && Equals(x);
        public static bool operator ==(GetMessages x, GetMessages y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetMessages x, GetMessages y) => !(x == y);

        public int CompareTo(GetMessages other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetMessages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetMessages x, GetMessages y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetMessages x, GetMessages y) => x.CompareTo(y) < 0;
        public static bool operator >(GetMessages x, GetMessages y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetMessages x, GetMessages y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4222fa74);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}