using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace UsingNavigationPageProvider.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        INavigationService _navigationService;

        private string _title = "Main Page";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }
        
        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            _navigationService.Navigate("ViewA");
        }
    }
}
