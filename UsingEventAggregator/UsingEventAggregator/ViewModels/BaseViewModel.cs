using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace UsingEventAggregator
{
    public class BaseViewModel : BindableBase, INavigationAware, IDisposable
    {

        private string _title;
        public string Title {
        	get { return _title; }
        	set { SetProperty (ref _title, value); }
        }

        public virtual void OnNavigatedFrom (NavigationParameters parameters) { }

        public virtual void OnNavigatedTo (NavigationParameters parameters) { }

        public virtual void OnNavigatingTo (NavigationParameters parameters) { }

        public virtual void Dispose() { }
    }
}
