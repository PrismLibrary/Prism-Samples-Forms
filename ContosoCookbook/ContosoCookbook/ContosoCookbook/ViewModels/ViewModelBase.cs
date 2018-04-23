using Prism.Mvvm;
using Prism.Navigation;

namespace ContosoCookbook.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware
    {
        public ViewModelBase()
        {

        }

        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {

        }

        public virtual void OnNavigatingTo(INavigationParameters parameters)
        {

        }
    }
}
