using NuGet.Protocol.Core.Types;
using ReactiveUI;

namespace PrismSample.ViewModels
{
    public class NuGetVersionViewModel : ViewModelBase
    {
        private VersionInfo _versionInfo;

        public NuGetVersionViewModel(VersionInfo versionInfo)
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