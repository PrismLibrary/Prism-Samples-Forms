using Prism.Mvvm;
using Prism.Navigation;

namespace PrismSample.SampleModule.ViewModels
{
    public class SamplePageViewModel : BindableBase, INavigationAware
    {
        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            // Called when the implementer has been navigated away from.
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            // Called when the implementer has been navigated to.
            Title = "Sample Page from a Prism module";

            var parameterName = "par";
            if (parameters.ContainsKey(parameterName))
                Title += " - parameter: " + (string)parameters[parameterName];
        }
    }
}
