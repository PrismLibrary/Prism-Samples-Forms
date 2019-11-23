using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;
using Prism.Navigation;
using ReactiveUI;

namespace PrismSample.ViewModels
{
    public class NugetPackageDetailViewModel : NavigationViewModelBase
    {
        private IPackageSearchMetadata _packageSearchMetadata;
        private readonly ObservableAsPropertyHelper<IEnumerable<NugetVersionViewModel>> _versions;

        public NugetPackageDetailViewModel()
        {
            GetVersions = ReactiveCommand.CreateFromTask<IPackageSearchMetadata, IEnumerable<NugetVersionViewModel>>(ExecuteGetVersions);

            _versions = GetVersions.ToProperty(this, x => x.Versions, scheduler: RxApp.MainThreadScheduler);
        }

        public ReactiveCommand<IPackageSearchMetadata, IEnumerable<NugetVersionViewModel>> GetVersions { get; set; }

        public IPackageSearchMetadata PackageSearchMetadata
        {
            get => _packageSearchMetadata;
            set => this.RaiseAndSetIfChanged(ref _packageSearchMetadata, value);
        }

        public IEnumerable<NugetVersionViewModel> Versions => _versions.Value;

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey("PackageMetadata"))
            {
                PackageSearchMetadata = parameters.GetValue<IPackageSearchMetadata>("PackageMetadata");
            }
        }

        private async Task<IEnumerable<NugetVersionViewModel>> ExecuteGetVersions(IPackageSearchMetadata packageSearchMetadata)
        {
            var versions = await packageSearchMetadata.GetVersionsAsync();
            return versions.Reverse().Take(30).Select(x => new NugetVersionViewModel(x));
        }
    }
}