using Prism;
using Prism.Ioc;
using UsingCompositeCommands.ViewModels;
using UsingCompositeCommands.Views;

namespace UsingCompositeCommands
{
    public partial class App
    {
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Xamarin.Forms.NavigationPage>();
            containerRegistry.RegisterForNavigation<TabA, TabViewModel>();
            containerRegistry.RegisterForNavigation<TabB, TabViewModel>();
            containerRegistry.RegisterForNavigation<TabC, TabViewModel>();

            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }
    }
}
