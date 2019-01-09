using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdatePasswordSettings : Record<UpdatePasswordSettings>, ITlFunc<bool>
    {
        public Arr<byte> CurrentPasswordHash { get; }
        public T.Account.PasswordInputSettings NewSettings { get; }
        
        public UpdatePasswordSettings(
            Some<Arr<byte>> currentPasswordHash,
            Some<T.Account.PasswordInputSettings> newSettings
        ) {
            CurrentPasswordHash = currentPasswordHash;
            NewSettings = newSettings;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xfa7c4b86);
            Write(CurrentPasswordHash, bw, WriteBytes);
            Write(NewSettings, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}