using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SaveRecentSticker : ITlFunc<bool>, IEquatable<SaveRecentSticker>, IComparable<SaveRecentSticker>, IComparable
    {
        public bool Attached { get; }
        public T.InputDocument Id { get; }
        public bool Unsave { get; }
        
        public SaveRecentSticker(
            bool attached,
            Some<T.InputDocument> id,
            bool unsave
        ) {
            Attached = attached;
            Id = id;
            Unsave = unsave;
        }
        
        
        (bool, T.InputDocument, bool) CmpTuple =>
            (Attached, Id, Unsave);

        public bool Equals(SaveRecentSticker other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SaveRecentSticker x && Equals(x);
        public static bool operator ==(SaveRecentSticker x, SaveRecentSticker y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveRecentSticker x, SaveRecentSticker y) => !(x == y);

        public int CompareTo(SaveRecentSticker other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SaveRecentSticker x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveRecentSticker x, SaveRecentSticker y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveRecentSticker x, SaveRecentSticker y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveRecentSticker x, SaveRecentSticker y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveRecentSticker x, SaveRecentSticker y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Attached: {Attached}, Id: {Id}, Unsave: {Unsave})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x392718f8);
            Write(MaskBit(0, Attached), bw, WriteInt);
            Write(Id, bw, WriteSerializable);
            Write(Unsave, bw, WriteBool);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}