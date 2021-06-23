using System.Reactive.Disposables;
using Prism.Navigation;
using ReactiveUI;

namespace PrismSample.ViewModels
{
    public abstract class ViewModelBase : ReactiveObject, IDestructible
    {
        protected CompositeDisposable Disposal = new CompositeDisposable();

        public void Destroy()
        {
            Disposal.Dispose();
        }
    }
}