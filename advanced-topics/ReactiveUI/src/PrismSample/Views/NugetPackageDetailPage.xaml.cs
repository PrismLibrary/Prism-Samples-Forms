using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismSample.ViewModels;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuGetPackageDetailPage : ContentPageBase<NuGetPackageDetailViewModel>
    {
        public NuGetPackageDetailPage()
        {
            InitializeComponent();

            this.WhenAnyValue(x => x.ViewModel.PackageSearchMetadata)
                .Where(x => x != null)
                .InvokeCommand(this, x => x.ViewModel.GetVersions)
                .DisposeWith(ViewBindings);

            NuGetVersions
                .Events()
                .ItemSelected
                .Subscribe(_ => NuGetVersions.SelectedItem = null)
                .DisposeWith(ViewBindings);
        }
    }
}