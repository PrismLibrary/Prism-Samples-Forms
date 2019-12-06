using System;
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

            var result = await NavigationService.NavigateAsync(nameof(HomePage) + "/" + nameof(NavigationPage) + "/" + nameof(MainPage));

            if (!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<TabsPage, TabsPageViewModel>();
            containerRegistry.RegisterForNavigation<TabAPage, TabAPageViewModel>();
            containerRegistry.RegisterForNavigation<TabBPage, TabBPageViewModel>();
        }
    }
}
