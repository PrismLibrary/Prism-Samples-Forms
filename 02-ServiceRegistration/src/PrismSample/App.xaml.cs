using System;
using Prism.Ioc;
using PrismSample.Services;
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

            var result = await NavigationService.NavigateAsync("MainPage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewAPage, ViewAPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewBPage, ViewBPageViewModel>();

            containerRegistry.RegisterSingleton<IExampleAlphaService, ExampleAlphaService>();
            containerRegistry.Register<IExampleBetaService, ExampleBetaService>();
        }
    }
}
