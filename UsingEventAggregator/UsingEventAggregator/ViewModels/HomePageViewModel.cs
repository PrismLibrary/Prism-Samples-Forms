using System.Windows.Input;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using UsingEventAggregator.Models;

namespace UsingEventAggregator
{
    public class HomePageViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public HomePageViewModel (INavigationService navigationService, IEventAggregator eventAggregator)
        {
            _navigationService = navigationService;
            _eventAggregator = eventAggregator;

            Title = "Your Feedback (Read only)";

            _eventAggregator.GetEvent<IsFunChangedEvent> ().Subscribe (IsFunChanged);
            _eventAggregator.GetEvent<GenericEvent<string>> ().Subscribe (NameChanged);
        }

        public void IsFunChanged (bool isFun)
        {
            IsFun = isFun;
        }

        public void NameChanged (string name)
        {
            Name = name;
        }

        #region Properties

        private bool _isFun;
        public bool IsFun 
        {
            get { return _isFun; }
            set { SetProperty (ref _isFun, value); }
        }

        private string _name = "Please provide feedback...";
        public string Name 
        {
            get { return _name; }
            set { SetProperty (ref _name, value); }
        }

        #endregion

        #region Commands

        private ICommand _entryCommand;
        public ICommand EntryCommand => _entryCommand ?? (_entryCommand = new DelegateCommand (OnEntryCommandTapped));

        private void OnEntryCommandTapped ()
        {
            _navigationService.NavigateAsync (nameof (DataEntryPage));
        }

        private ICommand _goBackCommand;
        public ICommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new DelegateCommand (OnGoBackCommandTapped));

        private void OnGoBackCommandTapped ()
        {
            _navigationService.GoBackAsync ();
        }
        #endregion

        #region Overrides

        public override void Dispose ()
        {
            _eventAggregator.GetEvent<IsFunChangedEvent> ().Unsubscribe (IsFunChanged);
            _eventAggregator.GetEvent<GenericEvent<string>> ().Unsubscribe (NameChanged);
        }

        #endregion

    }
}
