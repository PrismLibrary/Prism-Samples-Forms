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

            var result = await NavigationService.NavigateAsync("TabbedPage?createTab=NonAsyncExamplePage&createTab=AsyncExamplePage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<TabbedPage>();
            containerRegistry.RegisterForNavigation<NonAsyncExamplePage, NonAsyncExamplePageViewModel>();
            containerRegistry.RegisterForNavigation<AsyncExamplePage, AsyncExamplePageViewModel>();
            containerRegistry.RegisterForNavigation<ResultPage, ResultPageViewModel>();
        }
    }
}
