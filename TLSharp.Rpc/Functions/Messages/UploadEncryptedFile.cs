using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class UploadEncryptedFile : ITlFunc<T.EncryptedFile>, IEquatable<UploadEncryptedFile>, IComparable<UploadEncryptedFile>, IComparable
    {
        public T.InputEncryptedChat Peer { get; }
        public T.InputEncryptedFile File { get; }
        
        public UploadEncryptedFile(
            Some<T.InputEncryptedChat> peer,
            Some<T.InputEncryptedFile> file
        ) {
            Peer = peer;
            File = file;
        }
        
        
        (T.InputEncryptedChat, T.InputEncryptedFile) CmpTuple =>
            (Peer, File);

        public bool Equals(UploadEncryptedFile other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is UploadEncryptedFile x && Equals(x);
        public static bool operator ==(UploadEncryptedFile x, UploadEncryptedFile y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(UploadEncryptedFile x, UploadEncryptedFile y) => !(x == y);

        public int CompareTo(UploadEncryptedFile other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is UploadEncryptedFile x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(UploadEncryptedFile x, UploadEncryptedFile y) => x.CompareTo(y) <= 0;
        public static bool operator <(UploadEncryptedFile x, UploadEncryptedFile y) => x.CompareTo(y) < 0;
        public static bool operator >(UploadEncryptedFile x, UploadEncryptedFile y) => x.CompareTo(y) > 0;
        public static bool operator >=(UploadEncryptedFile x, UploadEncryptedFile y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, File: {File})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5057c497);
            Write(Peer, bw, WriteSerializable);
            Write(File, bw, WriteSerializable);
        }
        
        T.EncryptedFile ITlFunc<T.EncryptedFile>.DeserializeResult(BinaryReader br) =>
            Read(br, T.EncryptedFile.Deserialize);
    }
}