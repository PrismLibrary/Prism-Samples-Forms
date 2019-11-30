using System;
using Prism.Behaviors;
using Prism.Common;
using Prism.Ioc;
using Prism.Logging;
using Prism.Plugin.Popups;
using PrismSample.ViewModels;
using PrismSample.Views;
using Rg.Plugins.Popup.Contracts;
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
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterPopupDialogService();
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<SamplePopup, SamplePopupViewModel>();
            containerRegistry.RegisterDialog<SampleAlert, SampleAlertViewModel>();
        }
    }
}
