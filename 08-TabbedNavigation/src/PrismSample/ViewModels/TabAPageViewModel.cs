using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class TabAPageViewModel : TabPageViewModelBase
    {
        public TabAPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "A";
        }
    }
}
