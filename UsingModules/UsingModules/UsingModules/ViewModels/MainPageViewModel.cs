using System.Windows.Input;
using Prism.Commands;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Navigation;

namespace UsingModules.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IModuleManager _moduleManager;
        private readonly INavigationService _navigationService;

        public MainPageViewModel(IModuleManager moduleManager, INavigationService navigationService)
        {
            _moduleManager = moduleManager;
            _navigationService = navigationService;

            LoadSampleModuleCommand = new DelegateCommand(LoadSampleModule, ()=>!IsSampleModuleRegistered)
                .ObservesProperty(()=>IsSampleModuleRegistered);
            NavigateToSamplePageCommand = new DelegateCommand(NavigateToSamplePage, ()=>IsSampleModuleRegistered)
                .ObservesProperty(()=>IsSampleModuleRegistered);
        }

        private bool _isSampleModuleRegistered;
        public bool IsSampleModuleRegistered
        {
            get { return _isSampleModuleRegistered; }
            set { SetProperty(ref _isSampleModuleRegistered, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand LoadSampleModuleCommand { get; set; }

        public ICommand NavigateToSamplePageCommand { get; set; }

        private void NavigateToSamplePage()
        {
            _navigationService.NavigateAsync("SamplePage?par=test");
        }

        private void LoadSampleModule()
        {
            _moduleManager.LoadModule("SampleModule");
            IsSampleModuleRegistered = true;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("title"))
                Title = (string)parameters["title"] + " and Prism";
        }
    }
}
