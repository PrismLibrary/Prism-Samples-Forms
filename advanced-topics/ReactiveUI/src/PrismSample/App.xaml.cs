using System;
using Prism.Ioc;
using PrismSample.Converters;
using PrismSample.Services;
using PrismSample.ViewModels;
using PrismSample.Views;
using ReactiveUI;
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

            var result = await NavigationService.NavigateAsync("LoginPage");

            if(!result.Success)
            {
                System.Diagnostics.Debugger.Break();
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register Navigation
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginPage, LoginViewModel>();
            containerRegistry.RegisterForNavigation<NuGetPackageListPage, NuGetPackageListViewModel>();
            containerRegistry.RegisterForNavigation<NuGetPackageDetailPage, NuGetPackageDetailViewModel>();

            // Register Services
            containerRegistry.RegisterSingleton<INuGetPackageService, NuGetPackageService>();
        }
    }
}
