using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSample.Views;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand SecondPageCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            SecondPageCommand = new DelegateCommand(SecondPageAction);
        }

        private async void SecondPageAction()
        {
            await _navigationService.NavigateAsync("SecondPage");
        }

    }
}
