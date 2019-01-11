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
        public Arr<T.InputMessage> Id { get; }
        
        public GetMessages(
            Some<Arr<T.InputMessage>> id
        ) {
            Id = id;
        }
        
        
        Arr<T.InputMessage> CmpTuple =>
            Id;

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

        public override string ToString() => $"(Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x63c66506);
            Write(Id, bw, WriteVector<T.InputMessage>(WriteSerializable));
        }
        
        T.Messages.Messages ITlFunc<T.Messages.Messages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Messages.Deserialize);
    }
}