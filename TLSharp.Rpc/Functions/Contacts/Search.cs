using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contacts
{
    public sealed class Search : Record<Search>, ITlFunc<T.Contacts.Found>
    {
        public string Q { get; }
        public int Limit { get; }
        
        public Search(
            Some<string> q,
            int limit
        ) {
            Q = q;
            Limit = limit;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x11f812d8);
            Write(Q, bw, WriteString);
            Write(Limit, bw, WriteInt);
        }
        
        T.Contacts.Found ITlFunc<T.Contacts.Found>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Contacts.Found.Deserialize);
    }
}