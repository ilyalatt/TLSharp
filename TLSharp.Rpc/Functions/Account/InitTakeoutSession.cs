using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class InitTakeoutSession : ITlFunc<T.Account.Takeout>, IEquatable<InitTakeoutSession>, IComparable<InitTakeoutSession>, IComparable
    {
        public bool Contacts { get; }
        public bool MessageUsers { get; }
        public bool MessageChats { get; }
        public bool MessageMegagroups { get; }
        public bool MessageChannels { get; }
        public bool Files { get; }
        public Option<int> FileMaxSize { get; }
        
        public InitTakeoutSession(
            bool contacts,
            bool messageUsers,
            bool messageChats,
            bool messageMegagroups,
            bool messageChannels,
            bool files,
            Option<int> fileMaxSize
        ) {
            Contacts = contacts;
            MessageUsers = messageUsers;
            MessageChats = messageChats;
            MessageMegagroups = messageMegagroups;
            MessageChannels = messageChannels;
            Files = files;
            FileMaxSize = fileMaxSize;
        }
        
        
        (bool, bool, bool, bool, bool, bool, Option<int>) CmpTuple =>
            (Contacts, MessageUsers, MessageChats, MessageMegagroups, MessageChannels, Files, FileMaxSize);

        public bool Equals(InitTakeoutSession other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is InitTakeoutSession x && Equals(x);
        public static bool operator ==(InitTakeoutSession x, InitTakeoutSession y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(InitTakeoutSession x, InitTakeoutSession y) => !(x == y);

        public int CompareTo(InitTakeoutSession other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is InitTakeoutSession x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(InitTakeoutSession x, InitTakeoutSession y) => x.CompareTo(y) <= 0;
        public static bool operator <(InitTakeoutSession x, InitTakeoutSession y) => x.CompareTo(y) < 0;
        public static bool operator >(InitTakeoutSession x, InitTakeoutSession y) => x.CompareTo(y) > 0;
        public static bool operator >=(InitTakeoutSession x, InitTakeoutSession y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Contacts: {Contacts}, MessageUsers: {MessageUsers}, MessageChats: {MessageChats}, MessageMegagroups: {MessageMegagroups}, MessageChannels: {MessageChannels}, Files: {Files}, FileMaxSize: {FileMaxSize})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf05b4804);
            Write(MaskBit(0, Contacts) | MaskBit(1, MessageUsers) | MaskBit(2, MessageChats) | MaskBit(3, MessageMegagroups) | MaskBit(4, MessageChannels) | MaskBit(5, Files) | MaskBit(5, FileMaxSize), bw, WriteInt);
            Write(FileMaxSize, bw, WriteOption<int>(WriteInt));
        }
        
        T.Account.Takeout ITlFunc<T.Account.Takeout>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.Takeout.Deserialize);
    }
}