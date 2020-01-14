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

            var result = await NavigationService.NavigateAsync("NavigationPage/MainPage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterForNavigation<Xamarin.Forms.NavigationPage>();
            containerRegistry.RegisterForNavigation<TabA, TabViewModel>();
            containerRegistry.RegisterForNavigation<TabB, TabViewModel>();
            containerRegistry.RegisterForNavigation<TabC, TabViewModel>();

            containerRegistry.RegisterSingleton<IApplicationCommands, ApplicationCommands>();
        }
    }
}
