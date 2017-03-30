using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace HamburgerMenu.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware
    {
        protected INavigationService _navigationService { get; }

        public BaseViewModel( INavigationService navigationService )
        {
            _navigationService = navigationService;
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty( ref _title, value ); }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty( ref _isBusy, value, () => RaisePropertyChanged( nameof( IsNotBusy ) ) ); }
        }

        public bool IsNotBusy
        {
            get { return !IsBusy; }
        }

        public virtual void OnNavigatedFrom( NavigationParameters parameters )
        {
        }

        public virtual void OnNavigatedTo( NavigationParameters parameters )
        {
        }

        public virtual void OnNavigatingTo( NavigationParameters parameters )
        {
        }
    }
}
