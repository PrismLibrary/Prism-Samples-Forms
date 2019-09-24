using Prism.Navigation;

namespace NavigationModule.ViewModels
{
    public class ViewAViewModel : BaseViewModel
    {
        public ViewAViewModel()
        {
            Title = "View A";
        }
        
        private string _name = "stranger";
        public string Name { get => _name; set { SetProperty(ref _name, value); } }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("name"))
                Name = (string)parameters["name"];

            if (parameters.ContainsKey("title"))
                Title = (string)parameters.GetValue<string>("title");

            if (parameters.GetNavigationMode() == NavigationMode.Back)
                Name += " again";
        }
    }
}
