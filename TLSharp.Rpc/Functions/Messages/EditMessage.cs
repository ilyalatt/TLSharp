using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class EditMessage : ITlFunc<T.UpdatesType>, IEquatable<EditMessage>, IComparable<EditMessage>, IComparable
    {
        public bool NoWebpage { get; }
        public bool StopGeoLive { get; }
        public T.InputPeer Peer { get; }
        public int Id { get; }
        public Option<string> Message { get; }
        public Option<T.InputMedia> Media { get; }
        public Option<T.ReplyMarkup> ReplyMarkup { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        public Option<T.InputGeoPoint> GeoPoint { get; }
        
        public EditMessage(
            bool noWebpage,
            bool stopGeoLive,
            Some<T.InputPeer> peer,
            int id,
            Option<string> message,
            Option<T.InputMedia> media,
            Option<T.ReplyMarkup> replyMarkup,
            Option<Arr<T.MessageEntity>> entities,
            Option<T.InputGeoPoint> geoPoint
        ) {
            NoWebpage = noWebpage;
            StopGeoLive = stopGeoLive;
            Peer = peer;
            Id = id;
            Message = message;
            Media = media;
            ReplyMarkup = replyMarkup;
            Entities = entities;
            GeoPoint = geoPoint;
        }
        
        
        (bool, bool, T.InputPeer, int, Option<string>, Option<T.InputMedia>, Option<T.ReplyMarkup>, Option<Arr<T.MessageEntity>>, Option<T.InputGeoPoint>) CmpTuple =>
            (NoWebpage, StopGeoLive, Peer, Id, Message, Media, ReplyMarkup, Entities, GeoPoint);

        public bool Equals(EditMessage other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is EditMessage x && Equals(x);
        public static bool operator ==(EditMessage x, EditMessage y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(EditMessage x, EditMessage y) => !(x == y);

        public int CompareTo(EditMessage other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is EditMessage x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(EditMessage x, EditMessage y) => x.CompareTo(y) <= 0;
        public static bool operator <(EditMessage x, EditMessage y) => x.CompareTo(y) < 0;
        public static bool operator >(EditMessage x, EditMessage y) => x.CompareTo(y) > 0;
        public static bool operator >=(EditMessage x, EditMessage y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(NoWebpage: {NoWebpage}, StopGeoLive: {StopGeoLive}, Peer: {Peer}, Id: {Id}, Message: {Message}, Media: {Media}, ReplyMarkup: {ReplyMarkup}, Entities: {Entities}, GeoPoint: {GeoPoint})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc000e4c8);
            Write(MaskBit(1, NoWebpage) | MaskBit(12, StopGeoLive) | MaskBit(11, Message) | MaskBit(14, Media) | MaskBit(2, ReplyMarkup) | MaskBit(3, Entities) | MaskBit(13, GeoPoint), bw, WriteInt);
            Write(Peer, bw, WriteSerializable);
            Write(Id, bw, WriteInt);
            Write(Message, bw, WriteOption<string>(WriteString));
            Write(Media, bw, WriteOption<T.InputMedia>(WriteSerializable));
            Write(ReplyMarkup, bw, WriteOption<T.ReplyMarkup>(WriteSerializable));
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
            Write(GeoPoint, bw, WriteOption<T.InputGeoPoint>(WriteSerializable));
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}