using Prism.AppModel;
using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class ViewAViewModel : BindableBase, IAutoInitialize
    {
        private string _message;
        [AutoInitialize(true)]
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
    }
}
