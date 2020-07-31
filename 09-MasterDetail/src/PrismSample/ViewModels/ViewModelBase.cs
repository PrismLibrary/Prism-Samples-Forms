using Prism.Navigation;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace PrismSample.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject, IInitialize, INavigationAware, IDestructible
    {
        protected INavigationService NavigationService { get; private set; }

        [Reactive]
        public bool IsBusy { get; set; }

        [Reactive]
        public string Title { get; protected set; }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        public virtual void Initialize(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void Destroy()
        {

        }
    }
}
