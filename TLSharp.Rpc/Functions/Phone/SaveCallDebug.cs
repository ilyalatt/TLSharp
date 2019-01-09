using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class SaveCallDebug : Record<SaveCallDebug>, ITlFunc<bool>
    {
        public T.InputPhoneCall Peer { get; }
        public T.DataJson Debug { get; }
        
        public SaveCallDebug(
            Some<T.InputPhoneCall> peer,
            Some<T.DataJson> debug
        ) {
            Peer = peer;
            Debug = debug;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x277add7e);
            Write(Peer, bw, WriteSerializable);
            Write(Debug, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}