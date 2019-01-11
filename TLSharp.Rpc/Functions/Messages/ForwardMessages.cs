using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ForwardMessages : ITlFunc<T.UpdatesType>, IEquatable<ForwardMessages>, IComparable<ForwardMessages>, IComparable
    {
        public bool Silent { get; }
        public bool Background { get; }
        public bool WithMyScore { get; }
        public bool Grouped { get; }
        public T.InputPeer FromPeer { get; }
        public Arr<int> Id { get; }
        public Arr<long> RandomId { get; }
        public T.InputPeer ToPeer { get; }
        
        public ForwardMessages(
            bool silent,
            bool background,
            bool withMyScore,
            bool grouped,
            Some<T.InputPeer> fromPeer,
            Some<Arr<int>> id,
            Some<Arr<long>> randomId,
            Some<T.InputPeer> toPeer
        ) {
            Silent = silent;
            Background = background;
            WithMyScore = withMyScore;
            Grouped = grouped;
            FromPeer = fromPeer;
            Id = id;
            RandomId = randomId;
            ToPeer = toPeer;
        }
        
        
        (bool, bool, bool, bool, T.InputPeer, Arr<int>, Arr<long>, T.InputPeer) CmpTuple =>
            (Silent, Background, WithMyScore, Grouped, FromPeer, Id, RandomId, ToPeer);

        public bool Equals(ForwardMessages other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ForwardMessages x && Equals(x);
        public static bool operator ==(ForwardMessages x, ForwardMessages y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ForwardMessages x, ForwardMessages y) => !(x == y);

        public int CompareTo(ForwardMessages other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ForwardMessages x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ForwardMessages x, ForwardMessages y) => x.CompareTo(y) <= 0;
        public static bool operator <(ForwardMessages x, ForwardMessages y) => x.CompareTo(y) < 0;
        public static bool operator >(ForwardMessages x, ForwardMessages y) => x.CompareTo(y) > 0;
        public static bool operator >=(ForwardMessages x, ForwardMessages y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Silent: {Silent}, Background: {Background}, WithMyScore: {WithMyScore}, Grouped: {Grouped}, FromPeer: {FromPeer}, Id: {Id}, RandomId: {RandomId}, ToPeer: {ToPeer})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x708e0195);
            Write(MaskBit(5, Silent) | MaskBit(6, Background) | MaskBit(8, WithMyScore) | MaskBit(9, Grouped), bw, WriteInt);
            Write(FromPeer, bw, WriteSerializable);
            Write(Id, bw, WriteVector<int>(WriteInt));
            Write(RandomId, bw, WriteVector<long>(WriteLong));
            Write(ToPeer, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}