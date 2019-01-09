using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class SetPrivacy : Record<SetPrivacy>, ITlFunc<T.Account.PrivacyRules>
    {
        public T.InputPrivacyKey Key { get; }
        public Arr<T.InputPrivacyRule> Rules { get; }
        
        public SetPrivacy(
            Some<T.InputPrivacyKey> key,
            Some<Arr<T.InputPrivacyRule>> rules
        ) {
            Key = key;
            Rules = rules;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xc9f81ce8);
            Write(Key, bw, WriteSerializable);
            Write(Rules, bw, WriteVector<T.InputPrivacyRule>(WriteSerializable));
        }
        
        T.Account.PrivacyRules ITlFunc<T.Account.PrivacyRules>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.PrivacyRules.Deserialize);
    }
}