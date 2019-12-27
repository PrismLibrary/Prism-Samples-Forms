using Prism.Mvvm;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class ViewBViewModel : BindableBase, IInitialize
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public void Initialize(INavigationParameters parameters)
        {
            Message = "Manually initialized: " + parameters.GetValue<string>("message");
        }
    }
}
