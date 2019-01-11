using System;
using System.IO;
using BigMath;
using LanguageExt;
using static TLSharp.Rpc.TlMarshal;
using T = TLSharp.Rpc.Types;

namespace TLSharp.Rpc.Functions.Auth
{
    public sealed class ImportBotAuthorization : ITlFunc<T.Auth.Authorization>, IEquatable<ImportBotAuthorization>, IComparable<ImportBotAuthorization>, IComparable
    {
        public int Flags { get; }
        public int ApiId { get; }
        public string ApiHash { get; }
        public string BotAuthToken { get; }
        
        public ImportBotAuthorization(
            int flags,
            int apiId,
            Some<string> apiHash,
            Some<string> botAuthToken
        ) {
            Flags = flags;
            ApiId = apiId;
            ApiHash = apiHash;
            BotAuthToken = botAuthToken;
        }
        
        
        (int, int, string, string) CmpTuple =>
            (Flags, ApiId, ApiHash, BotAuthToken);

        public bool Equals(ImportBotAuthorization other) => !ReferenceEquals(other, null) && (ReferenceEquals(this, other) || CmpTuple == other.CmpTuple);
        public override bool Equals(object other) => other is ImportBotAuthorization x && Equals(x);
        public static bool operator ==(ImportBotAuthorization x, ImportBotAuthorization y) => x?.Equals(y) ?? ReferenceEquals(y, null);
        public static bool operator !=(ImportBotAuthorization x, ImportBotAuthorization y) => !(x == y);

        public int CompareTo(ImportBotAuthorization other) => ReferenceEquals(other, null) ? throw new ArgumentNullException(nameof(other)) : ReferenceEquals(this, other) ? 0 : CmpTuple.CompareTo(other.CmpTuple);
        int IComparable.CompareTo(object other) => other is ImportBotAuthorization x ? CompareTo(x) : throw new ArgumentException("bad type", nameof(other));
        public static bool operator <=(ImportBotAuthorization x, ImportBotAuthorization y) => x.CompareTo(y) <= 0;
        public static bool operator <(ImportBotAuthorization x, ImportBotAuthorization y) => x.CompareTo(y) < 0;
        public static bool operator >(ImportBotAuthorization x, ImportBotAuthorization y) => x.CompareTo(y) > 0;
        public static bool operator >=(ImportBotAuthorization x, ImportBotAuthorization y) => x.CompareTo(y) >= 0;

        public override int GetHashCode() => CmpTuple.GetHashCode();

        public override string ToString() => $"(Flags: {Flags}, ApiId: {ApiId}, ApiHash: {ApiHash}, BotAuthToken: {BotAuthToken})";
        
        void ITlSerializable.Serialize(BinaryWriter bw)
        {
            WriteUint(bw, 0x67a3ff2c);
            Write(Flags, bw, WriteInt);
            Write(ApiId, bw, WriteInt);
            Write(ApiHash, bw, WriteString);
            Write(BotAuthToken, bw, WriteString);
        }
        
        T.Auth.Authorization ITlFunc<T.Auth.Authorization>.DeserializeResult(BinaryReader br) =>
            Read(br, T.Auth.Authorization.Deserialize);
    }
}