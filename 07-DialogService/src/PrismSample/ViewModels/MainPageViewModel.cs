using Prism.Commands;
using Prism.Services.Dialogs;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        public MainPageViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            Title = "Dialog Service";
            LockingDialogCommand = new DelegateCommand(OnLockingDialogTapped);
            TapToCloseDialogCommand = new DelegateCommand(OnTapToCloseDialogTapped);
        }

        public DelegateCommand LockingDialogCommand { get; }
        public DelegateCommand TapToCloseDialogCommand { get; }
        
        private void OnLockingDialogTapped()
        {
            _dialogService.ShowDialog("LockingDialog?Question=Can navigate away?");
        }
        
        private void OnTapToCloseDialogTapped()
        {
            _dialogService.ShowDialog("LockingDialog", new DialogParameters
            {
                { "Question", "Tap outside to close?" },
                { "CloseOnTap", true }
            });
        }
    }
}
