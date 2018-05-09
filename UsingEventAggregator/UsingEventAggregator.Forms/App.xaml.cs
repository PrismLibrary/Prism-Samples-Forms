using Prism;
using Prism.Ioc;
using Prism.Unity;
using UsingEventAggregator.Views;

namespace UsingEventAggregator
{
    public partial class App : PrismApplication
    {
        public App (IPlatformInitializer initializer = null) : base (initializer) { }

        protected override void OnInitialized ()
        {
            InitializeComponent ();
            NavigationService.NavigateAsync (nameof(MainPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<DataEntryPage>();
        }
    }
}

