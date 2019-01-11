using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class UploadMedia : ITlFunc<T.MessageMedia>, IEquatable<UploadMedia>, IComparable<UploadMedia>, IComparable
    {
        public T.InputPeer Peer { get; }
        public T.InputMedia Media { get; }
        
        public UploadMedia(
            Some<T.InputPeer> peer,
            Some<T.InputMedia> media
        ) {
            Peer = peer;
            Media = media;
        }
        
        
        (T.InputPeer, T.InputMedia) CmpTuple =>
            (Peer, Media);

        public bool Equals(UploadMedia other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is UploadMedia x && Equals(x);
        public static bool operator ==(UploadMedia x, UploadMedia y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UploadMedia x, UploadMedia y) => !(x == y);

        public int CompareTo(UploadMedia other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is UploadMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UploadMedia x, UploadMedia y) => x.CompareTo(y) <= 0;
        public static bool operator <(UploadMedia x, UploadMedia y) => x.CompareTo(y) < 0;
        public static bool operator >(UploadMedia x, UploadMedia y) => x.CompareTo(y) > 0;
        public static bool operator >=(UploadMedia x, UploadMedia y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Media: {Media})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x519bc2b1);
            Write(Peer, bw, WriteSerializable);
            Write(Media, bw, WriteSerializable);
        }
        
        T.MessageMedia ITlFunc<T.MessageMedia>.DeserializeResult(BinaryReader br) =>
            Read(br, T.MessageMedia.Deserialize);
    }
}