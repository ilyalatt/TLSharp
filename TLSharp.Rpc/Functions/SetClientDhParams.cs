using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions
{
    public sealed class SetClientDhParams : ITlFunc<T.SetClientDhParamsAnswer>, IEquatable<SetClientDhParams>, IComparable<SetClientDhParams>, IComparable
    {
        public Int128 Nonce { get; }
        public Int128 ServerNonce { get; }
        public Arr<byte> EncryptedData { get; }
        
        public SetClientDhParams(
            Int128 nonce,
            Int128 serverNonce,
            Some<Arr<byte>> encryptedData
        ) {
            Nonce = nonce;
            ServerNonce = serverNonce;
            EncryptedData = encryptedData;
        }
        
        
        (Int128, Int128, Arr<byte>) CmpTuple =>
            (Nonce, ServerNonce, EncryptedData);

        public bool Equals(SetClientDhParams other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SetClientDhParams x && Equals(x);
        public static bool operator ==(SetClientDhParams x, SetClientDhParams y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SetClientDhParams x, SetClientDhParams y) => !(x == y);

        public int CompareTo(SetClientDhParams other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SetClientDhParams x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SetClientDhParams x, SetClientDhParams y) => x.CompareTo(y) <= 0;
        public static bool operator <(SetClientDhParams x, SetClientDhParams y) => x.CompareTo(y) < 0;
        public static bool operator >(SetClientDhParams x, SetClientDhParams y) => x.CompareTo(y) > 0;
        public static bool operator >=(SetClientDhParams x, SetClientDhParams y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Nonce: {Nonce}, ServerNonce: {ServerNonce}, EncryptedData: {EncryptedData})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xf5045f1f);
            Write(Nonce, bw, WriteInt128);
            Write(ServerNonce, bw, WriteInt128);
            Write(EncryptedData, bw, WriteBytes);
        }
        
        T.SetClientDhParamsAnswer ITlFunc<T.SetClientDhParamsAnswer>.DeserializeResult(BinaryReader br) =>
            Read(br, T.SetClientDhParamsAnswer.Deserialize);
    }
}