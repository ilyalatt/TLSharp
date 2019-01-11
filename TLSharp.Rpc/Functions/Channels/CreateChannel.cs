using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class CreateChannel : ITlFunc<T.UpdatesType>, IEquatable<CreateChannel>, IComparable<CreateChannel>, IComparable
    {
        public bool Broadcast { get; }
        public bool Megagroup { get; }
        public string Title { get; }
        public string About { get; }
        
        public CreateChannel(
            bool broadcast,
            bool megagroup,
            Some<string> title,
            Some<string> about
        ) {
            Broadcast = broadcast;
            Megagroup = megagroup;
            Title = title;
            About = about;
        }
        
        
        (bool, bool, string, string) CmpTuple =>
            (Broadcast, Megagroup, Title, About);

        public bool Equals(CreateChannel other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is CreateChannel x && Equals(x);
        public static bool operator ==(CreateChannel x, CreateChannel y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CreateChannel x, CreateChannel y) => !(x == y);

        public int CompareTo(CreateChannel other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is CreateChannel x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CreateChannel x, CreateChannel y) => x.CompareTo(y) <= 0;
        public static bool operator <(CreateChannel x, CreateChannel y) => x.CompareTo(y) < 0;
        public static bool operator >(CreateChannel x, CreateChannel y) => x.CompareTo(y) > 0;
        public static bool operator >=(CreateChannel x, CreateChannel y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Broadcast: {Broadcast}, Megagroup: {Megagroup}, Title: {Title}, About: {About})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf4893d7f);
            Write(MaskBit(0, Broadcast) | MaskBit(1, Megagroup), bw, WriteInt);
            Write(Title, bw, WriteString);
            Write(About, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}