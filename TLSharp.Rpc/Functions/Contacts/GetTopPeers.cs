using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetTopPeers : ITlFunc<T.Contacts.TopPeers>, IEquatable<GetTopPeers>, IComparable<GetTopPeers>, IComparable
    {
        public bool Correspondents { get; }
        public bool BotsPm { get; }
        public bool BotsInline { get; }
        public bool Groups { get; }
        public bool Channels { get; }
        public int Offset { get; }
        public int Limit { get; }
        public int Hash { get; }
        
        public GetTopPeers(
            bool correspondents,
            bool botsPm,
            bool botsInline,
            bool groups,
            bool channels,
            int offset,
            int limit,
            int hash
        ) {
            Correspondents = correspondents;
            BotsPm = botsPm;
            BotsInline = botsInline;
            Groups = groups;
            Channels = channels;
            Offset = offset;
            Limit = limit;
            Hash = hash;
        }
        
        
        (bool, bool, bool, bool, bool, int, int, int) CmpTuple =>
            (Correspondents, BotsPm, BotsInline, Groups, Channels, Offset, Limit, Hash);

        public bool Equals(GetTopPeers other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetTopPeers x && Equals(x);
        public static bool operator ==(GetTopPeers x, GetTopPeers y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetTopPeers x, GetTopPeers y) => !(x == y);

        public int CompareTo(GetTopPeers other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetTopPeers x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetTopPeers x, GetTopPeers y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetTopPeers x, GetTopPeers y) => x.CompareTo(y) < 0;
        public static bool operator >(GetTopPeers x, GetTopPeers y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetTopPeers x, GetTopPeers y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Correspondents: {Correspondents}, BotsPm: {BotsPm}, BotsInline: {BotsInline}, Groups: {Groups}, Channels: {Channels}, Offset: {Offset}, Limit: {Limit}, Hash: {Hash})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd4982db5);
            Write(MaskBit(0, Correspondents) | MaskBit(1, BotsPm) | MaskBit(2, BotsInline) | MaskBit(10, Groups) | MaskBit(15, Channels), bw, WriteInt);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
            Write(Hash, bw, WriteInt);
        }
        
        T.Contacts.TopPeers ITlFunc<T.Contacts.TopPeers>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.TopPeers.Deserialize);
    }
}