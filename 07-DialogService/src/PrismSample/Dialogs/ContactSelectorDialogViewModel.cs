using System;
using System.Collections.Generic;
using Prism.Services.Dialogs;
using PrismSample.Models;
using PrismSample.Services;

namespace PrismSample.ViewModels
{
    public class ContactSelectorDialogViewModel : BaseViewModel, IDialogAware
    {
        private readonly IContactsService _contactsService;
        
        public ContactSelectorDialogViewModel(IContactsService contactsService)
        {
            _contactsService = contactsService;
        }
        
        private List<Contact> _contacts;
        public List<Contact> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }
        
        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                SetProperty(ref _selectedContact, value);
                if(value != null)
                    RequestClose(new DialogParameters {{"Contact", value}});
            }
        }
        
        public async void OnDialogOpened(IDialogParameters parameters)
        {
            Contacts = await _contactsService.GetContacts();
        }
        
        public bool CanCloseDialog() => true;
        public void OnDialogClosed() { }       
        public event Action<IDialogParameters> RequestClose;
    }
}