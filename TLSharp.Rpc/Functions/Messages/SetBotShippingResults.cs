using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class SetBotShippingResults : Record<SetBotShippingResults>, ITlFunc<bool>
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