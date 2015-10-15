using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace UsingNavigationPageProvider.ViewModels
{
    class ViewBViewModel : BindableBase
    {
        INavigationService _navigationService;

        private string _title = "View B";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        public ViewBViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            //we are navigating within the NavigationPage so we set useModelNavigation to false
            _navigationService.GoBack(useModalNavigation: false);
        }
    }
}
