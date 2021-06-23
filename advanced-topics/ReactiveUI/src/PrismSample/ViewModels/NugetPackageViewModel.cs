using NuGet.Protocol.Core.Types;
using ReactiveUI;

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