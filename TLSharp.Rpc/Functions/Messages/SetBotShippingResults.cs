using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetBotShippingResults : ITlFunc<bool>, IEquatable<SetBotShippingResults>, IComparable<SetBotShippingResults>, IComparable
    {
        public long QueryId { get; }
        public Option<string> Error { get; }
        public Option<Arr<T.ShippingOption>> ShippingOptions { get; }
        
        public SetBotShippingResults(
            long queryId,
            Option<string> error,
            Option<Arr<T.ShippingOption>> shippingOptions
        ) {
            QueryId = queryId;
            Error = error;
            ShippingOptions = shippingOptions;
        }
        
        
        (long, Option<string>, Option<Arr<T.ShippingOption>>) CmpTuple =>
            (QueryId, Error, ShippingOptions);

        public bool Equals(SetBotShippingResults other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SetBotShippingResults x && Equals(x);
        public static bool operator ==(SetBotShippingResults x, SetBotShippingResults y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetBotShippingResults x, SetBotShippingResults y) => !(x == y);

        public int CompareTo(SetBotShippingResults other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SetBotShippingResults x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetBotShippingResults x, SetBotShippingResults y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetBotShippingResults x, SetBotShippingResults y) => x.CompareTo(y) < 0;
        public static bool operator >(SetBotShippingResults x, SetBotShippingResults y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetBotShippingResults x, SetBotShippingResults y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(QueryId: {QueryId}, Error: {Error}, ShippingOptions: {ShippingOptions})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe5f672fa);
            Write(MaskBit(0, Error) | MaskBit(1, ShippingOptions), bw, WriteInt);
            Write(QueryId, bw, WriteLong);
            Write(Error, bw, WriteOption<string>(WriteString));
            Write(ShippingOptions, bw, WriteOption<Arr<T.ShippingOption>>(WriteVector<T.ShippingOption>(WriteSerializable)));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}