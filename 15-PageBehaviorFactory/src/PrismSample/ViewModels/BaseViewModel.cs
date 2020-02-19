using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class BaseViewModel : BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}
