using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetPrivacy : Record<GetPrivacy>, ITlFunc<T.Account.PrivacyRules>
    {
        public T.InputPrivacyKey Key { get; }
        
        public GetPrivacy(
            Some<T.InputPrivacyKey> key
        ) {
            Key = key;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xdadbc950);
            Write(Key, bw, WriteSerializable);
        }
        
        T.Account.PrivacyRules ITlFunc<T.Account.PrivacyRules>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.PrivacyRules.Deserialize);
    }
}