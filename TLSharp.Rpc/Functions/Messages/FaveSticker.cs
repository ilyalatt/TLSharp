using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class FaveSticker : ITlFunc<bool>, IEquatable<FaveSticker>, IComparable<FaveSticker>, IComparable
    {
        public T.InputDocument Id { get; }
        public bool Unfave { get; }
        
        public FaveSticker(
            Some<T.InputDocument> id,
            bool unfave
        ) {
            Id = id;
            Unfave = unfave;
        }
        
        
        (T.InputDocument, bool) CmpTuple =>
            (Id, Unfave);

        public bool Equals(FaveSticker other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is FaveSticker x && Equals(x);
        public static bool operator ==(FaveSticker x, FaveSticker y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(FaveSticker x, FaveSticker y) => !(x == y);

        public int CompareTo(FaveSticker other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is FaveSticker x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(FaveSticker x, FaveSticker y) => x.CompareTo(y) <= 0;
        public static bool operator <(FaveSticker x, FaveSticker y) => x.CompareTo(y) < 0;
        public static bool operator >(FaveSticker x, FaveSticker y) => x.CompareTo(y) > 0;
        public static bool operator >=(FaveSticker x, FaveSticker y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id}, Unfave: {Unfave})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb9ffc55b);
            Write(Id, bw, WriteSerializable);
            Write(Unfave, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}