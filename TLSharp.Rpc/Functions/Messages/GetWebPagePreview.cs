using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class GetWebPagePreview : ITlFunc<T.MessageMedia>, IEquatable<GetWebPagePreview>, IComparable<GetWebPagePreview>, IComparable
    {
        public string Message { get; }
        public Option<Arr<T.MessageEntity>> Entities { get; }
        
        public GetWebPagePreview(
            Some<string> message,
            Option<Arr<T.MessageEntity>> entities
        ) {
            Message = message;
            Entities = entities;
        }
        
        
        (string, Option<Arr<T.MessageEntity>>) CmpTuple =>
            (Message, Entities);

        public bool Equals(GetWebPagePreview other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetWebPagePreview x && Equals(x);
        public static bool operator ==(GetWebPagePreview x, GetWebPagePreview y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetWebPagePreview x, GetWebPagePreview y) => !(x == y);

        public int CompareTo(GetWebPagePreview other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetWebPagePreview x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetWebPagePreview x, GetWebPagePreview y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetWebPagePreview x, GetWebPagePreview y) => x.CompareTo(y) < 0;
        public static bool operator >(GetWebPagePreview x, GetWebPagePreview y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetWebPagePreview x, GetWebPagePreview y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Message: {Message}, Entities: {Entities})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8b68b0cc);
            Write(MaskBit(3, Entities), bw, WriteInt);
            Write(Message, bw, WriteString);
            Write(Entities, bw, WriteOption<Arr<T.MessageEntity>>(WriteVector<T.MessageEntity>(WriteSerializable)));
        }
        
        T.MessageMedia ITlFunc<T.MessageMedia>.DeserializeResult(BinaryReader br) =>
            Read(br, T.MessageMedia.Deserialize);
    }
}