using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditAbout : ITlFunc<bool>, IEquatable<EditAbout>, IComparable<EditAbout>, IComparable
    {
        public T.InputChannel Channel { get; }
        public string About { get; }
        
        public EditAbout(
            Some<T.InputChannel> channel,
            Some<string> about
        ) {
            Channel = channel;
            About = about;
        }
        
        
        (T.InputChannel, string) CmpTuple =>
            (Channel, About);

        public bool Equals(EditAbout other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is EditAbout x && Equals(x);
        public static bool operator ==(EditAbout x, EditAbout y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditAbout x, EditAbout y) => !(x == y);

        public int CompareTo(EditAbout other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EditAbout x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditAbout x, EditAbout y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditAbout x, EditAbout y) => x.CompareTo(y) < 0;
        public static bool operator >(EditAbout x, EditAbout y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditAbout x, EditAbout y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, About: {About})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x13e27f1e);
            Write(Channel, bw, WriteSerializable);
            Write(About, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}