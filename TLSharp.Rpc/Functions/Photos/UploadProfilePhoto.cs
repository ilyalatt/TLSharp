using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Photos
{
    public sealed class UploadProfilePhoto : ITlFunc<T.Photos.Photo>, IEquatable<UploadProfilePhoto>, IComparable<UploadProfilePhoto>, IComparable
    {
        public T.InputFile File { get; }
        
        public UploadProfilePhoto(
            Some<T.InputFile> file
        ) {
            File = file;
        }
        
        
        T.InputFile CmpTuple =>
            File;

        public bool Equals(UploadProfilePhoto other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is UploadProfilePhoto x && Equals(x);
        public static bool operator ==(UploadProfilePhoto x, UploadProfilePhoto y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UploadProfilePhoto x, UploadProfilePhoto y) => !(x == y);

        public int CompareTo(UploadProfilePhoto other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is UploadProfilePhoto x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UploadProfilePhoto x, UploadProfilePhoto y) => x.CompareTo(y) <= 0;
        public static bool operator <(UploadProfilePhoto x, UploadProfilePhoto y) => x.CompareTo(y) < 0;
        public static bool operator >(UploadProfilePhoto x, UploadProfilePhoto y) => x.CompareTo(y) > 0;
        public static bool operator >=(UploadProfilePhoto x, UploadProfilePhoto y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(File: {File})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4f32c098);
            Write(File, bw, WriteSerializable);
        }
        
        T.Photos.Photo ITlFunc<T.Photos.Photo>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Photos.Photo.Deserialize);
    }
}