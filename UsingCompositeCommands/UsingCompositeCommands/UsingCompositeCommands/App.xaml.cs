using Microsoft.Practices.Unity;
using Prism.Unity;
using UsingCompositeCommands.ViewModels;
using UsingCompositeCommands.Views;

namespace UsingCompositeCommands
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<Xamarin.Forms.NavigationPage>();
            Container.RegisterTypeForNavigation<TabA, TabViewModel>();
            Container.RegisterTypeForNavigation<TabB, TabViewModel>();
            Container.RegisterTypeForNavigation<TabC, TabViewModel>();

            Container.RegisterType<IApplicationCommands, ApplicationCommands>(new ContainerControlledLifetimeManager());
        }
    }
}
