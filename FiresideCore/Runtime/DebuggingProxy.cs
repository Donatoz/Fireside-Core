using System;

namespace FiresideCore.Runtime
{
    /// <summary>
    /// Proxy for debugging messages (for example, in Unity).
    /// </summary>
    public static class DebuggingProxy
    {
        public static Action<string> LoggingContext;

        public static void Log(string msg)
        {
            LoggingContext?.Invoke(msg);
        }
    }
}