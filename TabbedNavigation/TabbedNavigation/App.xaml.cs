using Prism.DryIoc;
using TabbedNavigation.Views;
using Xamarin.Forms;

namespace TabbedNavigation
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage?title=Hello%20from%20Xamarin.Forms");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage>();
            Container.RegisterTypeForNavigation<NavigatingAwareTabbedPage>();
            Container.RegisterTypeForNavigation<EventInitializingTabbedPage>();
            Container.RegisterTypeForNavigation<DynamicTabbedPage>();
            Container.RegisterTypeForNavigation<ViewA>();
            Container.RegisterTypeForNavigation<ViewB>();
            Container.RegisterTypeForNavigation<ViewC>();
        }
    }
}

