using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SendMultiMedia : ITlFunc<T.UpdatesType>, IEquatable<SendMultiMedia>, IComparable<SendMultiMedia>, IComparable
    {
        public bool Silent { get; }
        public bool Background { get; }
        public bool ClearDraft { get; }
        public T.InputPeer Peer { get; }
        public Option<int> ReplyToMsgId { get; }
        public Arr<T.InputSingleMedia> MultiMedia { get; }
        
        public SendMultiMedia(
            bool silent,
            bool background,
            bool clearDraft,
            Some<T.InputPeer> peer,
            Option<int> replyToMsgId,
            Some<Arr<T.InputSingleMedia>> multiMedia
        ) {
            Silent = silent;
            Background = background;
            ClearDraft = clearDraft;
            Peer = peer;
            ReplyToMsgId = replyToMsgId;
            MultiMedia = multiMedia;
        }
        
        
        (bool, bool, bool, T.InputPeer, Option<int>, Arr<T.InputSingleMedia>) CmpTuple =>
            (Silent, Background, ClearDraft, Peer, ReplyToMsgId, MultiMedia);

        public bool Equals(SendMultiMedia other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SendMultiMedia x && Equals(x);
        public static bool operator ==(SendMultiMedia x, SendMultiMedia y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendMultiMedia x, SendMultiMedia y) => !(x == y);

        public int CompareTo(SendMultiMedia other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SendMultiMedia x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendMultiMedia x, SendMultiMedia y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendMultiMedia x, SendMultiMedia y) => x.CompareTo(y) < 0;
        public static bool operator >(SendMultiMedia x, SendMultiMedia y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendMultiMedia x, SendMultiMedia y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Silent: {Silent}, Background: {Background}, ClearDraft: {ClearDraft}, Peer: {Peer}, ReplyToMsgId: {ReplyToMsgId}, MultiMedia: {MultiMedia})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2095512f);
            Write(MaskBit(5, Silent) | MaskBit(6, Background) | MaskBit(7, ClearDraft) | MaskBit(0, ReplyToMsgId), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(ReplyToMsgId, bw, WriteOption<int>(WriteInt));
            Write(MultiMedia, bw, WriteVector<T.InputSingleMedia>(WriteSerializable));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}