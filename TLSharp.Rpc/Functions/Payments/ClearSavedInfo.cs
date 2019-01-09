using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Payments
{
    public sealed class ClearSavedInfo : Record<ClearSavedInfo>, ITlFunc<bool>
    {
        public bool Credentials { get; }
        public bool Info { get; }
        
        public ClearSavedInfo(
            bool credentials,
            bool info
        ) {
            Credentials = credentials;
            Info = info;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd83d70c1);
            Write(MaskBit(0, Credentials) | MaskBit(1, Info), bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}