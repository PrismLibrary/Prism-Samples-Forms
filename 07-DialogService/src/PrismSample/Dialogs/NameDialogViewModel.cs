using System;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismSample.ViewModels
{
    public class NameDialogViewModel : BaseViewModel, IDialogAware
    {
        public NameDialogViewModel()
        {
            SubmitCommand = new DelegateCommand(OnSubmitTapped);
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        public DelegateCommand SubmitCommand { get; set; }

        private void OnSubmitTapped()
        {
            RequestClose.Invoke(new DialogParameters { { "Name", Name } });
        }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => true;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters) { }
    }
}
