using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class DeleteMessages : ITlFunc<T.Messages.AffectedMessages>, IEquatable<DeleteMessages>, IComparable<DeleteMessages>, IComparable
    {
        public bool Revoke { get; }
        public Arr<int> Id { get; }
        
        public DeleteMessages(
            bool revoke,
            Some<Arr<int>> id
        ) {
            Revoke = revoke;
            Id = id;
        }
        
        
        (bool, Arr<int>) CmpTuple =>
            (Revoke, Id);

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

        public override string ToString() => $"(Revoke: {Revoke}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe58e95d2);
            Write(MaskBit(0, Revoke), bw, WriteInt);
            Write(Id, bw, WriteVector<int>(WriteInt));
        }
        
        T.Messages.AffectedMessages ITlFunc<T.Messages.AffectedMessages>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.AffectedMessages.Deserialize);
    }
}