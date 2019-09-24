using Prism.AppModel;

namespace NavigationModule.ViewModels
{
    public class TabBViewModel : BaseViewModel, IAutoInitialize
    {
        public TabBViewModel()
        {
            Title = "Tab B";
        }
        private string _name = "from Tab B";
        public string Name { get => _name; set { SetProperty(ref _name, value); } }
    }
}
