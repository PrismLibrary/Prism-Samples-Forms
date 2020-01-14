using System;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using PrismSample.Views;
using Xamarin.Forms;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private INavigationService _navigationService { get; }
        public DelegateCommand RuntimeTabsCommand { get; }
        public DelegateCommand TabBCommand { get; }

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            TabBCommand = new DelegateCommand(TabBAction);
            RuntimeTabsCommand = new DelegateCommand(RuntimeTabsAction);
        }

        private async void RuntimeTabsAction()
        {
            await _navigationService.NavigateAsync("TabbedPage" +
                                             $"?{KnownNavigationParameters.CreateTab}=TabCPage" +
                                             $"&{KnownNavigationParameters.CreateTab}=TabBPage" +
                                             $"&{KnownNavigationParameters.CreateTab}=TabAPage");
        }

        private async void TabBAction()
        {
            var p = new NavigationParameters();
            p.Add("ActiveCount", 0);

            await _navigationService.NavigateAsync("TabsPage?selectedTab=TabBPage", p);

        }
    }
}
