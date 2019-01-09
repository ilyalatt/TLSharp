using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class GetBlocked : Record<GetBlocked>, ITlFunc<T.Contacts.Blocked>
    {
        public int Offset { get; }
        public int Limit { get; }
        
        public GetBlocked(
            int offset,
            int limit
        ) {
            Offset = offset;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf57c350f);
            Write(Offset, bw, WriteInt);
            Write(Limit, bw, WriteInt);
        }
        
        T.Contacts.Blocked ITlFunc<T.Contacts.Blocked>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Blocked.Deserialize);
    }
}