using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public abstract class NavigationViewModelBase : ViewModelBase, INavigationAware
    {
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
    }
}