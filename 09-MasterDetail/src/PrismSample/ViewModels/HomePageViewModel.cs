using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using PrismSample.Views;
using Xamarin.Forms;

namespace PrismSample.ViewModels
{
    public class HomePageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand TabbedPageCommand { get; set; }
        public DelegateCommand MainPageCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MainPageCommand = new DelegateCommand(MainPageAction);
            TabbedPageCommand = new DelegateCommand(TabbedPageAction);
        }

        private async void TabbedPageAction()
        {
            await _navigationService.NavigateAsync("/" + nameof(HomePage) + "/" + nameof(NavigationPage) + "/" + nameof(TabsPage));
        }

        private async void MainPageAction()
        {
            await _navigationService.NavigateAsync("/" + nameof(HomePage) + "/" + nameof(NavigationPage) + "/" + nameof(MainPage));
        }

    }
}
