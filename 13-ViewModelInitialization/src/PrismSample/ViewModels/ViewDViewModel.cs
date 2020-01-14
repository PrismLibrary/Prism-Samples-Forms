using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;

namespace PrismSample.ViewModels
{
    public class ViewDViewModel : BindableBase, IInitialize
    {
        private INavigationService _navigationService { get; }
        private IPageDialogService _dialogs { get; }

        public ViewDViewModel(INavigationService navigationService, IPageDialogService dialogs)
        {
            _navigationService = navigationService;
            _dialogs = dialogs;
        }

        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public async void Initialize(INavigationParameters parameters)
        {
            Message = "Not actually set yet...";
            try
            {
                await DoBadStuff();
                Message = "Manually initialized: " + parameters.GetValue<string>("message");
            }
            catch (Exception ex)
            {
                await _dialogs.DisplayAlertAsync("Whoops", ex.Message, "Ok");
                await _navigationService.GoBackAsync();
            }
        }

        private async Task DoBadStuff()
        {
            await Task.Delay(TimeSpan.FromSeconds(5));
            throw new Exception("Really bad stuff happened");
        }
    }
}
