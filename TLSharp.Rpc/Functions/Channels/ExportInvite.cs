using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class ExportInvite : ITlFunc<T.ExportedChatInvite>, IEquatable<ExportInvite>, IComparable<ExportInvite>, IComparable
    {
        public T.InputChannel Channel { get; }
        
        public ExportInvite(
            Some<T.InputChannel> channel
        ) {
            Channel = channel;
        }
        
        
        T.InputChannel CmpTuple =>
            Channel;

        public bool Equals(ExportInvite other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ExportInvite x && Equals(x);
        public static bool operator ==(ExportInvite x, ExportInvite y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ExportInvite x, ExportInvite y) => !(x == y);

        public int CompareTo(ExportInvite other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ExportInvite x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportInvite x, ExportInvite y) => x.CompareTo(y) <= 0;
        public static bool operator <(ExportInvite x, ExportInvite y) => x.CompareTo(y) < 0;
        public static bool operator >(ExportInvite x, ExportInvite y) => x.CompareTo(y) > 0;
        public static bool operator >=(ExportInvite x, ExportInvite y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc7560885);
            Write(Channel, bw, WriteSerializable);
        }
        
        T.ExportedChatInvite ITlFunc<T.ExportedChatInvite>.DeserializeResult(BinaryReader br) =>
            Read(br, T.ExportedChatInvite.Deserialize);
    }
}