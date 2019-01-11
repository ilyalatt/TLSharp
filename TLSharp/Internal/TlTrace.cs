using System;

namespace TLSharp.Internal
{
    // so ugly
    public static class TlTrace
    {
        public static bool IsEnabled { get; set; }

        public static void Trace(string msg)
        {
            if (!IsEnabled) return;
            Console.WriteLine(msg);
        }
    }
}
