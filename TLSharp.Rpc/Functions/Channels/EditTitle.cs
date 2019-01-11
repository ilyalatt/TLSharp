using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditTitle : ITlFunc<T.UpdatesType>, IEquatable<EditTitle>, IComparable<EditTitle>, IComparable
    {
        public T.InputChannel Channel { get; }
        public string Title { get; }
        
        public EditTitle(
            Some<T.InputChannel> channel,
            Some<string> title
        ) {
            Channel = channel;
            Title = title;
        }
        
        
        (T.InputChannel, string) CmpTuple =>
            (Channel, Title);

        public bool Equals(EditTitle other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is EditTitle x && Equals(x);
        public static bool operator ==(EditTitle x, EditTitle y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditTitle x, EditTitle y) => !(x == y);

        public int CompareTo(EditTitle other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is EditTitle x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditTitle x, EditTitle y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditTitle x, EditTitle y) => x.CompareTo(y) < 0;
        public static bool operator >(EditTitle x, EditTitle y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditTitle x, EditTitle y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Title: {Title})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x566decd0);
            Write(Channel, bw, WriteSerializable);
            Write(Title, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}