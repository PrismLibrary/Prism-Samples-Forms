using Prism.Events;
using Prism.Ioc;
using Prism.Logging;
using Prism.Logging.Loggly;
using PrismSample.Events;
using PrismSample.Logging;
using PrismSample.ViewModels;
using PrismSample.Views;
using Xamarin.Forms;

namespace PrismSample
{
    public partial class App
    {
        public App()
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            SetupEventListeners();
            var result = await NavigationService.NavigateAsync("NavigationPage/MainPage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<GenerateLogsPage, GenerateLogsPageViewModel>();

            containerRegistry.RegisterSingleton<LogGenerator>();

            // Set this up as the initial logger. We'll replace these later.
            containerRegistry.Register<ILogger, ConsoleLoggingService>();
            containerRegistry.Register<ILogglyOptions, LogglyOptions>();

            // TODO: Be sure to get your Loggly Consumer Token. Paste it here to avoid typing it...
            //containerRegistry.RegisterInstance<ILogglyOptions>(new LogglyOptions
            //{ 
            //    Token = "{Enter your Loggly Consumer Token Here...}"
            //});

        }

        private void SetupEventListeners()
        {
            var ea = Container.Resolve<IEventAggregator>();
            ea.GetEvent<RegisterLoggerEvent>().Subscribe(OnRegisterLogglyEvent);
            ea.GetEvent<RegisterLogglyTokenEvent>().Subscribe(OnRegisterLogglyTokenEvent);
        }

        private void OnRegisterLogglyEvent(LogglyEndpoint endpoint)
        {
            var c = Container as IContainerRegistry;
            switch(endpoint)
            {
                case LogglyEndpoint.Http:
                    c.RegisterSingleton<ILogger, LogglyHttpLogger>();
                    break;
                case LogglyEndpoint.Syslog:
                    c.RegisterSingleton<ILogger, LogglySyslogLogger>();
                    break;
            }
        }

        private void OnRegisterLogglyTokenEvent(string token)
        {
            var options = new LogglyOptions
            {
                Token = token
            };

            var c = Container as IContainerRegistry;
            c.RegisterInstance<ILogglyOptions>(options);
            NavigationService.NavigateAsync("/NavigationPage/MainPage");
        }
    }
}
