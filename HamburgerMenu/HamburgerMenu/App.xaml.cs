using Xamarin.Forms;
using DryIoc;
using Prism.DryIoc;
using HamburgerMenu.Services;
using HamburgerMenu.Views;
using Prism.Logging;
using Prism.Ioc;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HamburgerMenu
{
    public partial class App
    {
        public App()
        {
            InitializeComponent();
        }

        public static new App Current
        {
            get { return Application.Current as App; }
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync( "Navigation/Login" );
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>("Navigation");
            containerRegistry.RegisterForNavigation<MainPage>("Index");
            containerRegistry.RegisterForNavigation<LoginPage>("Login");
            containerRegistry.RegisterForNavigation<ViewA>();
            containerRegistry.RegisterForNavigation<ViewB>();
            containerRegistry.RegisterForNavigation<ViewC>();

            containerRegistry.RegisterSingleton<IAuthenticationService, AuthenticationService>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
