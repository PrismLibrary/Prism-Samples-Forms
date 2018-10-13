using Prism;
using Prism.Ioc;
using Prism.Modularity;
using UsingModules.ViewModels;
using UsingModules.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace UsingModules
{
    public partial class App
    {
        public App()
            : this(null)
        {
        }

        public App(IPlatformInitializer initializer) 
            : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            var navigationPage = "MainNavigationPage/MainPage";
            NavigationService.NavigateAsync($"{navigationPage}?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("MainNavigationPage");
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SampleModule.SampleModule>(InitializationMode.OnDemand);
        }
    }
}
