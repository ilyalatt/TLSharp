using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class ImportChatInvite : ITlFunc<T.UpdatesType>, IEquatable<ImportChatInvite>, IComparable<ImportChatInvite>, IComparable
    {
        public string Hash { get; }
        
        public ImportChatInvite(
            Some<string> hash
        ) {
            Hash = hash;
        }
        
        
        string CmpTuple =>
            Hash;

        public bool Equals(ImportChatInvite other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ImportChatInvite x && Equals(x);
        public static bool operator ==(ImportChatInvite x, ImportChatInvite y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ImportChatInvite x, ImportChatInvite y) => !(x == y);

        public int CompareTo(ImportChatInvite other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ImportChatInvite x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ImportChatInvite x, ImportChatInvite y) => x.CompareTo(y) <= 0;
        public static bool operator <(ImportChatInvite x, ImportChatInvite y) => x.CompareTo(y) < 0;
        public static bool operator >(ImportChatInvite x, ImportChatInvite y) => x.CompareTo(y) > 0;
        public static bool operator >=(ImportChatInvite x, ImportChatInvite y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x6c50051c);
            Write(Hash, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}