using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class ResolveUsername : Record<ResolveUsername>, ITlFunc<T.Contacts.ResolvedPeer>
    {
        public string Username { get; }
        
        public ResolveUsername(
            Some<string> username
        ) {
            Username = username;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf93ccba3);
            Write(Username, bw, WriteString);
        }
        
        T.Contacts.ResolvedPeer ITlFunc<T.Contacts.ResolvedPeer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.ResolvedPeer.Deserialize);
    }
}