using System.Collections.Generic;
using Prism.Commands;
using Prism.Services.Dialogs;
using PrismSample.Models;
using PrismSample.Services;

namespace PrismSample.ViewModels
{
    public class SelectorPageViewModel : BaseViewModel
    {
        private readonly IDialogService _dialogService;

        public SelectorPageViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            GetContactCommand = new DelegateCommand(OnGetContactTapped);
        }

        private Contact _contact;
        public Contact Contact
        {
            get { return _contact; }
            set { SetProperty(ref _contact, value); }
        }

        public DelegateCommand GetContactCommand { get; }
        
        async void OnGetContactTapped()
        {
            Contact = await _dialogService.ShowDialogAsync<Contact>("ContactSelectorDialog");
        }
    }
}