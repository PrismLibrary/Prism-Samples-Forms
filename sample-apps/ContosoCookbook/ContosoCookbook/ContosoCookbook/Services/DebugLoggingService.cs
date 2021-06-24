using System;
using System.Collections.Generic;
using Prism.Logging;
using System.Diagnostics;

namespace ContosoCookbook.Services
{
    public class DebugLoggingService : ILogger
    {
        public void TrackEvent(string name, IDictionary<string, string> properties)
        {
            LogInternal(name, properties);
        }

        public void Report(Exception ex, IDictionary<string, string> properties)
        {
            LogInternal(ex, properties);
        }

        public void Log(string message, IDictionary<string, string> properties)
        {
            LogInternal(message, properties);
        }

        private void LogInternal(object message, IDictionary<string, string> properties)
        {
            Debug.WriteLine(message);

            foreach (var prop in properties ?? new Dictionary<string, string>())
            {
                Debug.WriteLine($"    {prop.Key}: {prop.Value}");
            }
        }
    }
}
