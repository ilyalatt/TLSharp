using System;
using System.Text.RegularExpressions;
using LanguageExt;
using TLSharp.Rpc.Types;
using static LanguageExt.Prelude;

namespace TLSharp.Rpc
{
    class TlRpcResultUnknownError : TlInternalException
    {
        public int Code { get; }
        public string Message { get; }

        public TlRpcResultUnknownError(int code, Some<string> message) : base(
            $"Unknown rpc error ({code}, '{message}').",
            None
        ) {
            Code = code;
            Message = message;
        }
    }

    static class RpcResultErrorHandler
    {
        public static TlException ToException(RpcError.Tag error)
        {
            var code = error.ErrorCode;
            var msg = error.ErrorMessage;

            // TODO: get some of these messages and simplify the extraction
            // I guess we can get a last index of '_' and parse a number after that
            int ExtractInt() =>
                Regex.Match(msg, @"\d+").Value.Apply(int.Parse);

            TimeSpan ExtractTimeSpan() =>
                ExtractInt().Apply(x => (double) x).Apply(TimeSpan.FromSeconds);

            TlDataCenterMigrationException ExtractDcMigration(DcMigrationReason reason) =>
                new TlDataCenterMigrationException(reason, ExtractInt());

            if (msg.StartsWith("FLOOD_WAIT_")) return new TlFloodException(ExtractTimeSpan());

            if (msg.StartsWith("PHONE_MIGRATE_")) return ExtractDcMigration(DcMigrationReason.Phone);
            if (msg.StartsWith("FILE_MIGRATE_")) return ExtractDcMigration(DcMigrationReason.File);
            if (msg.StartsWith("USER_MIGRATE_")) return ExtractDcMigration(DcMigrationReason.User);
            if (msg.StartsWith("NETWORK_MIGRATE_")) return ExtractDcMigration(DcMigrationReason.Network);

            if (msg == "PHONE_CODE_INVALID") return new TlInvalidPhoneCodeException();
            if (msg == "SESSION_PASSWORD_NEEDED") return new TlPasswordNeededException();

            return new TlRpcResultUnknownError(code, msg);
        }
    }
}
