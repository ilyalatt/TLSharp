using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditInlineBotMessage : ITlFunc<bool>, IEquatable<EditInlineBotMessage>, IComparable<EditInlineBotMessage>, IComparable
    {
        public bool NoWebpage { get; }
        public bool StopGeoLive { get; }
        public T.InputBotInlineMessageId Id { get; }
        public Option<string> Message { get; }
        public Option<T.InputMedia> Media { get; }
        public Option<T.ReplyMarkup> ReplyMarkup { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        public Option<T.InputGeoPoint> GeoPoint { get; }
        
        public EditInlineBotMessage(
            bool noWebpage,
            bool stopGeoLive,
            Some<T.InputBotInlineMessageId> id,
            Option<string> message,
            Option<T.InputMedia> media,
            Option<T.ReplyMarkup> replyMarkup,
            Option<Arr<T.MessageEntity>> entities,
            Option<T.InputGeoPoint> geoPoint
        ) {
            NoWebpage = noWebpage;
            StopGeoLive = stopGeoLive;
            Id = id;
            Message = message;
            Media = media;
            ReplyMarkup = replyMarkup;
            Entities = entities;
            GeoPoint = geoPoint;
        }
        
        
        (bool, bool, T.InputBotInlineMessageId, Option<string>, Option<T.InputMedia>, Option<T.ReplyMarkup>, Option<Arr<T.MessageEntity>>, Option<T.InputGeoPoint>) CmpTuple =>
            (NoWebpage, StopGeoLive, Id, Message, Media, ReplyMarkup, Entities, GeoPoint);

        public bool Equals(EditInlineBotMessage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is EditInlineBotMessage x && Equals(x);
        public static bool operator ==(EditInlineBotMessage x, EditInlineBotMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditInlineBotMessage x, EditInlineBotMessage y) => !(x == y);

        public int CompareTo(EditInlineBotMessage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is EditInlineBotMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditInlineBotMessage x, EditInlineBotMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditInlineBotMessage x, EditInlineBotMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(EditInlineBotMessage x, EditInlineBotMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditInlineBotMessage x, EditInlineBotMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(NoWebpage: {NoWebpage}, StopGeoLive: {StopGeoLive}, Id: {Id}, Message: {Message}, Media: {Media}, ReplyMarkup: {ReplyMarkup}, Entities: {Entities}, GeoPoint: {GeoPoint})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xadc3e828);
            Write(MaskBit(1, NoWebpage) | MaskBit(12, StopGeoLive) | MaskBit(11, Message) | MaskBit(14, Media) | MaskBit(2, ReplyMarkup) | MaskBit(3, Entities) | MaskBit(13, GeoPoint), bw, WriteInt);
            Write(Id, bw, WriteSerializable);
            Write(Message, bw, WriteOption<string>(WriteString));
            Write(Media, bw, WriteOption<T.InputMedia>(WriteSerializable));
            Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
            Write(GeoPoint, bw, WriteOption<T.InputGeoPoint>(WriteSerializable));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}