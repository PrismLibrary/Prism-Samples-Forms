using Prism.Commands;
using Prism.Mvvm;
using Prism.Services;
using System.Diagnostics;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private IPageDialogService _pageDialogService { get; }

        public MainPageViewModel(IPageDialogService pageDialogService)
        {
            _pageDialogService = pageDialogService;

            DisplayAlertCommand = new DelegateCommand(DisplayAlert);

            DisplayActionSheetCommand = new DelegateCommand(DisplayActionSheet);

            DisplayActionSheetUsingActionSheetButtonsCommand = new DelegateCommand(DisplayActionSheetUsingActionSheetButtons);
        }

        public DelegateCommand DisplayAlertCommand { get; }
        public DelegateCommand DisplayActionSheetCommand { get; }
        public DelegateCommand DisplayActionSheetUsingActionSheetButtonsCommand { get; }

        private async void DisplayAlert()
        {
            var result = await _pageDialogService.DisplayAlertAsync("Alert", "This is an alert from MainPageViewModel.", "Accept", "Cancel");
            Trace.WriteLine(result);
        }

        private async void DisplayActionSheet()
        {
            var result = await _pageDialogService.DisplayActionSheetAsync("ActionSheet", "Cancel", "Destroy", "Option 1", "Option 2");
            Trace.WriteLine(result);
        }

        private async void DisplayActionSheetUsingActionSheetButtons()
        {
            var buttons = new IActionSheetButton[]
            {
                ActionSheetButton.CreateButton("Option 1", WriteLine, "Option 1"),
                ActionSheetButton.CreateButton("Option 2", WriteLine, "Option 2"),
                ActionSheetButton.CreateCancelButton("Cancel", WriteLine, "Cancel"),
                ActionSheetButton.CreateDestroyButton("Destroy", WriteLine, "Destroy")
            };

            await _pageDialogService.DisplayActionSheetAsync("ActionSheet with ActionSheetButtons", buttons);
        }

        private void WriteLine(string message) =>
            Trace.WriteLine(message);
    }
}
