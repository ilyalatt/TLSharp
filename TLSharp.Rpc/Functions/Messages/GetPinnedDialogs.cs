using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetPinnedDialogs : ITlFunc<T.Messages.PeerDialogs>, IEquatable<GetPinnedDialogs>, IComparable<GetPinnedDialogs>, IComparable
    {

        
        public GetPinnedDialogs(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetPinnedDialogs other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetPinnedDialogs x && Equals(x);
        public static bool operator ==(GetPinnedDialogs x, GetPinnedDialogs y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetPinnedDialogs x, GetPinnedDialogs y) => !(x == y);

        public int CompareTo(GetPinnedDialogs other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetPinnedDialogs x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetPinnedDialogs x, GetPinnedDialogs y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetPinnedDialogs x, GetPinnedDialogs y) => x.CompareTo(y) < 0;
        public static bool operator >(GetPinnedDialogs x, GetPinnedDialogs y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetPinnedDialogs x, GetPinnedDialogs y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe254d64e);

        }
        
        T.Messages.PeerDialogs ITlFunc<T.Messages.PeerDialogs>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.PeerDialogs.Deserialize);
    }
}