using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Bots
{
    public sealed class SendCustomRequest : ITlFunc<T.DataJson>, IEquatable<SendCustomRequest>, IComparable<SendCustomRequest>, IComparable
    {
        public string CustomMethod { get; }
        public T.DataJson Params { get; }
        
        public SendCustomRequest(
            Some<string> customMethod,
            Some<T.DataJson> @params
        ) {
            CustomMethod = customMethod;
            Params = @params;
        }
        
        
        (string, T.DataJson) CmpTuple =>
            (CustomMethod, Params);

        public bool Equals(SendCustomRequest other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SendCustomRequest x && Equals(x);
        public static bool operator ==(SendCustomRequest x, SendCustomRequest y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SendCustomRequest x, SendCustomRequest y) => !(x == y);

        public int CompareTo(SendCustomRequest other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SendCustomRequest x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SendCustomRequest x, SendCustomRequest y) => x.CompareTo(y) <= 0;
        public static bool operator <(SendCustomRequest x, SendCustomRequest y) => x.CompareTo(y) < 0;
        public static bool operator >(SendCustomRequest x, SendCustomRequest y) => x.CompareTo(y) > 0;
        public static bool operator >=(SendCustomRequest x, SendCustomRequest y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(CustomMethod: {CustomMethod}, Params: {Params})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xaa2769ed);
            Write(CustomMethod, bw, WriteString);
            Write(Params, bw, WriteSerializable);
        }
        
        T.DataJson ITlFunc<T.DataJson>.DeserializeResult(BinaryReader br) =>
            Read(br, T.DataJson.Deserialize);
    }
}