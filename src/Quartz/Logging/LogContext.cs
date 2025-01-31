using Microsoft.Extensions.Logging;

using Quartz.Simpl;

namespace Quartz.Logging
{
    public static class LogContext
    {
        /// <summary>
        /// Sets the current log provider based on logger factory.
        /// </summary>
        /// <param name="loggerFactory">The logger factory.</param>
        public static void SetCurrentLogProvider(ILoggerFactory loggerFactory)
        {
            LogProvider.SetCurrentLogProvider(new MicrosoftLoggingProvider(loggerFactory));
        }

#if DIAGNOSTICS_SOURCE
        internal static class Cached
        {
            internal static readonly System.Lazy<System.Diagnostics.DiagnosticListener> Default =
                new(() => new System.Diagnostics.DiagnosticListener(DiagnosticHeaders.DefaultListenerName));
        }
#endif
    }
}