using Prism;
using Prism.AppModel;
using Prism.Ioc;
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

            var result = await NavigationService.NavigateAsync("NavigationPage/MainMenuPage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainMenuPage, MainMenuPageViewModel>();

            // Basic Register View
            containerRegistry.RegisterForNavigation<BasicPage>();

            // Register View + ViewModel
            containerRegistry.RegisterForNavigation<FullRegistratedPage, FullRegistratedPageViewModel>();

            // Register View with Custom Name
            containerRegistry.RegisterForNavigation<AnotherPage>(name: "CustomNamePage");

            // Register View using Platform Specific Overrides
            containerRegistry.RegisterForNavigationOnPlatform<OtherPlatformPage, PlatformSharedViewModel>(name: "PlatformSpecificPage",
                platforms: new IPlatform[] 
                { 
                    new Platform<DroidPage>(RuntimePlatform.Android), 
                    new Platform<IOSPage>(RuntimePlatform.iOS), 
                    new Platform<UWPPage>(RuntimePlatform.UWP) 
                });

            // Register View using Idiom Specific Overrides
            containerRegistry.RegisterForNavigationOnIdiom<OtherIdiomPage, IdiomSharedViewModel>(name: "IdiomSpecificPage",
                phoneView: typeof(PhonePage),
                tabletView: typeof(TabletPage));
        }
    }
}
