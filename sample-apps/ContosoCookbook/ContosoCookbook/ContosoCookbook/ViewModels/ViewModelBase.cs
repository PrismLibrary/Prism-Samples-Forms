using Prism.Mvvm;
using Prism.Navigation;

namespace ContosoCookbook.ViewModels
{
    public class ViewModelBase : BindableBase, INavigationAware, IInitialize
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

        public virtual void Initialize(INavigationParameters parameters)
        {

        }
    }
}
