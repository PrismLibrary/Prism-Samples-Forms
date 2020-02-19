using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using PrismSample.Converters;
using PrismSample.ViewModels;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PrismSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuGetPackageListPage : ContentPageBase<NuGetPackageListViewModel>
    {
        public NuGetPackageListPage()
        {
            InitializeComponent();

            this.Bind(ViewModel, x => x.SearchText, x => x.SearchBar.Text)
                .DisposeWith(ViewBindings);

            this.OneWayBind(ViewModel, x => x.Instructions, x => x.Instructions.Text)
                .DisposeWith(ViewBindings);

            this.OneWayBind(ViewModel, x => x.HasItems, x => x.Instructions.IsVisible, vmToViewConverterOverride: new InverseBooleanBindingTypeConverter())
                .DisposeWith(ViewBindings);

            this.OneWayBind(ViewModel, x => x.HasItems, x => x.NuGetPackageListView.IsVisible)
                .DisposeWith(ViewBindings);

            this.OneWayBind(ViewModel, x => x.IsRefreshing, x => x.NuGetPackageListView.IsRefreshing)
                .DisposeWith(ViewBindings);

            this.WhenAnyValue(x => x.ViewModel.SearchResults)
                .BindTo(this, x => x.NuGetPackageListView.ItemsSource)
                .DisposeWith(ViewBindings);

            NuGetPackageListView
                .Events() // The Events API provided by Pharmacist
                .ItemTapped
                .Select(x => x.Item as NuGetPackageViewModel) // Select the tapped item as the View Model
                .ObserveOn(RxApp.MainThreadScheduler)
                .InvokeCommand(this, x => x.ViewModel.PackageDetails) // Invoke a command on the provided ViewModel
                .DisposeWith(ViewBindings);

            NuGetPackageListView
                .Events() // The Events API provided by Pharmacist
                .ItemSelected
                .Select(_ => Unit.Default)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(x => NuGetPackageListView.SelectedItem = null)
                .DisposeWith(ViewBindings);

            NuGetPackageListView
                .Events() // The Events API provided by Pharmacist
                .Refreshing
                .Select(_ => Unit.Default)
                .InvokeCommand(this, x => x.ViewModel.Refresh)
                .DisposeWith(ViewBindings);
        }
    }
}