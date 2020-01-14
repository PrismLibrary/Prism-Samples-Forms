using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class TabAPageViewModel : BindableBase, IActiveAware, IInitialize
    {
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
        }

        private int _activeCount;
        public int ActiveCount
        {
            get { return _activeCount; }
            set { SetProperty(ref _activeCount, value); }
        }

        public event EventHandler IsActiveChanged;

        public TabAPageViewModel()
        {

        }

        private void RaiseIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            if (IsActive)
            {
                ActiveCount++;
            }
            else
            {
            }
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("ActiveCount"))
            {
                ActiveCount = parameters.GetValue<int>("ActiveCount");
            }
        }
    }
}
