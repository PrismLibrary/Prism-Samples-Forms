using System;
using Prism.Mvvm;
using Prism.Navigation;

namespace UsingEventAggregator.ViewModels
{
    public class BaseViewModel : BindableBase, INavigationAware, IDisposable
    {

        private string _title;
        public string Title {
        	get { return _title; }
        	set { SetProperty (ref _title, value); }
        }

        public virtual void OnNavigatedFrom (INavigationParameters parameters) { }

        public virtual void OnNavigatedTo (INavigationParameters parameters) { }

        public virtual void OnNavigatingTo (INavigationParameters parameters) { }

        public virtual void Dispose() { }
    }
}
