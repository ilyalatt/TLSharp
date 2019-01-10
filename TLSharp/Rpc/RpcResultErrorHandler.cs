using System;
using System.Text.RegularExpressions;
using LanguageExt;
using TLSharp.Rpc.Types;

namespace TLSharp.Rpc
{
    static class RpcResultErrorHandler
    {
        public static Exception ToException(Some<RpcError.Tag> someError)
        {
            var error = someError.Value;
            var code = error.ErrorCode;
            var msg = error.ErrorMessage;

            // TODO: get some of these messages and simplify the extraction
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