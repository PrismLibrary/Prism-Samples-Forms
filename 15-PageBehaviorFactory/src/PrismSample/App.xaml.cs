using Prism.Behaviors;
using Prism.Ioc;
using PrismSample.Behaviors;
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

            var result = await NavigationService.NavigateAsync("TabbedPage?createTab=FirstTabPage&createTab=SecondTabPage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedPage>();
            containerRegistry.RegisterSingleton<IPageBehaviorFactory, SampleBehaviorFactory>();
            containerRegistry.RegisterForNavigation<FirstTabPage>();
            containerRegistry.RegisterForNavigation<SecondTabPage>();
        }
    }
}
