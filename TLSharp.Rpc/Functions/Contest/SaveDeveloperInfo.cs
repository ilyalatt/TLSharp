using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contest
{
    public sealed class SaveDeveloperInfo : Record<SaveDeveloperInfo>, ITlFunc<bool>
    {
        public int VkId { get; }
        public string Name { get; }
        public string PhoneNumber { get; }
        public int Age { get; }
        public string City { get; }
        
        public SaveDeveloperInfo(
            int vkId,
            Some<string> name,
            Some<string> phoneNumber,
            int age,
            Some<string> city
        ) {
            VkId = vkId;
            Name = name;
            PhoneNumber = phoneNumber;
            Age = age;
            City = city;
        }
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x9a5f6e95);
            Write(VkId, bw, WriteInt);
            Write(Name, bw, WriteString);
            Write(PhoneNumber, bw, WriteString);
            Write(Age, bw, WriteInt);
            Write(City, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}