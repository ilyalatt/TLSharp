using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class GetAdminedPublicChannels : ITlFunc<T.Messages.Chats>, IEquatable<GetAdminedPublicChannels>, IComparable<GetAdminedPublicChannels>, IComparable
    {

        
        public GetAdminedPublicChannels(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(GetAdminedPublicChannels other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is GetAdminedPublicChannels x && Equals(x);
        public static bool operator ==(GetAdminedPublicChannels x, GetAdminedPublicChannels y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAdminedPublicChannels x, GetAdminedPublicChannels y) => !(x == y);

        public int CompareTo(GetAdminedPublicChannels other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is GetAdminedPublicChannels x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAdminedPublicChannels x, GetAdminedPublicChannels y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAdminedPublicChannels x, GetAdminedPublicChannels y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAdminedPublicChannels x, GetAdminedPublicChannels y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAdminedPublicChannels x, GetAdminedPublicChannels y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8d8d82d7);

        }
        
        T.Messages.Chats ITlFunc<T.Messages.Chats>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Messages.Chats.Deserialize);
    }
}