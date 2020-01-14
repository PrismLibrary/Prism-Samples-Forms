using System.Collections.Generic;
using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using PrismSample.Logging;

namespace PrismSample.ViewModels
{
    public class GenerateLogsPageViewModel : BindableBase
    {
        private LogGenerator _generator { get; }

        public GenerateLogsPageViewModel(LogGenerator generator, ILogger logger)
        {
            _generator = generator;

            LoggerType = logger.GetType().Name;
            GenerateLogs = new DelegateCommand(OnGenerateLogsExecuted);
        }

        public string LoggerType { get; }

        public DelegateCommand GenerateLogs { get; }

        public IEnumerable<string> Logs => _generator.Messages;

        private void OnGenerateLogsExecuted()
        {
            _generator.GenerateLogs();
        }
    }
}
