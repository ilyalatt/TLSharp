using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class RequestCall : Record<RequestCall>, ITlFunc<T.Phone.PhoneCall>
    {
        public T.InputUser UserId { get; }
        public int RandomId { get; }
        public Arr<byte> GaHash { get; }
        public T.PhoneCallProtocol Protocol { get; }
        
        public RequestCall(
            Some<T.InputUser> userId,
            int randomId,
            Some<Arr<byte>> gaHash,
            Some<T.PhoneCallProtocol> protocol
        ) {
            UserId = userId;
            RandomId = randomId;
            GaHash = gaHash;
            Protocol = protocol;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x5b95b3d4);
            Write(UserId, bw, WriteSerializable);
            Write(RandomId, bw, WriteInt);
            Write(GaHash, bw, WriteBytes);
            Write(Protocol, bw, WriteSerializable);
        }
        
        T.Phone.PhoneCall ITlFunc<T.Phone.PhoneCall>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Phone.PhoneCall.Deserialize);
    }
}