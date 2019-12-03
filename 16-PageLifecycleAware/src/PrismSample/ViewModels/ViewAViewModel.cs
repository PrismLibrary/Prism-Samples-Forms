using Prism.Mvvm;
using Prism.AppModel;


namespace PrismSample.ViewModels
{
    public class ViewAViewModel : BindableBase, IPageLifecycleAware
    {
        public void OnAppearing()
        {
            System.Diagnostics.Debugger.Break();
        }

        public void OnDisappearing()
        {
            System.Diagnostics.Debugger.Break();
        }
    }
}
