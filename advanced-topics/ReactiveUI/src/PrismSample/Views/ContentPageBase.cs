using System.Reactive.Disposables;
using Prism.Navigation;
using PrismSample.ViewModels;
using ReactiveUI.XamForms;

namespace PrismSample.Views
{
    public abstract class ContentPageBase<T> : ReactiveContentPage<T>, IDestructible
        where T : ViewModelBase
    {
        protected readonly CompositeDisposable ViewBindings = new CompositeDisposable();

        public void Destroy()
        {
            ViewBindings?.Dispose();
        }
    }
}