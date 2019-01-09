using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class DropTempAuthKeys : Record<DropTempAuthKeys>, ITlFunc<bool>
    {
        public Arr<long> ExceptAuthKeys { get; }
        
        public DropTempAuthKeys(
            Some<Arr<long>> exceptAuthKeys
        ) {
            ExceptAuthKeys = exceptAuthKeys;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x8e48a188);
            Write(ExceptAuthKeys, bw, WriteVector<long>(WriteLong));
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}