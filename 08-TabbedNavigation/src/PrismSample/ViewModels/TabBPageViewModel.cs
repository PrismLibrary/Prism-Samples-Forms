using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class TabBPageViewModel : TabPageViewModelBase
    {
        public TabBPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "B";
        }
    }
}
