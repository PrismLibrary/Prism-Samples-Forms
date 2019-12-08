using System.Collections.ObjectModel;
using System.Threading.Tasks;
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

        private DelegateCommand<Developer> _selectedDeveloperCommand;
        public DelegateCommand<Developer> SelectedDeveloperCommand => _selectedDeveloperCommand ?? (_selectedDeveloperCommand = new DelegateCommand<Developer>(async (developer) => await SelectedDeveloper(developer)));

        public EventArgsExamplePageViewModel(IPageDialogService pageDialogService,
            IDataProvider dataProvider)
        {
            _pageDialogService = pageDialogService;

            // Insert test data into collection of Developers
            Developers = new ObservableCollection<Developer>();
            foreach (var developer in dataProvider.GetAllData())
            {
                Developers.Add(developer);
            }
        }

        async Task SelectedDeveloper(Developer developer)
        {
            await _pageDialogService.DisplayAlertAsync("Info", $"{developer.FullName} from {developer.Country} is selected.", "Ok");
        }
    }
}
