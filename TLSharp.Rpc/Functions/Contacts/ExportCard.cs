using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ExportCard : Record<ExportCard>, ITlFunc<Arr<int>>
    {

        
        public ExportCard(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x84e53737);

        }
        
        Arr<int> ITlFunc<Arr<int>>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadVector(ReadInt));
    }
}