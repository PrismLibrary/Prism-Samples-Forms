using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace UsingNavigationPageProvider.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        INavigationService _navigationService;

        private string _title = "View A";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NavigateCommand { get; set; }

        public ViewAViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            //We are using the NavigationPageProviderAttribute on ViewA to wrap it in a NavigationPage
            //so we set useModelNavigation to false so that we can navigate within the NavigationPage
            _navigationService.Navigate("ViewB", useModalNavigation: false);
        }
    }
}
