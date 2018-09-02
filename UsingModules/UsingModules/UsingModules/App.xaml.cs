using System;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using UsingModules.Views;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UsingModules
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var navigationPage = "MainNavigationPage/MainPage";
            NavigationService.NavigateAsync($"{navigationPage}?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainNavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SampleModule.SampleModule>(InitializationMode.OnDemand);
        }
    }
}
