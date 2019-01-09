using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class UpdateProfile : Record<UpdateProfile>, ITlFunc<T.User>
    {
        public Option<string> FirstName { get; }
        public Option<string> LastName { get; }
        public Option<string> About { get; }
        
        public UpdateProfile(
            Option<string> firstName,
            Option<string> lastName,
            Option<string> about
        ) {
            FirstName = firstName;
            LastName = lastName;
            About = about;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x78515775);
            Write(MaskBit(0, FirstName) | MaskBit(1, LastName) | MaskBit(2, About), bw, WriteInt);
            Write(FirstName, bw, WriteOption<string>(WriteString));
            Write(LastName, bw, WriteOption<string>(WriteString));
            Write(About, bw, WriteOption<string>(WriteString));
        }
        
        T.User ITlFunc<T.User>.DeserializeResult(BinaryReader br) =>
            Read(br, T.User.Deserialize);
    }
}