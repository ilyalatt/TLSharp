using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Account
{
    public sealed class AcceptAuthorization : ITlFunc<bool>, IEquatable<AcceptAuthorization>, IComparable<AcceptAuthorization>, IComparable
    {
        public int BotId { get; }
        public string Scope { get; }
        public string PublicKey { get; }
        public Arr<T.SecureValueHash> ValueHashes { get; }
        public T.SecureCredentialsEncrypted Credentials { get; }
        
        public AcceptAuthorization(
            int botId,
            Some<string> scope,
            Some<string> publicKey,
            Some<Arr<T.SecureValueHash>> valueHashes,
            Some<T.SecureCredentialsEncrypted> credentials
        ) {
            BotId = botId;
            Scope = scope;
            PublicKey = publicKey;
            ValueHashes = valueHashes;
            Credentials = credentials;
        }
        
        
        (int, string, string, Arr<T.SecureValueHash>, T.SecureCredentialsEncrypted) CmpTuple =>
            (BotId, Scope, PublicKey, ValueHashes, Credentials);

        public bool Equals(AcceptAuthorization other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is AcceptAuthorization x && Equals(x);
        public static bool operator ==(AcceptAuthorization x, AcceptAuthorization y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(AcceptAuthorization x, AcceptAuthorization y) => !(x == y);

        public int CompareTo(AcceptAuthorization other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is AcceptAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(AcceptAuthorization x, AcceptAuthorization y) => x.CompareTo(y) <= 0;
        public static bool operator <(AcceptAuthorization x, AcceptAuthorization y) => x.CompareTo(y) < 0;
        public static bool operator >(AcceptAuthorization x, AcceptAuthorization y) => x.CompareTo(y) > 0;
        public static bool operator >=(AcceptAuthorization x, AcceptAuthorization y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(BotId: {BotId}, Scope: {Scope}, PublicKey: {PublicKey}, ValueHashes: {ValueHashes}, Credentials: {Credentials})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0xe7027c94);
            Write(BotId, bw, WriteInt);
            Write(Scope, bw, WriteString);
            Write(PublicKey, bw, WriteString);
            Write(ValueHashes, bw, WriteVector<T.SecureValueHash>(WriteSerializable));
            Write(Credentials, bw, WriteSerializable);
        }
        
        bool ITlFunc<bool>.DeserializeResult(BinaryReader br) =>
            Read(br, ReadBool);
    }
}