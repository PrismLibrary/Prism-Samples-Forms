using System;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;

namespace NavigationModule.ViewModels
{
    public class NavMainPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public NavMainPageViewModel(INavigationService navigationService)
        {
            Title = "Navigation Menu";
            _navigationService = navigationService;

            NavigateCommand = new DelegateCommand<string>(async (s) => await OnNavigateTapped(s));
        }

        public DelegateCommand<string> NavigateCommand { get; set; }

        private async Task OnNavigateTapped(string page)
        {
            switch (page)
            {
                case "Simple":
                    INavigationResult result = await _navigationService.NavigateAsync("ViewA");
                    if(!result.Success) {
                        Console.WriteLine($"Navigation failed {result.Exception.Message}");
                    }
                    break;
                case "Params":
                    await _navigationService.NavigateAsync("ViewA", new NavigationParameters { { "name", "Hussain" } });
                    break;
                case "ParamsBoth":
                    await _navigationService.NavigateAsync("ViewA", new NavigationParameters("?title=Hussain A") { { "name", "Hussain" } });
                    break;
                case "AutoInit":
                    await _navigationService.NavigateAsync("ViewB?name=Hussain");
                    break;
                case "Deep":
                    await _navigationService.NavigateAsync("ViewA/ViewB/ViewC");
                    break;
                case "DeepParams":
                    await _navigationService.NavigateAsync("ViewA?name=HussainA/ViewB?name=HussainB/ViewC");
                    break;
                case "Deeper":
                    await _navigationService.NavigateAsync("ViewA/ViewB/ViewC?selectedTab=TabB");
                    break;
                case "DeeperParams":
                    // Any parameter passed to a TabbedPage will be propagated to all children pages (tabs).
                    await _navigationService.NavigateAsync("ViewA?name=HussainA/ViewB?name=HussainB/ViewC?selectedTab=TabB&name=Hussain&message=folks");
                    break;
                case "Remove":
                    await _navigationService.NavigateAsync("../ViewA/ViewB/ViewC");
                    break;
            }
        }
    }
}
