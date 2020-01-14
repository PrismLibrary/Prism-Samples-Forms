using System;
using System.Threading.Tasks;
using Prism.Mvvm;
using Prism.Navigation;

namespace PrismSample.ViewModels
{
    public class ViewCViewModel : BindableBase, IInitializeAsync
    {
        private string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public Task InitializeAsync(INavigationParameters parameters)
        {
            Message = "Initialized with long running task: " + parameters.GetValue<string>("message");
            return Task.Delay(TimeSpan.FromSeconds(7.5));
        }
    }
}
