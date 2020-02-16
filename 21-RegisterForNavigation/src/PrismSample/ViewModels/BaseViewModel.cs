using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private string pageText;
        public string PageText
        {
            get { return pageText; }
            set { SetProperty(ref pageText, value); }
        }
    }
}
