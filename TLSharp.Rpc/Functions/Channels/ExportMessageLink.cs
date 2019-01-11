using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ExportMessageLink : ITlFunc<T.ExportedMessageLink>, IEquatable<ExportMessageLink>, IComparable<ExportMessageLink>, IComparable
    {
        public T.InputChannel Channel { get; }
        public int Id { get; }
        
        public ExportMessageLink(
            Some<T.InputChannel> channel,
            int id
        ) {
            Channel = channel;
            Id = id;
        }
        
        
        (T.InputChannel, int) CmpTuple =>
            (Channel, Id);

        public bool Equals(ExportMessageLink other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ExportMessageLink x && Equals(x);
        public static bool operator ==(ExportMessageLink x, ExportMessageLink y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ExportMessageLink x, ExportMessageLink y) => !(x == y);

        public int CompareTo(ExportMessageLink other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ExportMessageLink x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportMessageLink x, ExportMessageLink y) => x.CompareTo(y) <= 0;
        public static bool operator <(ExportMessageLink x, ExportMessageLink y) => x.CompareTo(y) < 0;
        public static bool operator >(ExportMessageLink x, ExportMessageLink y) => x.CompareTo(y) > 0;
        public static bool operator >=(ExportMessageLink x, ExportMessageLink y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Id: {Id})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc846d22d);
            Write(Channel, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
        }
        
        T.ExportedMessageLink ITlFunc<T.ExportedMessageLink>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ExportedMessageLink.Deserialize);
    }
}