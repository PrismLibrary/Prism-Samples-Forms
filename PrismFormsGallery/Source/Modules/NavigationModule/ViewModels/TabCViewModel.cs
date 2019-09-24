using Prism.AppModel;

namespace NavigationModule.ViewModels
{
    public class TabCViewModel : BaseViewModel, IAutoInitialize
    {
        public TabCViewModel()
        {
            Title = "Tab C";
        }

        private string _name = "from Tab C";
        public string Name { get => _name; set { SetProperty(ref _name, value); } }

        private string _message = "friend";
        public string Message { get => _message; set { SetProperty(ref _message, value); } }
    }
}
