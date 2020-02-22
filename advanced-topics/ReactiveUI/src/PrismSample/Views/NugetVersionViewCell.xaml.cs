using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Text;
using System.Threading.Tasks;
using PrismSample.Converters;
using PrismSample.ViewModels;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuGetVersionViewCell : ContentViewBase<NuGetVersionViewModel>
    {
        public NuGetVersionViewCell()
        {
            InitializeComponent();

            // Note: The VersionToStringConvterer could be done inline.  Check the ReadMe.md for a link to the documentation
            this.OneWayBind(ViewModel, x => x.VersionInformation.Version, x => x.PackageVersion.Text, vmToViewConverterOverride: new VersionToStringConverter())
                .DisposeWith(ViewCellBindings);

            this.OneWayBind(ViewModel, x => x.VersionInformation.DownloadCount, x => x.DownloadCount.Text, count => $"{count:N0} downloads")
                .DisposeWith(ViewCellBindings);
        }
    }
}