using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class ConfirmCall : Record<ConfirmCall>, ITlFunc<T.Phone.PhoneCall>
    {
        public T.InputPhoneCall Peer { get; }
        public Arr<byte> Ga { get; }
        public long KeyFingerprint { get; }
        public T.PhoneCallProtocol Protocol { get; }
        
        public ConfirmCall(
            Some<T.InputPhoneCall> peer,
            Some<Arr<byte>> ga,
            long keyFingerprint,
            Some<T.PhoneCallProtocol> protocol
        ) {
            Peer = peer;
            Ga = ga;
            KeyFingerprint = keyFingerprint;
            Protocol = protocol;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x2efe1722);
            Write(Peer, bw, WriteSerializable);
            Write(Ga, bw, WriteBytes);
            Write(KeyFingerprint, bw, WriteLong);
            Write(Protocol, bw, WriteSerializable);
        }
        
        T.Phone.PhoneCall ITlFunc<T.Phone.PhoneCall>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Phone.PhoneCall.Deserialize);
    }
}