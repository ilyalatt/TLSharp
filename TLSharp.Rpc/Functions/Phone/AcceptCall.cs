using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class AcceptCall : Record<AcceptCall>, ITlFunc<T.Phone.PhoneCall>
    {
        public T.InputPhoneCall Peer { get; }
        public Arr<byte> Gb { get; }
        public T.PhoneCallProtocol Protocol { get; }
        
        public AcceptCall(
            Some<T.InputPhoneCall> peer,
            Some<Arr<byte>> gb,
            Some<T.PhoneCallProtocol> protocol
        ) {
            Peer = peer;
            Gb = gb;
            Protocol = protocol;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3bd2b4a0);
            Write(Peer, bw, WriteSerializable);
            Write(Gb, bw, WriteBytes);
            Write(Protocol, bw, WriteSerializable);
        }
        
        T.Phone.PhoneCall ITlFunc<T.Phone.PhoneCall>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Phone.PhoneCall.Deserialize);
    }
}