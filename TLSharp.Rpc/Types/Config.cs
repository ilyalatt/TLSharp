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
            internal const uint TypeNumber = 0x3213dbba;
            uint ITlTypeTag.TypeNumber => TypeNumber;
            
            public readonly bool PhonecallsEnabled;
            public readonly bool DefaultP2pContacts;
            public readonly bool PreloadFeaturedStickers;
            public readonly bool IgnorePhoneEntities;
            public readonly bool RevokePmInbox;
            public readonly bool BlockedMode;
            public readonly int Date;
            public readonly int Expires;
            public readonly bool TestMode;
            public readonly int ThisDc;
            public readonly Arr<T.DcOption> DcOptions;
            public readonly string DcTxtDomainName;
            public readonly int ChatSizeMax;
            public readonly int MegagroupSizeMax;
            public readonly int ForwardedCountMax;
            public readonly int OnlineUpdatePeriodMs;
            public readonly int OfflineBlurTimeoutMs;
            public readonly int OfflineIdleTimeoutMs;
            public readonly int OnlineCloudTimeoutMs;
            public readonly int NotifyCloudDelayMs;
            public readonly int NotifyDefaultDelayMs;
            public readonly int PushChatPeriodMs;
            public readonly int PushChatLimit;
            public readonly int SavedGifsLimit;
            public readonly int EditTimeLimit;
            public readonly int RevokeTimeLimit;
            public readonly int RevokePmTimeLimit;
            public readonly int RatingEDecay;
            public readonly int StickersRecentLimit;
            public readonly int StickersFavedLimit;
            public readonly int ChannelsReadMediaPeriod;
            public readonly Option<int> TmpSessions;
            public readonly int PinnedDialogsCountMax;
            public readonly int CallReceiveTimeoutMs;
            public readonly int CallRingTimeoutMs;
            public readonly int CallConnectTimeoutMs;
            public readonly int CallPacketTimeoutMs;
            public readonly string MeUrlPrefix;
            public readonly Option<string> AutoupdateUrlPrefix;
            public readonly Option<string> GifSearchUsername;
            public readonly Option<string> VenueSearchUsername;
            public readonly Option<string> ImgSearchUsername;
            public readonly Option<string> StaticMapsProvider;
            public readonly int CaptionLengthMax;
            public readonly int MessageLengthMax;
            public readonly int WebfileDcId;
            public readonly Option<string> SuggestedLangCode;
            public readonly Option<int> LangPackVersion;
            
            public Tag(
                bool phonecallsEnabled,
                bool defaultP2pContacts,
                bool preloadFeaturedStickers,
                bool ignorePhoneEntities,
                bool revokePmInbox,
                bool blockedMode,
                int date,
                int expires,
                bool testMode,
                int thisDc,
                Some<Arr<T.DcOption>> dcOptions,
                Some<string> dcTxtDomainName,
                int chatSizeMax,
                int megagroupSizeMax,
                int forwardedCountMax,
                int onlineUpdatePeriodMs,
                int offlineBlurTimeoutMs,
                int offlineIdleTimeoutMs,
                int onlineCloudTimeoutMs,
                int notifyCloudDelayMs,
                int notifyDefaultDelayMs,
                int pushChatPeriodMs,
                int pushChatLimit,
                int savedGifsLimit,
                int editTimeLimit,
                int revokeTimeLimit,
                int revokePmTimeLimit,
                int ratingEDecay,
                int stickersRecentLimit,
                int stickersFavedLimit,
                int channelsReadMediaPeriod,
                Option<int> tmpSessions,
                int pinnedDialogsCountMax,
                int callReceiveTimeoutMs,
                int callRingTimeoutMs,
                int callConnectTimeoutMs,
                int callPacketTimeoutMs,
                Some<string> meUrlPrefix,
                Option<string> autoupdateUrlPrefix,
                Option<string> gifSearchUsername,
                Option<string> venueSearchUsername,
                Option<string> imgSearchUsername,
                Option<string> staticMapsProvider,
                int captionLengthMax,
                int messageLengthMax,
                int webfileDcId,
                Option<string> suggestedLangCode,
                Option<int> langPackVersion
            ) {
                PhonecallsEnabled = phonecallsEnabled;
                DefaultP2pContacts = defaultP2pContacts;
                PreloadFeaturedStickers = preloadFeaturedStickers;
                IgnorePhoneEntities = ignorePhoneEntities;
                RevokePmInbox = revokePmInbox;
                BlockedMode = blockedMode;
                Date = date;
                Expires = expires;
                TestMode = testMode;
                ThisDc = thisDc;
                DcOptions = dcOptions;
                DcTxtDomainName = dcTxtDomainName;
                ChatSizeMax = chatSizeMax;
                MegagroupSizeMax = megagroupSizeMax;
                ForwardedCountMax = forwardedCountMax;
                OnlineUpdatePeriodMs = onlineUpdatePeriodMs;
                OfflineBlurTimeoutMs = offlineBlurTimeoutMs;
                OfflineIdleTimeoutMs = offlineIdleTimeoutMs;
                OnlineCloudTimeoutMs = onlineCloudTimeoutMs;
                NotifyCloudDelayMs = notifyCloudDelayMs;
                NotifyDefaultDelayMs = notifyDefaultDelayMs;
                PushChatPeriodMs = pushChatPeriodMs;
                PushChatLimit = pushChatLimit;
                SavedGifsLimit = savedGifsLimit;
                EditTimeLimit = editTimeLimit;
                RevokeTimeLimit = revokeTimeLimit;
                RevokePmTimeLimit = revokePmTimeLimit;
                RatingEDecay = ratingEDecay;
                StickersRecentLimit = stickersRecentLimit;
                StickersFavedLimit = stickersFavedLimit;
                ChannelsReadMediaPeriod = channelsReadMediaPeriod;
                TmpSessions = tmpSessions;
                PinnedDialogsCountMax = pinnedDialogsCountMax;
                CallReceiveTimeoutMs = callReceiveTimeoutMs;
                CallRingTimeoutMs = callRingTimeoutMs;
                CallConnectTimeoutMs = callConnectTimeoutMs;
                CallPacketTimeoutMs = callPacketTimeoutMs;
                MeUrlPrefix = meUrlPrefix;
                AutoupdateUrlPrefix = autoupdateUrlPrefix;
                GifSearchUsername = gifSearchUsername;
                VenueSearchUsername = venueSearchUsername;
                ImgSearchUsername = imgSearchUsername;
                StaticMapsProvider = staticMapsProvider;
                CaptionLengthMax = captionLengthMax;
                MessageLengthMax = messageLengthMax;
                WebfileDcId = webfileDcId;
                SuggestedLangCode = suggestedLangCode;
                LangPackVersion = langPackVersion;
            }
            
            (bool, bool, bool, bool, bool, bool, int, int, bool, int, Arr<T.DcOption>, string, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, int, Option<int>, int, int, int, int, int, string, Option<string>, Option<string>, Option<string>, Option<string>, Option<string>, int, int, int, Option<string>, Option<int>) CmpTuple =>
                (PhonecallsEnabled, DefaultP2pContacts, PreloadFeaturedStickers, IgnorePhoneEntities, RevokePmInbox, BlockedMode, Date, Expires, TestMode, ThisDc, DcOptions, DcTxtDomainName, ChatSizeMax, MegagroupSizeMax, ForwardedCountMax, OnlineUpdatePeriodMs, OfflineBlurTimeoutMs, OfflineIdleTimeoutMs, OnlineCloudTimeoutMs, NotifyCloudDelayMs, NotifyDefaultDelayMs, PushChatPeriodMs, PushChatLimit, SavedGifsLimit, EditTimeLimit, RevokeTimeLimit, RevokePmTimeLimit, RatingEDecay, StickersRecentLimit, StickersFavedLimit, ChannelsReadMediaPeriod, TmpSessions, PinnedDialogsCountMax, CallReceiveTimeoutMs, CallRingTimeoutMs, CallConnectTimeoutMs, CallPacketTimeoutMs, MeUrlPrefix, AutoupdateUrlPrefix, GifSearchUsername, VenueSearchUsername, ImgSearchUsername, StaticMapsProvider, CaptionLengthMax, MessageLengthMax, WebfileDcId, SuggestedLangCode, LangPackVersion);

            public bool Equals(Tag other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
            public override bool Equals(object other) => other is Tag x && Equals(x);
            public static bool operator ==(Tag x, Tag y) => x?.Equals(y) ?? ReferenceEquals(y, null);
            public static bool operator !=(Tag x, Tag y) => !(x == y);

            public int CompareTo(Tag other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
            int IComparable.CompareTo(object other) => other is Tag x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
            public static bool operator <=(Tag x, Tag y) => x.CompareTo(y) <= 0;
            public static bool operator <(Tag x, Tag y) => x.CompareTo(y) < 0;
            public static bool operator >(Tag x, Tag y) => x.CompareTo(y) > 0;
            public static bool operator >=(Tag x, Tag y) => x.CompareTo(y) >= 0;

            public override int GetHashCode() => CmpTuple.GetHashCode();

            public override string ToString() => $"(PhonecallsEnabled: {PhonecallsEnabled}, DefaultP2pContacts: {DefaultP2pContacts}, PreloadFeaturedStickers: {PreloadFeaturedStickers}, IgnorePhoneEntities: {IgnorePhoneEntities}, RevokePmInbox: {RevokePmInbox}, BlockedMode: {BlockedMode}, Date: {Date}, Expires: {Expires}, TestMode: {TestMode}, ThisDc: {ThisDc}, DcOptions: {DcOptions}, DcTxtDomainName: {DcTxtDomainName}, ChatSizeMax: {ChatSizeMax}, MegagroupSizeMax: {MegagroupSizeMax}, ForwardedCountMax: {ForwardedCountMax}, OnlineUpdatePeriodMs: {OnlineUpdatePeriodMs}, OfflineBlurTimeoutMs: {OfflineBlurTimeoutMs}, OfflineIdleTimeoutMs: {OfflineIdleTimeoutMs}, OnlineCloudTimeoutMs: {OnlineCloudTimeoutMs}, NotifyCloudDelayMs: {NotifyCloudDelayMs}, NotifyDefaultDelayMs: {NotifyDefaultDelayMs}, PushChatPeriodMs: {PushChatPeriodMs}, PushChatLimit: {PushChatLimit}, SavedGifsLimit: {SavedGifsLimit}, EditTimeLimit: {EditTimeLimit}, RevokeTimeLimit: {RevokeTimeLimit}, RevokePmTimeLimit: {RevokePmTimeLimit}, RatingEDecay: {RatingEDecay}, StickersRecentLimit: {StickersRecentLimit}, StickersFavedLimit: {StickersFavedLimit}, ChannelsReadMediaPeriod: {ChannelsReadMediaPeriod}, TmpSessions: {TmpSessions}, PinnedDialogsCountMax: {PinnedDialogsCountMax}, CallReceiveTimeoutMs: {CallReceiveTimeoutMs}, CallRingTimeoutMs: {CallRingTimeoutMs}, CallConnectTimeoutMs: {CallConnectTimeoutMs}, CallPacketTimeoutMs: {CallPacketTimeoutMs}, MeUrlPrefix: {MeUrlPrefix}, AutoupdateUrlPrefix: {AutoupdateUrlPrefix}, GifSearchUsername: {GifSearchUsername}, VenueSearchUsername: {VenueSearchUsername}, ImgSearchUsername: {ImgSearchUsername}, StaticMapsProvider: {StaticMapsProvider}, CaptionLengthMax: {CaptionLengthMax}, MessageLengthMax: {MessageLengthMax}, WebfileDcId: {WebfileDcId}, SuggestedLangCode: {SuggestedLangCode}, LangPackVersion: {LangPackVersion})";
            
            
            void ITlSerializable.Serialize(BinaryWriter bw)
            {
                Write(MaskBit(1, PhonecallsEnabled) | MaskBit(3, DefaultP2pContacts) | MaskBit(4, PreloadFeaturedStickers) | MaskBit(5, IgnorePhoneEntities) | MaskBit(6, RevokePmInbox) | MaskBit(8, BlockedMode) | MaskBit(0, TmpSessions) | MaskBit(7, AutoupdateUrlPrefix) | MaskBit(9, GifSearchUsername) | MaskBit(10, VenueSearchUsername) | MaskBit(11, ImgSearchUsername) | MaskBit(12, StaticMapsProvider) | MaskBit(2, SuggestedLangCode) | MaskBit(2, LangPackVersion), bw, WriteInt);
                Write(Date, bw, WriteInt);
                Write(Expires, bw, WriteInt);
                Write(TestMode, bw, WriteBool);
                Write(ThisDc, bw, WriteInt);
                Write(DcOptions, bw, WriteVector<T.DcOption>(WriteSerializable));
                Write(DcTxtDomainName, bw, WriteString);
                Write(ChatSizeMax, bw, WriteInt);
                Write(MegagroupSizeMax, bw, WriteInt);
                Write(ForwardedCountMax, bw, WriteInt);
                Write(OnlineUpdatePeriodMs, bw, WriteInt);
                Write(OfflineBlurTimeoutMs, bw, WriteInt);
                Write(OfflineIdleTimeoutMs, bw, WriteInt);
                Write(OnlineCloudTimeoutMs, bw, WriteInt);
                Write(NotifyCloudDelayMs, bw, WriteInt);
                Write(NotifyDefaultDelayMs, bw, WriteInt);
                Write(PushChatPeriodMs, bw, WriteInt);
                Write(PushChatLimit, bw, WriteInt);
                Write(SavedGifsLimit, bw, WriteInt);
                Write(EditTimeLimit, bw, WriteInt);
                Write(RevokeTimeLimit, bw, WriteInt);
                Write(RevokePmTimeLimit, bw, WriteInt);
                Write(RatingEDecay, bw, WriteInt);
                Write(StickersRecentLimit, bw, WriteInt);
                Write(StickersFavedLimit, bw, WriteInt);
                Write(ChannelsReadMediaPeriod, bw, WriteInt);
                Write(TmpSessions, bw, WriteOption<int>(WriteInt));
                Write(PinnedDialogsCountMax, bw, WriteInt);
                Write(CallReceiveTimeoutMs, bw, WriteInt);
                Write(CallRingTimeoutMs, bw, WriteInt);
                Write(CallConnectTimeoutMs, bw, WriteInt);
                Write(CallPacketTimeoutMs, bw, WriteInt);
                Write(MeUrlPrefix, bw, WriteString);
                Write(AutoupdateUrlPrefix, bw, WriteOption<string>(WriteString));
                Write(GifSearchUsername, bw, WriteOption<string>(WriteString));
                Write(VenueSearchUsername, bw, WriteOption<string>(WriteString));
                Write(ImgSearchUsername, bw, WriteOption<string>(WriteString));
                Write(StaticMapsProvider, bw, WriteOption<string>(WriteString));
                Write(CaptionLengthMax, bw, WriteInt);
                Write(MessageLengthMax, bw, WriteInt);
                Write(WebfileDcId, bw, WriteInt);
                Write(SuggestedLangCode, bw, WriteOption<string>(WriteString));
                Write(LangPackVersion, bw, WriteOption<int>(WriteInt));
            }
            
            internal static Tag DeserializeTag(BinaryReader br)
            {
                var flags = Read(br, ReadInt);
                var phonecallsEnabled = Read(br, ReadOption(flags, 1));
                var defaultP2pContacts = Read(br, ReadOption(flags, 3));
                var preloadFeaturedStickers = Read(br, ReadOption(flags, 4));
                var ignorePhoneEntities = Read(br, ReadOption(flags, 5));
                var revokePmInbox = Read(br, ReadOption(flags, 6));
                var blockedMode = Read(br, ReadOption(flags, 8));
                var date = Read(br, ReadInt);
                var expires = Read(br, ReadInt);
                var testMode = Read(br, ReadBool);
                var thisDc = Read(br, ReadInt);
                var dcOptions = Read(br, ReadVector(T.DcOption.Deserialize));
                var dcTxtDomainName = Read(br, ReadString);
                var chatSizeMax = Read(br, ReadInt);
                var megagroupSizeMax = Read(br, ReadInt);
                var forwardedCountMax = Read(br, ReadInt);
                var onlineUpdatePeriodMs = Read(br, ReadInt);
                var offlineBlurTimeoutMs = Read(br, ReadInt);
                var offlineIdleTimeoutMs = Read(br, ReadInt);
                var onlineCloudTimeoutMs = Read(br, ReadInt);
                var notifyCloudDelayMs = Read(br, ReadInt);
                var notifyDefaultDelayMs = Read(br, ReadInt);
                var pushChatPeriodMs = Read(br, ReadInt);
                var pushChatLimit = Read(br, ReadInt);
                var savedGifsLimit = Read(br, ReadInt);
                var editTimeLimit = Read(br, ReadInt);
                var revokeTimeLimit = Read(br, ReadInt);
                var revokePmTimeLimit = Read(br, ReadInt);
                var ratingEDecay = Read(br, ReadInt);
                var stickersRecentLimit = Read(br, ReadInt);
                var stickersFavedLimit = Read(br, ReadInt);
                var channelsReadMediaPeriod = Read(br, ReadInt);
                var tmpSessions = Read(br, ReadOption(flags, 0, ReadInt));
                var pinnedDialogsCountMax = Read(br, ReadInt);
                var callReceiveTimeoutMs = Read(br, ReadInt);
                var callRingTimeoutMs = Read(br, ReadInt);
                var callConnectTimeoutMs = Read(br, ReadInt);
                var callPacketTimeoutMs = Read(br, ReadInt);
                var meUrlPrefix = Read(br, ReadString);
                var autoupdateUrlPrefix = Read(br, ReadOption(flags, 7, ReadString));
                var gifSearchUsername = Read(br, ReadOption(flags, 9, ReadString));
                var venueSearchUsername = Read(br, ReadOption(flags, 10, ReadString));
                var imgSearchUsername = Read(br, ReadOption(flags, 11, ReadString));
                var staticMapsProvider = Read(br, ReadOption(flags, 12, ReadString));
                var captionLengthMax = Read(br, ReadInt);
                var messageLengthMax = Read(br, ReadInt);
                var webfileDcId = Read(br, ReadInt);
                var suggestedLangCode = Read(br, ReadOption(flags, 2, ReadString));
                var langPackVersion = Read(br, ReadOption(flags, 2, ReadInt));
                return new Tag(phonecallsEnabled, defaultP2pContacts, preloadFeaturedStickers, ignorePhoneEntities, revokePmInbox, blockedMode, date, expires, testMode, thisDc, dcOptions, dcTxtDomainName, chatSizeMax, megagroupSizeMax, forwardedCountMax, onlineUpdatePeriodMs, offlineBlurTimeoutMs, offlineIdleTimeoutMs, onlineCloudTimeoutMs, notifyCloudDelayMs, notifyDefaultDelayMs, pushChatPeriodMs, pushChatLimit, savedGifsLimit, editTimeLimit, revokeTimeLimit, revokePmTimeLimit, ratingEDecay, stickersRecentLimit, stickersFavedLimit, channelsReadMediaPeriod, tmpSessions, pinnedDialogsCountMax, callReceiveTimeoutMs, callRingTimeoutMs, callConnectTimeoutMs, callPacketTimeoutMs, meUrlPrefix, autoupdateUrlPrefix, gifSearchUsername, venueSearchUsername, imgSearchUsername, staticMapsProvider, captionLengthMax, messageLengthMax, webfileDcId, suggestedLangCode, langPackVersion);
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

        public bool Equals(Config other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpPair == other.CmpPair);
        public override bool Equals(object other) => other is Config x && Equals(x);
        public static bool operator ==(Config x, Config y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(Config x, Config y) => !(x == y);

        public int CompareTo(Config other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpPair.CompareTo(other.CmpPair);
        int IComparable.CompareTo(object other) => other is Config x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(Config x, Config y) => x.CompareTo(y) <= 0;
        public static bool operator <(Config x, Config y) => x.CompareTo(y) < 0;
        public static bool operator >(Config x, Config y) => x.CompareTo(y) > 0;
        public static bool operator >=(Config x, Config y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpPair.GetHashCode();

        public override string ToString() => $"Config.{_tag.GetType().Name}{_tag}";
    }
}