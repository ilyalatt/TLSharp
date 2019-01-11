using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetSavedGifs : ITlFunc<T.Messages.SavedGifs>, IEquatable<GetSavedGifs>, IComparable<GetSavedGifs>, IComparable
    {
        public int Hash { get; }
        
        public GetSavedGifs(
            int hash
        ) {
            Hash = hash;
        }
        
        
        int CmpTuple =>
            Hash;

        public bool Equals(GetSavedGifs other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetSavedGifs x && Equals(x);
        public static bool operator ==(GetSavedGifs x, GetSavedGifs y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetSavedGifs x, GetSavedGifs y) => !(x == y);

        public int CompareTo(GetSavedGifs other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetSavedGifs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetSavedGifs x, GetSavedGifs y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetSavedGifs x, GetSavedGifs y) => x.CompareTo(y) < 0;
        public static bool operator >(GetSavedGifs x, GetSavedGifs y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetSavedGifs x, GetSavedGifs y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x83bf3d52);
            Write(Hash, bw, WriteInt);
        }
        
        T.Messages.SavedGifs ITlFunc<T.Messages.SavedGifs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.SavedGifs.Deserialize);
    }
}