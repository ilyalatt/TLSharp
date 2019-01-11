using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Contest
{
    public sealed class SaveDeveloperInfo : ITlFunc<bool>, IEquatable<SaveDeveloperInfo>, IComparable<SaveDeveloperInfo>, IComparable
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
        
        
        (int, string, string, int, string) CmpTuple =>
            (VkId, Name, PhoneNumber, Age, City);

        public bool Equals(SaveDeveloperInfo other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is SaveDeveloperInfo x && Equals(x);
        public static bool operator ==(SaveDeveloperInfo x, SaveDeveloperInfo y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveDeveloperInfo x, SaveDeveloperInfo y) => !(x == y);

        public int CompareTo(SaveDeveloperInfo other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is SaveDeveloperInfo x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveDeveloperInfo x, SaveDeveloperInfo y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveDeveloperInfo x, SaveDeveloperInfo y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveDeveloperInfo x, SaveDeveloperInfo y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveDeveloperInfo x, SaveDeveloperInfo y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(VkId: {VkId}, Name: {Name}, PhoneNumber: {PhoneNumber}, Age: {Age}, City: {City})";
        
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