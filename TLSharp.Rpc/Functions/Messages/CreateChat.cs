using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Messages
{
    public sealed class CreateChat : Record<CreateChat>, ITlFunc<T.UpdatesType>
    {
        public Arr<T.InputUser> Users { get; }
        public string Title { get; }
        
        public CreateChat(
            Some<Arr<T.InputUser>> users,
            Some<string> title
        ) {
            Users = users;
            Title = title;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x09cb126e);
            Write(Users, bw, WriteVector<T.InputUser>(WriteSerializable));
            Write(Title, bw, WriteString);
        }
        
        T.UpdatesType ITlFunc<T.UpdatesType>.DeserializeResult(BinaryReader br) =>
            Read(br, T.UpdatesType.Deserialize);
    }
}