using System;
using System.Collections.Generic;
using System.Text;
using Prism.Logging.Loggly;

namespace PrismSample.Logging
{
    public class LogglyOptions : ILogglyOptions
    {
        public string Token { get; set; }
        public string AppName => "Logging Demo";
        public IEnumerable<string> Tags => new[] { "Prism", "Sample" };
    }
}
