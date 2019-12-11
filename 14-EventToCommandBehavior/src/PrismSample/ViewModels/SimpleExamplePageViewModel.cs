using System.Collections.ObjectModel;
using PrismSample.Services;
using PrismSample.Models;
using Prism.Commands;
using Prism.Services;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class SimpleExamplePageViewModel : BindableBase
    {
        private readonly IPageDialogService _pageDialogService;

        public DelegateCommand SelectedDeveloperCommand { get; private set; }

        public ObservableCollection<Developer> Developers { get; set; }

        public SimpleExamplePageViewModel(IPageDialogService pageDialogService, 
            IDataProvider dataProvider)
        {
            _pageDialogService = pageDialogService;

            SelectedDeveloperCommand = new DelegateCommand(SelectedDeveloper);

            // Insert test data into collection of Developers
            Developers = new ObservableCollection<Developer>();
            foreach (var person in dataProvider.GetAllData())
            {
                Developers.Add(person);
            }
        }

        private async void SelectedDeveloper()
        {
            await _pageDialogService.DisplayAlertAsync("Info.", "Some developer is selected.", "Ok");
        }
    }
}
