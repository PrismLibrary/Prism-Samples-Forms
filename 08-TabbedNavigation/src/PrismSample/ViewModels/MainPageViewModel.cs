using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSample.Views;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly INavigationService _navigationService;
        public DelegateCommand DynamicTabsCommand { get; set; }
        public DelegateCommand TabBCommand { get; set; }
        public DelegateCommand TabCCommand { get; set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            TabBCommand = new DelegateCommand(TabBAction);
            TabCCommand = new DelegateCommand(TabCAction);
            DynamicTabsCommand = new DelegateCommand(DynamicTabsAction);
        }

        private async void DynamicTabsAction()
        {
            // Notice that with the DynamicTabsPage.xaml page we haven't specified any tabs.
            // They are created on the fly when we navigate there
            await _navigationService.NavigateAsync(nameof(DynamicTabsPage) +
                                             $"?{KnownNavigationParameters.CreateTab}=" + nameof(TabCPage) +
                                             $"&{KnownNavigationParameters.CreateTab}=" + nameof(TabBPage) +
                                             $"&{KnownNavigationParameters.CreateTab}=" + nameof(TabAPage));
        }

        private async void TabBAction()
        {
            await _navigationService.NavigateAsync(nameof(TabsPage) + $"?{KnownNavigationParameters.SelectedTab}=" + nameof(TabBPage));
        }

        private async void TabCAction()
        {
            await _navigationService.NavigateAsync(nameof(TabsPage) + "?selectedTab=" + nameof(TabCPage));
        }

    }
}
