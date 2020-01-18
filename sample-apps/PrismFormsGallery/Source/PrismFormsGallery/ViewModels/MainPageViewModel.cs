using Prism.Commands;
using Prism.Navigation;
using MvvmHelpers;
using Prism.Modularity;

namespace PrismFormsGallery.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private INavigationService _navigationService { get; }

        public DelegateCommand<string> AreaSelected { get; }

        public MainPageViewModel(INavigationService navigationService, IModuleCatalog moduleCatalog)
        {
            Title = "Prism.Forms";
            _navigationService = navigationService;

            AreaSelected = new DelegateCommand<string>(OnAreaSelected, area => moduleCatalog.IsInitialized($"{area}Module"));
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
                case "Events":
                    _navigationService.NavigateAsync("EventPage");
                    break;
                case "Dialog":
                    _navigationService.NavigateAsync("RegistrationView");
                    break;
            }
        }
    }
}
