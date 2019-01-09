using System;

namespace TLSharp
{
    public class FloodException : Exception
    {
        public TimeSpan TimeToWait { get; private set; }

        internal FloodException(TimeSpan timeToWait)
            : base($"Flood prevention. Telegram now requires your program to do requests again only after {timeToWait.TotalSeconds} seconds have passed ({nameof(TimeToWait)} property)." +
                    " If you think the culprit of this problem may lie in TLSharp's implementation, open a Github issue please.")
        {
            TimeToWait = timeToWait;
        }
    }

    internal abstract class DataCenterMigrationException : Exception
    {
        internal int DC { get; private set; }

        private const string REPORT_MESSAGE =
            " See: https://github.com/sochix/TLSharp#i-get-a-xxxmigrationexception-or-a-migrate_x-error";

        protected DataCenterMigrationException(string msg, int dc) : base (msg + REPORT_MESSAGE)
        {
            DC = dc;
        }
    }

    internal class PhoneMigrationException : DataCenterMigrationException
    {
        internal PhoneMigrationException(int dc)
            : base ($"Phone number registered to a different DC: {dc}.", dc)
        {
        }
    }

    internal class FileMigrationException : DataCenterMigrationException
    {
        internal FileMigrationException(int dc)
            : base ($"File located on a different DC: {dc}.", dc)
        {
        }
    }

    internal class UserMigrationException : DataCenterMigrationException
    {
        internal UserMigrationException(int dc)
            : base($"User located on a different DC: {dc}.", dc)
        {
        }
    }

    internal class NetworkMigrationException : DataCenterMigrationException
    {
        internal NetworkMigrationException(int dc)
            : base($"Network located on a different DC: {dc}.", dc)
        {
        }
    }

    public class MissingApiConfigurationException : Exception
    {
        public const string InfoUrl = "https://github.com/sochix/TLSharp#quick-configuration";

        internal MissingApiConfigurationException(string invalidParamName) :
            base($"Your {invalidParamName} setting is missing. Adjust the configuration first, see {InfoUrl}")
        {
        }
    }

    public class InvalidPhoneCodeException : Exception
    {
        internal InvalidPhoneCodeException(string msg) : base(msg) { }
    }

    public class CloudPasswordNeededException : Exception
    {
        internal CloudPasswordNeededException(string msg) : base(msg)
        {
        }
    }
}
