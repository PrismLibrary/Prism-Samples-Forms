using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private string text;
        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }
    }
}
