using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Prism.Logging;
using Prism.Services;

namespace PrismSample.Logging
{
    public class LogGenerator
    {
        private ILogger _logger { get; }
        private IDeviceService _deviceService { get; }

        public LogGenerator(ILogger logger, IDeviceService deviceService)
        {
            _logger = logger;
            _deviceService = deviceService;

            Messages = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Messages { get; }

        int logCount;
        public void GenerateLogs()
        {
            logCount = 0;
            Messages.Clear();
            _deviceService.StartTimer(TimeSpan.FromSeconds(1.5), GenerateLog);
        }

        private bool GenerateLog()
        {
            bool trackEvent = false;
            string message = null;
            if (logCount == 0)
            {
                message = "Starting Test Log Run";
                trackEvent = true;
            }
            else if (logCount % 3 == 1)
            {
                GracefulException();
            }
            else if(logCount % 2 == 0)
            {
                message = "ViewA";
                trackEvent = true;
            }
            else
            {
                message = "User did something fun...";
            }

            if(!string.IsNullOrEmpty(message))
            {
                if(trackEvent)
                {
                    _logger.TrackEvent(message, new Dictionary<string, string>
                    {
                        { "loggerType", _logger.GetType().Name }
                    });
                }
                else
                {
                    _logger.Info(message, new Dictionary<string, string>
                    {
                        { "loggerType", _logger.GetType().Name }
                    });
                }
                Messages.Add(message);
            }

            return logCount++ < 14;
        }

        private void GracefulException()
        {
            try
            {
                var foo = new FooService();
                foo.DangerousApi();
            }
            catch (Exception ex)
            {
                _logger.Report(ex, new Dictionary<string, string>
                {
                    { "loggerType", _logger.GetType().Name }
                });
                Messages.Add($"{ex.GetType().Name}: {ex.Message}");
            }
        }

        private class FooService
        {
            public void DangerousApi()
            {
                throw new Exception("Whoops this Dangerous Api did something terrible");
            }
        }
    }
}
