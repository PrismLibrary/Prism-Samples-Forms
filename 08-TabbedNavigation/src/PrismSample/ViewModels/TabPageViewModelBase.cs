using Prism.Mvvm;
using System;
using Prism;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class TabPageViewModelBase : BindableBase, IActiveAware, IInitialize
    {
        private readonly INavigationService _navigationService;

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set => SetProperty(ref _isActive, value, RaiseIsActiveChanged);
        }

        private int _activeCount;
        public int ActiveCount
        {
            get => _activeCount;
            set => SetProperty(ref _activeCount, value);
        }

        public event EventHandler IsActiveChanged;

        public TabPageViewModelBase(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("ActiveCount"))
            {
                ActiveCount = parameters.GetValue<int>("ActiveCount");
            }
        }

        private void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            if (IsActive)
            {
                ActiveCount++;
            }
        }
    }
}
