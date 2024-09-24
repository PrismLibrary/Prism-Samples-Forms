using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            
            // Creating a shortcut for the CreateTab constant
            const string selectedTab = KnownNavigationParameters.SelectedTab;

            //Navigating to and selecting the TabA with the created parameter
            _navigationService.NavigateAsync("TabsPage?" + $"?{selectedTab}=TabAPage");
        }
    }
}
