using Prism.Commands;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class MainMenuPageViewModel
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand GoToBasicPageCommand { get; private set; }
        public DelegateCommand GoToIdiomSpecificPageCommand { get; private set; }
        public DelegateCommand GoToFullRegistratedPageCommand { get; private set; }
        public DelegateCommand GoToPlatformSpecificPageCommand { get; private set; }
        public DelegateCommand GoToCustomNameRegisteredPageCommand { get; private set; }

        public MainMenuPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            GoToBasicPageCommand = new DelegateCommand(GoToBasicPage);
            GoToIdiomSpecificPageCommand = new DelegateCommand(GoToIdiomSpecificPage);
            GoToFullRegistratedPageCommand = new DelegateCommand(GoToFullRegistratedPage);
            GoToPlatformSpecificPageCommand = new DelegateCommand(GoToPlatformSpecificPage);
            GoToCustomNameRegisteredPageCommand = new DelegateCommand(GoToCustomNameRegisteredPage);
        }
        
        private void GoToBasicPage()
        {
            _navigationService.NavigateAsync("BasicPage");
        }

        private void GoToCustomNameRegisteredPage()
        {
            _navigationService.NavigateAsync("CustomNamePage");
        }
        
        private void GoToIdiomSpecificPage()
        {
            _navigationService.NavigateAsync("IdiomSpecificPage");
        }
        
        private void GoToFullRegistratedPage()
        {
            _navigationService.NavigateAsync("FullRegistratedPage");
        }

        private void GoToPlatformSpecificPage()
        {
            _navigationService.NavigateAsync("PlatformSpecificPage");
        }
    }
}
