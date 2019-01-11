using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Channels
{
    public sealed class CheckUsername : ITlFunc<bool>, IEquatable<CheckUsername>, IComparable<CheckUsername>, IComparable
    {
        public T.InputChannel Channel { get; }
        public string Username { get; }
        
        public CheckUsername(
            Some<T.InputChannel> channel,
            Some<string> username
        ) {
            Channel = channel;
            Username = username;
        }
        
        
        (T.InputChannel, string) CmpTuple =>
            (Channel, Username);

        public bool Equals(CheckUsername other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is CheckUsername x && Equals(x);
        public static bool operator ==(CheckUsername x, CheckUsername y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(CheckUsername x, CheckUsername y) => !(x == y);

        public int CompareTo(CheckUsername other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is CheckUsername x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(CheckUsername x, CheckUsername y) => x.CompareTo(y) <= 0;
        public static bool operator <(CheckUsername x, CheckUsername y) => x.CompareTo(y) < 0;
        public static bool operator >(CheckUsername x, CheckUsername y) => x.CompareTo(y) > 0;
        public static bool operator >=(CheckUsername x, CheckUsername y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Channel: {Channel}, Username: {Username})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x10e6bd2c);
            Write(Channel, bw, WriteSerializable);
            Write(Username, bw, WriteString);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}