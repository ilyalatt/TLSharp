using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateDeviceLocked : Record<UpdateDeviceLocked>, ITlFunc<bool>
    {
        public int Period { get; }
        
        public UpdateDeviceLocked(
            int period
        ) {
            Period = period;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x38df3532);
            Write(Period, bw, WriteInt);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}