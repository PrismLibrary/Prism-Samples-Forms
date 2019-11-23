using System.Reactive.Disposables;
using PrismSample.ViewModels;
using ReactiveUI.XamForms;

namespace PrismSample.Views
{
    public abstract class ContentViewBase<TViewModel> : ReactiveContentView<TViewModel>
        where TViewModel : ViewModelBase
    {
        protected readonly CompositeDisposable ViewCellBindings = new CompositeDisposable();
    }
}