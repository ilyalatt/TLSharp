using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Help
{
    public sealed class GetInviteText : Record<GetInviteText>, ITlFunc<T.Help.InviteText>
    {

        
        public GetInviteText(

        ) {

        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x4d392343);

        }
        
        T.Help.InviteText ITlFunc<T.Help.InviteText>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Help.InviteText.Deserialize);
    }
}