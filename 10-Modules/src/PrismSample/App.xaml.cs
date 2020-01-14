using System;
using Prism;
using Prism.Ioc;
using Prism.Modularity;
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

            var navigationPage = "NavigationPage/MainPage";
            var result = await NavigationService.NavigateAsync($"{navigationPage}?title=Hello%20from%20Xamarin.Forms");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<SampleModule.SampleModule>(InitializationMode.OnDemand);
        }
    }
}
