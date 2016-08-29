using Prism.Mvvm;
using Prism.Navigation;

namespace UsingModules.SampleModule.ViewModels
{
    public class SamplePageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Title = "Sample Page from a Prism module";

            var parameterName = "par";
            if (parameters.ContainsKey(parameterName))
                Title += " - parameter: " + (string)parameters[parameterName];
        }
    }
}
