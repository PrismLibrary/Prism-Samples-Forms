using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private IApplicationCommands _applicationCommand;
        public IApplicationCommands ApplicationCommands
        {
            get { return _applicationCommand; }
            set { SetProperty(ref _applicationCommand, value); }
        }

        public MainPageViewModel(IApplicationCommands applicationCommands)
        {
            ApplicationCommands = applicationCommands;
        }
    }
}
