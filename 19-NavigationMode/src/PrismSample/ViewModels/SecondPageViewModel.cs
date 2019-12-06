using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using PrismSample.Views;

namespace PrismSample.ViewModels
{
    public class SecondPageViewModel : BindableBase, INavigatedAware
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand ThirdPageCommand { get; set; }

        private string _navigationMode;
        public string NavigationMode
        {
            get { return _navigationMode; }
            set { SetProperty(ref _navigationMode, value); }
        }

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { SetProperty(ref _isVisible, value); }
        }

        public SecondPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ThirdPageCommand = new DelegateCommand(ThirdPageAction);
        }


        private async void ThirdPageAction()
        {
            await _navigationService.NavigateAsync(nameof(ThirdPage));
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            NavigationMode navigationMode = parameters.GetNavigationMode();

            NavigationMode = navigationMode.ToString();

            IsVisible = navigationMode == Prism.Navigation.NavigationMode.Back;
        }
    }
}
