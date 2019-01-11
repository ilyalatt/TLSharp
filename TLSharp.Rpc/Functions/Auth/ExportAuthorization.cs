using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ExportAuthorization : ITlFunc<T.Auth.ExportedAuthorization>, IEquatable<ExportAuthorization>, IComparable<ExportAuthorization>, IComparable
    {
        public int DcId { get; }
        
        public ExportAuthorization(
            int dcId
        ) {
            DcId = dcId;
        }
        
        
        int CmpTuple =>
            DcId;

        public bool Equals(ExportAuthorization other) => !ReferenceEquals(other, null) && CmpTuple == other.CmpTuple;
        public override bool Equals(object other) => other is ExportAuthorization x && Equals(x);
        public static bool operator ==(ExportAuthorization x, ExportAuthorization y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ExportAuthorization x, ExportAuthorization y) => !(x == y);

        public int CompareTo(ExportAuthorization other) => !ReferenceEquals(other, null) ? CmpTuple.CompareTo(other.CmpTuple) : throw new ArgumentNullException(nameof(other));
        int IComparable.CompareTo(object other) => other is ExportAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ExportAuthorization x, ExportAuthorization y) => x.CompareTo(y) <= 0;
        public static bool operator <(ExportAuthorization x, ExportAuthorization y) => x.CompareTo(y) < 0;
        public static bool operator >(ExportAuthorization x, ExportAuthorization y) => x.CompareTo(y) > 0;
        public static bool operator >=(ExportAuthorization x, ExportAuthorization y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(DcId: {DcId})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe5bfffcd);
            Write(DcId, bw, WriteInt);
        }
        
        T.Auth.ExportedAuthorization ITlFunc<T.Auth.ExportedAuthorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.ExportedAuthorization.Deserialize);
    }
}