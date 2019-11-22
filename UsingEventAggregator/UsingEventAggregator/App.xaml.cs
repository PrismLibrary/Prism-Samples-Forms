using Prism;
using Prism.Ioc;
using Prism.Unity;
using UsingEventAggregator.Navigation;
using UsingEventAggregator.ViewModels;
using UsingEventAggregator.Views;

namespace UsingEventAggregator
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base (initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync(Navigate.Start);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<DataEntryPage, DataEntryPageViewModel>();
        }
    }
}

