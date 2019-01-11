using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Phone
{
    public sealed class SaveCallDebug : ITlFunc<bool>, IEquatable<SaveCallDebug>, IComparable<SaveCallDebug>, IComparable
    {
        public T.InputPhoneCall Peer { get; }
        public T.DataJson Debug { get; }
        
        public SaveCallDebug(
            Some<T.InputPhoneCall> peer,
            Some<T.DataJson> debug
        ) {
            Peer = peer;
            Debug = debug;
        }
        
        
        (T.InputPhoneCall, T.DataJson) CmpTuple =>
            (Peer, Debug);

        public bool Equals(SaveCallDebug other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is SaveCallDebug x && Equals(x);
        public static bool operator ==(SaveCallDebug x, SaveCallDebug y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(SaveCallDebug x, SaveCallDebug y) => !(x == y);

        public int CompareTo(SaveCallDebug other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is SaveCallDebug x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(SaveCallDebug x, SaveCallDebug y) => x.CompareTo(y) <= 0;
        public static bool operator <(SaveCallDebug x, SaveCallDebug y) => x.CompareTo(y) < 0;
        public static bool operator >(SaveCallDebug x, SaveCallDebug y) => x.CompareTo(y) > 0;
        public static bool operator >=(SaveCallDebug x, SaveCallDebug y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Peer: {Peer}, Debug: {Debug})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x277add7e);
            Write(Peer, bw, WriteSerializable);
            Write(Debug, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}