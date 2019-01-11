using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Types
{
    public sealed class Config : ITlType, IEquatable<Config>, IComparable<Config>, IComparable
    {
        public sealed class Tag : ITlTypeTag, IEquatable<Tag>, IComparable<Tag>, IComparable
        {
            internal const uint TypeNumber = 0xcb601684;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public bool PhonecallsEnabled { get; }
            public int Date { get; }
            public int Expires { get; }
            public bool TestMode { get; }
            public int ThisDc { get; }
            public Arr<T.DcOption> DcOptions { get; }
            public int ChatSizeMax { get; }
            public int MegagroupSizeMax { get; }
            public int ForwardedCountMax { get; }
            public int OnlineUpdatePeriodMs { get; }
            public int OfflineBlurTimeoutMs { get; }
            public int OfflineIdleTimeoutMs { get; }
            public int OnlineCloudTimeoutMs { get; }
            public int NotifyCloudDelayMs { get; }
            public int NotifyDefaultDelayMs { get; }
            public int ChatBigSize { get; }
            public int PushChatPeriodMs { get; }
            public int PushChatLimit { get; }
            public int SavedGifsLimit { get; }
            public int EditTimeLimit { get; }
            public int RatingEDecay { get; }
            public int StickersRecentLimit { get; }
            public Option<int> TmpSessions { get; }
            public int PinnedDialogsCountMax { get; }
            public int CallReceiveTimeoutMs { get; }
            public int CallRingTimeoutMs { get; }
            public int CallConnectTimeoutMs { get; }
            public int CallPacketTimeoutMs { get; }
            public string MeUrlPrefix { get; }
            public Arr<T.DisabledFeature> DisabledFeatures { get; }
            
            public Tag(
                bool phonecallsEnabled,
                int date,
                int expires,
                bool testMode,
                int thisDc,
                Some<Arr<T.DcOption>> dcOptions,
                int chatSizeMax,
                int megagroupSizeMax,
                int forwardedCountMax,
                int onlineUpdatePeriodMs,
                int offlineBlurTimeoutMs,
                int offlineIdleTimeoutMs,
                int onlineCloudTimeoutMs,
                int notifyCloudDelayMs,
                int notifyDefaultDelayMs,
                int chatBigSize,
                int pushChatPeriodMs,
                int pushChatLimit,
                int savedGifsLimit,
                int editTimeLimit,
                int ratingEDecay,
                int stickersRecentLimit,
                Option<int> tmpSessions,
                int pinnedDialogsCountMax,
                int callReceiveTimeoutMs,
                int callRingTimeoutMs,
                int callConnectTimeoutMs,
                int callPacketTimeoutMs,
                Some<string> meUrlPrefix,
                Some<Arr<T.DisabledFeature>> disabledFeatures
            ) {
                PhonecallsEnabled = phonecallsEnabled;
                Date = date;
                Expires = expires;
                TestMode = testMode;
                ThisDc = thisDc;
                DcOptions = dcOptions;
                ChatSizeMax = chatSizeMax;
                MegagroupSizeMax = megagroupSizeMax;
                ForwardedCountMax = forwardedCountMax;
                OnlineUpdatePeriodMs = onlineUpdatePeriodMs;
                OfflineBlurTimeoutMs = offlineBlurTimeoutMs;
                OfflineIdleTimeoutMs = offlineIdleTimeoutMs;
                OnlineCloudTimeoutMs = onlineCloudTimeoutMs;
                NotifyCloudDelayMs = notifyCloudDelayMs;
                NotifyDefaultDelayMs = notifyDefaultDelayMs;
                ChatBigSize = chatBigSize;
                PushChatPeriodMs = pushChatPeriodMs;
                PushChatLimit = pushChatLimit;
                SavedGifsLimit = savedGifsLimit;
                EditTimeLimit = editTimeLimit;
                RatingEDecay = ratingEDecay;
                StickersRecentLimit = stickersRecentLimit;
                TmpSessions = tmpSessions;
                PinnedDialogsCountMax = pinnedDialogsCountMax;
                CallReceiveTimeoutMs = callReceiveTimeoutMs;
                CallRingTimeoutMs = callRingTimeoutMs;
                CallConnectTimeoutMs = callConnectTimeoutMs;
                CallPacketTimeoutMs = callPacketTimeoutMs;
                MeUrlPrefix = meUrlPrefix;
                DisabledFeatures = disabledFeatures;
            }
            
            (bool, int, int, bool, int, Arr<T.DcOption>, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Option<int>, int, int, int, int, int, string, Arr<T.DisabledFeature>) CmpTuple =>
                (PhonecallsEnabled, Date, Expires, TestMode, ThisDc, DcOptions, ChatSizeMax, MegagroupSizeMax, ForwardedCountMax, OnlineUpdatePeriodMs, OfflineBlurTimeoutMs, OfflineIdleTimeoutMs, OnlineCloudTimeoutMs, NotifyCloudDelayMs, NotifyDefaultDelayMs, ChatBigSize, PushChatPeriodMs, PushChatLimit, SavedGifsLimit, EditTimeLimit, RatingEDecay, StickersRecentLimit, TmpSessions, PinnedDialogsCountMax, CallReceiveTimeoutMs, CallRingTimeoutMs, CallConnectTimeoutMs, CallPacketTimeoutMs, MeUrlPrefix, DisabledFeatures);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PhonecallsEnabled: {PhonecallsEnabled}, Date: {Date}, Expires: {Expires}, TestMode: {TestMode}, ThisDc: {ThisDc}, DcOptions: {DcOptions}, ChatSizeMax: {ChatSizeMax}, MegagroupSizeMax: {MegagroupSizeMax}, ForwardedCountMax: {ForwardedCountMax}, OnlineUpdatePeriodMs: {OnlineUpdatePeriodMs}, OfflineBlurTimeoutMs: {OfflineBlurTimeoutMs}, OfflineIdleTimeoutMs: {OfflineIdleTimeoutMs}, OnlineCloudTimeoutMs: {OnlineCloudTimeoutMs}, NotifyCloudDelayMs: {NotifyCloudDelayMs}, NotifyDefaultDelayMs: {NotifyDefaultDelayMs}, ChatBigSize: {ChatBigSize}, PushChatPeriodMs: {PushChatPeriodMs}, PushChatLimit: {PushChatLimit}, SavedGifsLimit: {SavedGifsLimit}, EditTimeLimit: {EditTimeLimit}, RatingEDecay: {RatingEDecay}, StickersRecentLimit: {StickersRecentLimit}, TmpSessions: {TmpSessions}, PinnedDialogsCountMax: {PinnedDialogsCountMax}, CallReceiveTimeoutMs: {CallReceiveTimeoutMs}, CallRingTimeoutMs: {CallRingTimeoutMs}, CallConnectTimeoutMs: {CallConnectTimeoutMs}, CallPacketTimeoutMs: {CallPacketTimeoutMs}, MeUrlPrefix: {MeUrlPrefix}, DisabledFeatures: {DisabledFeatures})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, PhonecallsEnabled) | MaskBit(0, TmpSessions), bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Expires, bw, WriteInt);
                Write(TestMode, bw, WriteBool);
                Write(ThisDc, bw, WriteInt);
                Write(DcOptions, bw, WriteVector<T.DcOption>(WriteSerializable));
                Write(ChatSizeMax, bw, WriteInt);
                Write(MegagroupSizeMax, bw, WriteInt);
                Write(ForwardedCountMax, bw, WriteInt);
                Write(OnlineUpdatePeriodMs, bw, WriteInt);
                Write(OfflineBlurTimeoutMs, bw, WriteInt);
                Write(OfflineIdleTimeoutMs, bw, WriteInt);
                Write(OnlineCloudTimeoutMs, bw, WriteInt);
                Write(NotifyCloudDelayMs, bw, WriteInt);
                Write(NotifyDefaultDelayMs, bw, WriteInt);
                Write(ChatBigSize, bw, WriteInt);
                Write(PushChatPeriodMs, bw, WriteInt);
                Write(PushChatLimit, bw, WriteInt);
                Write(SavedGifsLimit, bw, WriteInt);
                Write(EditTimeLimit, bw, WriteInt);
                Write(RatingEDecay, bw, WriteInt);
                Write(StickersRecentLimit, bw, WriteInt);
                Write(TmpSessions, bw, WriteOption<int>(WriteInt));
                Write(PinnedDialogsCountMax, bw, WriteInt);
                Write(CallReceiveTimeoutMs, bw, WriteInt);
                Write(CallRingTimeoutMs, bw, WriteInt);
                Write(CallConnectTimeoutMs, bw, WriteInt);
                Write(CallPacketTimeoutMs, bw, WriteInt);
                Write(MeUrlPrefix, bw, WriteString);
                Write(DisabledFeatures, bw, WriteVector<T.DisabledFeature>(WriteSerializable));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var phonecallsEnabled = Read(br, ReadOption(flags, 1));
                var date = Read(br, ReadInt);
                var expires = Read(br, ReadInt);
                var testMode = Read(br, ReadBool);
                var thisDc = Read(br, ReadInt);
                var dcOptions = Read(br, ReadVector(T.DcOption.Deserialize));
                var chatSizeMax = Read(br, ReadInt);
                var megagroupSizeMax = Read(br, ReadInt);
                var forwardedCountMax = Read(br, ReadInt);
                var onlineUpdatePeriodMs = Read(br, ReadInt);
                var offlineBlurTimeoutMs = Read(br, ReadInt);
                var offlineIdleTimeoutMs = Read(br, ReadInt);
                var onlineCloudTimeoutMs = Read(br, ReadInt);
                var notifyCloudDelayMs = Read(br, ReadInt);
                var notifyDefaultDelayMs = Read(br, ReadInt);
                var chatBigSize = Read(br, ReadInt);
                var pushChatPeriodMs = Read(br, ReadInt);
                var pushChatLimit = Read(br, ReadInt);
                var savedGifsLimit = Read(br, ReadInt);
                var editTimeLimit = Read(br, ReadInt);
                var ratingEDecay = Read(br, ReadInt);
                var stickersRecentLimit = Read(br, ReadInt);
                var tmpSessions = Read(br, ReadOption(flags, 0, ReadInt));
                var pinnedDialogsCountMax = Read(br, ReadInt);
                var callReceiveTimeoutMs = Read(br, ReadInt);
                var callRingTimeoutMs = Read(br, ReadInt);
                var callConnectTimeoutMs = Read(br, ReadInt);
                var callPacketTimeoutMs = Read(br, ReadInt);
                var meUrlPrefix = Read(br, ReadString);
                var disabledFeatures = Read(br, ReadVector(T.DisabledFeature.Deserialize));
                return new Tag(phonecallsEnabled, date, expires, testMode, thisDc, dcOptions, chatSizeMax, megagroupSizeMax, forwardedCountMax, onlineUpdatePeriodMs, offlineBlurTimeoutMs, offlineIdleTimeoutMs, onlineCloudTimeoutMs, notifyCloudDelayMs, notifyDefaultDelayMs, chatBigSize, pushChatPeriodMs, pushChatLimit, savedGifsLimit, editTimeLimit, ratingEDecay, stickersRecentLimit, tmpSessions, pinnedDialogsCountMax, callReceiveTimeoutMs, callRingTimeoutMs, callConnectTimeoutMs, callPacketTimeoutMs, meUrlPrefix, disabledFeatures);
            }
        }

        readonly ITlTypeTag _tag;
        Config(ITlTypeTag tag) => _tag = tag ?? throw new ArgumentNullException(nameof(tag));

        public static explicit operator Config(Tag tag) => new Config(tag);

        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, _tag.TypeNumber);
            _tag.Serialize(bw);
        }

        internal static Config Deserialize(BinaryReader br)
        {
            var typeNumber = ReadUint(br);
            switch (typeNumber)
            {
                case Tag.TypeNumber: return (Config) Tag.DeserializeTag(br);
                default: throw TlRpcDeserializeException.UnexpectedTypeNumber(actual: typeNumber, expected: new[] { Tag.TypeNumber });
            }
        }

        T Match<T>(
            Func<T> _,
            Func<Tag, T> tag = null
        ) {
            if (_ == null) throw new ArgumentNullException(nameof(_));
            switch (_tag)
            {
                case Tag x when tag != null: return tag(x);
                default: return _();
            }
        }

        public T Match<T>(
            Func<Tag, T> tag
        ) => Match(
            () => throw new Exception("WTF"),
            tag ?? throw new ArgumentNullException(nameof(tag))
        );

        int GetTagOrder()
        {
            switch (_tag)
            {
                case Tag _: return 0;
                default: throw new Exception("WTF");
            }
        }
        (int, object) CmpPair => (GetTagOrder(), _tag);

        public bool Equals(Config other) => !ReferenceEquals(other, null) && CmpPair == other.CmpPair;
        public override bool Equals(object other) => other is Config x && Equals(x);
        public static bool operator ==(Config x, Config y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Config x, Config y) => !(x == y);

        public int CompareTo(Config other) => !ReferenceEquals(other, null) ? CmpPair.CompareTo(other.CmpPair) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is Config x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Config x, Config y) => x.CompareTo(y) <= 0;
        public static bool operator <(Config x, Config y) => x.CompareTo(y) < 0;
        public static bool operator >(Config x, Config y) => x.CompareTo(y) > 0;
        public static bool operator >=(Config x, Config y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Config.{_tag.GetType().Name}{_tag}";
    }
}