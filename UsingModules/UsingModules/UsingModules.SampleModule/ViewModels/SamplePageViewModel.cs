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
            // Called when the implementer has been navigated away from.
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            // Called when the implementer has been navigated to.
            Title = "Sample Page from a Prism module";

            var parameterName = "par";
            if (parameters.ContainsKey(parameterName))
                Title += " - parameter: " + (string)parameters[parameterName];
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            //Called before the implementor has been navigated to - but not called when using 
            // device hardware or software back buttons.
        }
    }
}
