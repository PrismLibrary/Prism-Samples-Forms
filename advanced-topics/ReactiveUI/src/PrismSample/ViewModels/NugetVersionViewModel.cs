using NuGet.Protocol.Core.Types;
using ReactiveUI;

namespace PrismSample.ViewModels
{
    public class NugetVersionViewModel : ViewModelBase
    {
        private VersionInfo _versionInfo;

        public NugetVersionViewModel(VersionInfo versionInfo)
        {
            _versionInfo = versionInfo;
        }

        public VersionInfo VersionInformation
        {
            get => _versionInfo;
            set => this.RaiseAndSetIfChanged(ref _versionInfo, value);
        }
    }
}