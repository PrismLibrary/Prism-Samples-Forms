using Prism;
using Prism.Events;
using Prism.Navigation;
using TabbedNavigation.Events;
using System;

namespace TabbedNavigation.ViewModels
{
    public class ChildViewModelBase : BaseViewModel, IActiveAware, INavigatingAware, IDestructible
    {
        IEventAggregator _ea { get; }
        public ChildViewModelBase( IEventAggregator eventAggregator )
        {
            _ea = eventAggregator;

            _ea.GetEvent<InitializeTabbedChildrenEvent>().Subscribe(OnInitializationEventFired);

            IsActiveChanged += (sender, e) => System.Diagnostics.Debug.WriteLine($"{Title} IsActive: {IsActive}");
        }

        public event EventHandler IsActiveChanged;

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, () => System.Diagnostics.Debug.WriteLine($"{Title} IsActive Changed: {value}")); }
        }

        void OnInitializationEventFired(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{Title} Detected an initialization event");
            var message = parameters.GetValue<string>("message");
            Message = $"{Title} Initialized by Event: {message}";
        }

        public override void OnNavigatingTo(NavigationParameters parameters)
        {
            System.Diagnostics.Debug.WriteLine($"{Title} is executing OnNavigatingTo");
            var message = parameters.GetValue<string>("message");
            Message = $"{Title} Initialized by OnNavigatingTo: {message}";
        }

        public override void Destroy()
        {
            System.Diagnostics.Debug.WriteLine($"{Title} is being Destroyed!");
            _ea.GetEvent<InitializeTabbedChildrenEvent>().Unsubscribe(OnInitializationEventFired);
        }
    }
}
