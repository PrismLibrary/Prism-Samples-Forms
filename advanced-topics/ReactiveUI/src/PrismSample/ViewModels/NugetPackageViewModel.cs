using System;
using System.Reactive;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;
using ReactiveUI;
using Xamarin.Forms;

namespace PrismSample.ViewModels
{
    public class NuGetPackageViewModel : ViewModelBase
    {
        private IPackageSearchMetadata _packageSearchMetadata;

        public NuGetPackageViewModel(IPackageSearchMetadata packageSearchMetadata)
        {
            _packageSearchMetadata = packageSearchMetadata;
        }

        public IPackageSearchMetadata PackageMetadata
        {
            get => _packageSearchMetadata;
            set => this.RaiseAndSetIfChanged(ref _packageSearchMetadata, value);
        }
    }
}