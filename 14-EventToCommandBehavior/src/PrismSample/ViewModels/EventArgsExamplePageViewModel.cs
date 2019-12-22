using System.Collections.ObjectModel;
using PrismSample.Services;
using PrismSample.Models;
using Prism.Services;
using Prism.Commands;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class EventArgsExamplePageViewModel : BindableBase
    {
        private readonly IPageDialogService _pageDialogService;

        public ObservableCollection<Developer> Developers { get; set; }

        public DelegateCommand<Developer> SelectedDeveloperCommand { get; private set; }

        public EventArgsExamplePageViewModel(IPageDialogService pageDialogService,
            IDataProvider dataProvider)
        {
            _pageDialogService = pageDialogService;

            SelectedDeveloperCommand = new DelegateCommand<Developer>(SelectedDeveloper);

            // Insert test data into collection of Developers
            Developers = new ObservableCollection<Developer>();
            foreach (var developer in dataProvider.GetAllData())
            {
                Developers.Add(developer);
            }
        }

        private async void SelectedDeveloper(Developer developer)
        {
            await _pageDialogService.DisplayAlertAsync("Info", $"{developer.FullName} from {developer.Country} is selected.", "Ok");
        }
    }
}
