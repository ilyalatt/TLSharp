using System;
using LanguageExt;
using TLSharp.Rpc;
using static LanguageExt.Prelude;

namespace TLSharp
{
    public sealed class TlFloodException : TlException
    {
        public TimeSpan Delay { get; }

        internal TlFloodException(TimeSpan delay) : base(
            $"Flood prevention. Wait {delay.TotalMinutes} minutes.",
            None
        ) => Delay = delay;
    }

    enum DcMigrationReason
    {
        Phone,
        File,
        User,
        Network
    }

    class TlInternalException : TlException
    {
        internal TlInternalException(
            Some<string> additionalMessage,
            Option<Exception> innerException
        ) : base(
            "Internal exception. Should be handled by the library." + Environment.NewLine + additionalMessage,
            innerException
        ) { }
    }

    class TlFailedAssertionException : TlInternalException
    {
        public TlFailedAssertionException(Some<string> msg) : base($"Assert failed. {msg}", None) { }
    }

    sealed class TlDataCenterMigrationException : TlInternalException
    {
        public DcMigrationReason Reason { get; }
        public int Dc { get; }

        internal TlDataCenterMigrationException(DcMigrationReason reason, int dc) : base("Data center migration.", None)
        {
            Reason = reason;
            Dc = dc;
        }
    }

    sealed class TlBadSalt : TlInternalException
    {
        public TlBadSalt() : base("bad_server_salt is received.", None) { }
    }

    public sealed class TlInvalidPhoneCodeException : TlException
    {
        internal TlInvalidPhoneCodeException() : base(
            "The numeric code used to authenticate does not match the numeric code sent by SMS/Telegram.",
            None
        ) { }
    }

    public sealed class TlPasswordNeededException : TlException
    {
        internal TlPasswordNeededException() : base("This account has a password.", None) { }
    }
}
