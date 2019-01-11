using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class RequestPasswordRecovery : ITlFunc<T.Auth.PasswordRecovery>, IEquatable<RequestPasswordRecovery>, IComparable<RequestPasswordRecovery>, IComparable
    {

        
        public RequestPasswordRecovery(

        ) {

        }
        
        
        Unit CmpTuple =>
            Unit.Default;

        public bool Equals(RequestPasswordRecovery other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is RequestPasswordRecovery x && Equals(x);
        public static bool operator ==(RequestPasswordRecovery x, RequestPasswordRecovery y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(RequestPasswordRecovery x, RequestPasswordRecovery y) => !(x == y);

        public int CompareTo(RequestPasswordRecovery other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is RequestPasswordRecovery x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(RequestPasswordRecovery x, RequestPasswordRecovery y) => x.CompareTo(y) <= 0;
        public static bool operator <(RequestPasswordRecovery x, RequestPasswordRecovery y) => x.CompareTo(y) < 0;
        public static bool operator >(RequestPasswordRecovery x, RequestPasswordRecovery y) => x.CompareTo(y) > 0;
        public static bool operator >=(RequestPasswordRecovery x, RequestPasswordRecovery y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"()";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xd897bc66);

        }
        
        T.Auth.PasswordRecovery ITlFunc<T.Auth.PasswordRecovery>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.PasswordRecovery.Deserialize);
    }
}