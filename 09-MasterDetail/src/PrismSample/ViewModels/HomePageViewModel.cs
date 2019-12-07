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
        public DelegateCommand TabbedPageCommand { get; }
        public DelegateCommand MainPageCommand { get; }

        public HomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MainPageCommand = new DelegateCommand(MainPageAction);
            TabbedPageCommand = new DelegateCommand(TabbedPageAction);
        }

        private async void TabbedPageAction()
        {
            await _navigationService.NavigateAsync("/HomePage/NavigationPage/TabsPage");
        }

        private async void MainPageAction()
        {
            await _navigationService.NavigateAsync("/HomePage/NavigationPage/MainPage");
        }

    }
}
