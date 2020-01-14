using System;
using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismSample.ViewModels
{
    public class LockingDialogViewModel : BaseViewModel, IDialogAware
    {
        public LockingDialogViewModel()
        {
            CloseCommand = new DelegateCommand(OnCloseTapped);
        }

        private string _question;
        public string Question
        {
            get => _question; 
            set => SetProperty(ref _question, value);
        }

        private bool _canClose;
        public bool CanClose
        {
            get => _canClose;
            set => SetProperty(ref _canClose, value);
        }

        private bool _closeOnTap;
        public bool CloseOnTap
        {
            get => _closeOnTap;
            set => SetProperty(ref _closeOnTap, value);
        }

        private void OnCloseTapped()
        {
            RequestClose(new DialogParameters());
        }

        public DelegateCommand CloseCommand { get; }

        public event Action<IDialogParameters> RequestClose;

        public bool CanCloseDialog() => CanClose;

        public void OnDialogClosed() { }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            // When not using IAutoInitialize, get values from parameters
            
            // For sample 2 & 3
            if (parameters.ContainsKey("Question"))
                Question = parameters.GetValue<string>("Question");
            
            // For sample 3
            if (parameters.ContainsKey("CloseOnTap"))
                CloseOnTap = CanClose = parameters.GetValue<bool>("CloseOnTap");
        }
    }
}
