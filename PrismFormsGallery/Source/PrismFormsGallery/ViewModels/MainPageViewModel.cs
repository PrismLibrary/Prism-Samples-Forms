using Prism.Commands;
using Prism.Navigation;
using MvvmHelpers;

namespace PrismFormsGallery.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand<string> AreaSelected { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            Title = "Prism.Forms";
            _navigationService = navigationService;

            AreaSelected = new DelegateCommand<string>(OnAreaSelected);
        }

        private void OnAreaSelected(string area)
        {
            switch (area)
            {
                case "Commanding":
                    _navigationService.NavigateAsync("LoginPage");
                    break;
                case "Navigation":
                    _navigationService.NavigateAsync("NavMainPage");
                    break;
                case "EventAggregator":
                    _navigationService.NavigateAsync("EventPage");
                    break;
                case "DialogService":
                    _navigationService.NavigateAsync("RegistrationView");
                    break;
            }
        }
    }
}
