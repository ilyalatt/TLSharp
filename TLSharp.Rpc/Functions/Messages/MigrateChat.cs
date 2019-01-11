using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class MigrateChat : ITlFunc<T.UpdatesType>, IEquatable<MigrateChat>, IComparable<MigrateChat>, IComparable
    {
        public int ChatId { get; }
        
        public MigrateChat(
            int chatId
        ) {
            ChatId = chatId;
        }
        
        
        int CmpTuple =>
            ChatId;

        public bool Equals(MigrateChat other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is MigrateChat x && Equals(x);
        public static bool operator ==(MigrateChat x, MigrateChat y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(MigrateChat x, MigrateChat y) => !(x == y);

        public int CompareTo(MigrateChat other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is MigrateChat x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(MigrateChat x, MigrateChat y) => x.CompareTo(y) <= 0;
        public static bool operator <(MigrateChat x, MigrateChat y) => x.CompareTo(y) < 0;
        public static bool operator >(MigrateChat x, MigrateChat y) => x.CompareTo(y) > 0;
        public static bool operator >=(MigrateChat x, MigrateChat y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(ChatId: {ChatId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x15a3b8e3);
            Write(ChatId, bw, WriteInt);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}