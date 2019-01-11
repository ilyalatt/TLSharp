using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class EditPhoto : ITlFunc<T.UpdatesType>, IEquatable<EditPhoto>, IComparable<EditPhoto>, IComparable
    {
        public T.InputChannel Channel { get; }
        public T.InputChatPhoto Photo { get; }
        
        public EditPhoto(
            Some<T.InputChannel> channel,
            Some<T.InputChatPhoto> photo
        ) {
            Channel = channel;
            Photo = photo;
        }
        
        
        (T.InputChannel, T.InputChatPhoto) CmpTuple =>
            (Channel, Photo);

        public bool Equals(EditPhoto other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is EditPhoto x && Equals(x);
        public static bool operator ==(EditPhoto x, EditPhoto y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditPhoto x, EditPhoto y) => !(x == y);

        public int CompareTo(EditPhoto other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is EditPhoto x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditPhoto x, EditPhoto y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditPhoto x, EditPhoto y) => x.CompareTo(y) < 0;
        public static bool operator >(EditPhoto x, EditPhoto y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditPhoto x, EditPhoto y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Photo: {Photo})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf12e57c9);
            Write(Channel, bw, WriteSerializable);
            Write(Photo, bw, WriteSerializable);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}