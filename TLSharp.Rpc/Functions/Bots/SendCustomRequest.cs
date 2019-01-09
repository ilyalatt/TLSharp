using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Bots
{
    public sealed class SendCustomRequest : Record<SendCustomRequest>, ITlFunc<T.DataJson>
    {
        public string CustomMethod { get; }
        public T.DataJson Params { get; }
        
        public SendCustomRequest(
            Some<string> customMethod,
            Some<T.DataJson> @params
        ) {
            CustomMethod = customMethod;
            Params = @params;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xaa2769ed);
            Write(CustomMethod, bw, WriteString);
            Write(Params, bw, WriteSerializable);
        }
        
        T.DataJson ITlFunc<T.DataJson>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DataJson.Deserialize);
    }
}