using System;
using Prism.Ioc;
using PrismSample.ViewModels;
using PrismSample.Views;
using Xamarin.Forms;
using PrismSample.Services;

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
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.Register<IDataProvider, MockDataProvider>();

            containerRegistry.RegisterForNavigation<SimpleExamplePage, SimpleExamplePageViewModel>();
            containerRegistry.RegisterForNavigation<EventArgsConverterExamplePage, EventArgsConverterExamplePageViewModel>();
            containerRegistry.RegisterForNavigation<EventArgsParameterExamplePage, EventArgsExamplePageViewModel>();
        }
    }
}
