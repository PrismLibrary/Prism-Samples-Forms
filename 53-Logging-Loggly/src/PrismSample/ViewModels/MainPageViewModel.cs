using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Events;
using Prism.Logging.Loggly;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSample.Events;
using PrismSample.Models;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }
        private IEventAggregator _eventAggregator { get; }

        public MainPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator, ILogglyOptions options)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            HasLogglyToken = !string.IsNullOrEmpty(options.Token);
            NavigateCommand = new DelegateCommand(OnNavigateCommandExecuted)
                .ObservesCanExecute(() => HasLogglyToken);
            SaveTokenCommand = new DelegateCommand(OnSaveTokenCommandExecuted);

            InfoItems = new[]
            {
                new InfoItem
                {
                    ImageName = "PrismSample.Images.signup.png",
                    Text = "Be sure to create a free account at Loggly.com"
                },
                new InfoItem
                {
                    ImageName = "PrismSample.Images.dashboard.png",
                    Text = "You'll see your logs here once you start logging."
                },
                new InfoItem
                {
                    ImageName = "PrismSample.Images.generate-token.png",
                    Text = "Be sure to create a Consumer Token to be able to log to Loggly with either the HTTP or Syslog Logger."
                },
                new InfoItem
                {
                    ImageName = "PrismSample.Images.generated-logs.png",
                    Text = "Once you've sent some logs to loggly you will see them in the search results and be able to filter as needed."
                }
            };
        }

        public DelegateCommand NavigateCommand { get; }

        public DelegateCommand SaveTokenCommand { get; }

        public IEnumerable<InfoItem> InfoItems { get; }

        public bool HasLogglyToken { get; }

        public bool RequiresLogglyToken => !HasLogglyToken;

        private string _token;
        public string Token
        {
            get => _token;
            set => SetProperty(ref _token, value);
        }

        private string _selectedLoggerType = "Please Select";
        public string SelectedLoggerType
        {
            get => _selectedLoggerType;
            set => SetProperty(ref _selectedLoggerType, value, onChanged: SelectedLoggerChanged);
        }

        private void SelectedLoggerChanged()
        {
            switch(SelectedLoggerType)
            {
                case "Http":
                    _eventAggregator.GetEvent<RegisterLoggerEvent>().Publish(LogglyEndpoint.Http);
                    break;
                case "Syslog":
                    _eventAggregator.GetEvent<RegisterLoggerEvent>().Publish(LogglyEndpoint.Syslog);
                    break;
            }
        }

        private async void OnNavigateCommandExecuted()
        {
            var result = await _navigationService.NavigateAsync("GenerateLogsPage");
            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        private void OnSaveTokenCommandExecuted()
        {
            _eventAggregator.GetEvent<RegisterLogglyTokenEvent>().Publish(Token);
        }
    }
}
