using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class SetCallRating : ITlFunc<T.UpdatesType>, IEquatable<SetCallRating>, IComparable<SetCallRating>, IComparable
    {
        public T.InputPhoneCall Peer { get; }
        public int Rating { get; }
        public string Comment { get; }
        
        public SetCallRating(
            Some<T.InputPhoneCall> peer,
            int rating,
            Some<string> comment
        ) {
            Peer = peer;
            Rating = rating;
            Comment = comment;
        }
        
        
        (T.InputPhoneCall, int, string) CmpTuple =>
            (Peer, Rating, Comment);

        public bool Equals(SetCallRating other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetCallRating x && Equals(x);
        public static bool operator ==(SetCallRating x, SetCallRating y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetCallRating x, SetCallRating y) => !(x == y);

        public int CompareTo(SetCallRating other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetCallRating x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetCallRating x, SetCallRating y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetCallRating x, SetCallRating y) => x.CompareTo(y) < 0;
        public static bool operator >(SetCallRating x, SetCallRating y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetCallRating x, SetCallRating y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Rating: {Rating}, Comment: {Comment})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x1c536a34);
            Write(Peer, bw, WriteSerializable);
            Write(Rating, bw, WriteInt);
            Write(Comment, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}