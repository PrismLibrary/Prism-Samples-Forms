using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private bool _isActive;
        public bool IsActive
        {
            get { return _isActive; }
            set { SetProperty(ref _isActive, value); }
        }

        private string _text = "Default Text";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        public DelegateCommand<string> ButtonClickCommand { get; private set; }

        public MainPageViewModel()
        {
            ButtonClickCommand = new DelegateCommand<string>(Execute).ObservesCanExecute(() => IsActive);
        }

        private void Execute(string parameter)
        {
            Text = parameter;
        }
    }
}
