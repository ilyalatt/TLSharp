using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SaveGif : ITlFunc<bool>, IEquatable<SaveGif>, IComparable<SaveGif>, IComparable
    {
        public T.InputDocument Id { get; }
        public bool Unsave { get; }
        
        public SaveGif(
            Some<T.InputDocument> id,
            bool unsave
        ) {
            Id = id;
            Unsave = unsave;
        }
        
        
        (T.InputDocument, bool) CmpTuple =>
            (Id, Unsave);

        public bool Equals(SaveGif other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SaveGif x && Equals(x);
        public static bool operator ==(SaveGif x, SaveGif y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveGif x, SaveGif y) => !(x == y);

        public int CompareTo(SaveGif other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SaveGif x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveGif x, SaveGif y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveGif x, SaveGif y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveGif x, SaveGif y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveGif x, SaveGif y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Id: {Id}, Unsave: {Unsave})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x327a30cb);
            Write(Id, bw, WriteSerializable);
            Write(Unsave, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}