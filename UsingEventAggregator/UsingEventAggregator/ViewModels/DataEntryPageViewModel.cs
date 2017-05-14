using System;
using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using UsingEventAggregator.Models;

namespace UsingEventAggregator
{
    public class DataEntryPageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public DataEntryPageViewModel (INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "So what do you think?";
        }

        private bool _isFun;
        public bool IsFun {
        get { return _isFun; }
        set { 
                SetProperty (ref _isFun, value);
                _eventAggregator.GetEvent<IsFunChangedEvent> ().Publish (value);
            }
        }

        private string _name;
        public string Name 
        {
        	get { return _name; }
        	set { 
                SetProperty (ref _name, value);
                _eventAggregator.GetEvent<GenericEvent<string>> ().Publish (value); 
            }
        }

        private ICommand _submitCommand;
        public ICommand SubmitCommand => _submitCommand ?? (_submitCommand = new DelegateCommand (OnSubmitTapped));

        private void OnSubmitTapped()
        {
            _navigationService.GoBackAsync ();
        }
    }
}
