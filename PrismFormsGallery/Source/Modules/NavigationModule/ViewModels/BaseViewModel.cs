using Prism.Navigation;

namespace NavigationModule.ViewModels
{
    public class BaseViewModel : MvvmHelpers.BaseViewModel, INavigationAware
    {
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }
    }
}
