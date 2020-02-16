using Prism.Mvvm;

namespace PrismSample.ViewModels
{
    public class BasicPageViewModel : BaseViewModel
    {
        public BasicPageViewModel()
        {
            PageText = "MVVM and data binding is working with basic page registration!";
        }
    }
}
