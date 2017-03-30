using Xamarin.Forms;
using DryIoc;
using Prism.DryIoc;
using HamburgerMenu.Services;
using HamburgerMenu.Views;
using Prism.Logging;

namespace HamburgerMenu
{
    public partial class App : PrismApplication
    {
        public App()
        {
            InitializeComponent();
        }

        public static new App Current
        {
            get { return Application.Current as App; }
        }

        public new ILoggerFacade Logger
        {
            get { return base.Logger; }
        }

        protected override void OnInitialized()
        {
            NavigationService.NavigateAsync( "Navigation/Login" );
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>( "Navigation" );
            Container.RegisterTypeForNavigation<MainPage>( "Index" );
            Container.RegisterTypeForNavigation<LoginPage>( "Login" );
            Container.RegisterTypeForNavigation<ViewA>();
            Container.RegisterTypeForNavigation<ViewB>();
            Container.RegisterTypeForNavigation<ViewC>();

            Container.Register<IAuthenticationService, AuthenticationService>( Reuse.Singleton );
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
