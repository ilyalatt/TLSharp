using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateUsername : Record<UpdateUsername>, ITlFunc<T.User>
    {
        public string Username { get; }
        
        public UpdateUsername(
            Some<string> username
        ) {
            Username = username;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x3e0bdd7c);
            Write(Username, bw, WriteString);
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}