using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class GetAuthorizationForm : ITlFunc<T.Account.AuthorizationForm>, IEquatable<GetAuthorizationForm>, IComparable<GetAuthorizationForm>, IComparable
    {
        public int BotId { get; }
        public string Scope { get; }
        public string PublicKey { get; }
        
        public GetAuthorizationForm(
            int botId,
            Some<string> scope,
            Some<string> publicKey
        ) {
            BotId = botId;
            Scope = scope;
            PublicKey = publicKey;
        }
        
        
        (int, string, string) CmpTuple =>
            (BotId, Scope, PublicKey);

        public bool Equals(GetAuthorizationForm other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is GetAuthorizationForm x && Equals(x);
        public static bool operator ==(GetAuthorizationForm x, GetAuthorizationForm y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(GetAuthorizationForm x, GetAuthorizationForm y) => !(x == y);

        public int CompareTo(GetAuthorizationForm other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is GetAuthorizationForm x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(GetAuthorizationForm x, GetAuthorizationForm y) => x.CompareTo(y) <= 0;
        public static bool operator <(GetAuthorizationForm x, GetAuthorizationForm y) => x.CompareTo(y) < 0;
        public static bool operator >(GetAuthorizationForm x, GetAuthorizationForm y) => x.CompareTo(y) > 0;
        public static bool operator >=(GetAuthorizationForm x, GetAuthorizationForm y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(BotId: {BotId}, Scope: {Scope}, PublicKey: {PublicKey})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xb86ba8e1);
            Write(BotId, bw, WriteInt);
            Write(Scope, bw, WriteString);
            Write(PublicKey, bw, WriteString);
        }
        
        T.Account.AuthorizationForm ITlFunc<T.Account.AuthorizationForm>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Account.AuthorizationForm.Deserialize);
    }
}