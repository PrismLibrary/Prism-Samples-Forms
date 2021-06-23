using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using DynamicData;
using DynamicData.Binding;
using NuGet.Protocol.Core.Types;
using Prism.Navigation;
using PrismSample.Services;
using ReactiveUI;
using Splat;

namespace PrismSample.ViewModels
{
    public class NuGetPackageListViewModel : ViewModelBase
    {
        private readonly SourceCache<IPackageSearchMetadata, string> _nugetCache =
            new SourceCache<IPackageSearchMetadata, string>(x => x.Identity.Id);

        private ReadOnlyObservableCollection<NuGetPackageViewModel> _searchResults;
        private ObservableAsPropertyHelper<bool> _isRefreshing;
        private ObservableAsPropertyHelper<bool> _hasItems;
        private ReadOnlyObservableCollection<string> _tags;
        private readonly INavigationService _navigationService;
        private readonly INuGetPackageService _nugetPackageService;
        private string _searchText;
        private string _selectedTag;


        public NuGetPackageListViewModel(INavigationService navigationService, INuGetPackageService nugetPackageService)
        {
            _navigationService = navigationService;
            _nugetPackageService = nugetPackageService;

            PackageDetails = ReactiveCommand.CreateFromTask<NuGetPackageViewModel>(ExecutePackageDetails);
            Refresh = ReactiveCommand.CreateFromTask(ExecuteRefresh);

            Refresh.ThrownExceptions.Subscribe(exception => this.Log().Warn(exception));
            PackageDetails.ThrownExceptions.Subscribe(exception => this.Log().Warn(exception));

            var nugetChangeSet =
                _nugetCache
                    .Connect()
                    .RefCount();

            var sortChanged =
                this.WhenAnyValue(x => x.SelectedTag)
                    .Where(x => !string.IsNullOrEmpty(x))
                    .Select(selectedTag =>
                        SortExpressionComparer<NuGetPackageViewModel>
                            .Ascending(x => x.PackageMetadata.DownloadCount)
                            .ThenByAscending(x => x.PackageMetadata.Tags.Contains(selectedTag)));

            nugetChangeSet
                .Transform(x => new NuGetPackageViewModel(x))
                .Sort(sortChanged)
                .Bind(out _searchResults)
                .DisposeMany()
                .Subscribe()
                .DisposeWith(Disposal);

            _nugetCache
                .CountChanged
                .Select(count => count > 0)
                .ToProperty(this, x => x.HasItems, out _hasItems)
                .DisposeWith(Disposal);

            nugetChangeSet
                .Transform(x => x.Tags.Split(','))
                .RemoveKey()
                .TransformMany(x => x)
                .DistinctValues(x => x)
                .Bind(out _tags)
                .Subscribe()
                .DisposeWith(Disposal);

            Search =
                ReactiveCommand.CreateFromObservable<string, IEnumerable<IPackageSearchMetadata>>(SearchNuGetPackages);

            Search
                .Select(packageSearchMetadata => packageSearchMetadata)
                .Subscribe(packages =>
                    _nugetCache.EditDiff(packages, (first, second) => first.Identity.Id == second.Identity.Id))
                .DisposeWith(Disposal);

            this.WhenAnyValue(x => x.SearchText)
                .Where(x => !string.IsNullOrEmpty(x))
                .Throttle(TimeSpan.FromMilliseconds(750), RxApp.TaskpoolScheduler)
                .Select(term => term.Trim())
                .DistinctUntilChanged()
                .InvokeCommand(this, x => x.Search)
                .DisposeWith(Disposal);

            this.WhenAnyValue(x => x.SearchText)
                .Where(string.IsNullOrEmpty)
                .Subscribe(_ => _nugetCache.Clear())
                .DisposeWith(Disposal);

            this.WhenAnyObservable(x => x.Refresh.IsExecuting)
                .StartWith(false)
                .DistinctUntilChanged()
                .ToProperty(this, x => x.IsRefreshing, out _isRefreshing)
                .DisposeWith(Disposal);
        }

        public ReactiveCommand<string, IEnumerable<IPackageSearchMetadata>> Search { get; set; }

        public bool IsRefreshing => _isRefreshing.Value;

        public bool HasItems => _hasItems.Value;


        public string SearchText
        {
            get => _searchText;
            set => this.RaiseAndSetIfChanged(ref _searchText, value);
        }

        public string SelectedTag
        {
            get => _selectedTag;
            set => this.RaiseAndSetIfChanged(ref _selectedTag, value);
        }

        public string Instructions = "Search for a NuGet package.";

        public ReadOnlyObservableCollection<NuGetPackageViewModel> SearchResults => _searchResults;

        public ReadOnlyObservableCollection<string> Tags => _tags;

        public ReactiveCommand<NuGetPackageViewModel, Unit> PackageDetails { get; set; }

        public ReactiveCommand<Unit, Unit> Refresh { get; set; }


        private async Task ExecutePackageDetails(NuGetPackageViewModel viewModel) =>
            await _navigationService.NavigateAsync(
                "NuGetPackageDetailPage",
                new NavigationParameters
                {
                    {"PackageMetadata", viewModel.PackageMetadata}
                });

        private async Task<IEnumerable<NuGetPackageViewModel>> SearchNuGetPackages(string term, CancellationToken token)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return Enumerable.Empty<NuGetPackageViewModel>();
            }

            var result = await _nugetPackageService.SearchNuGetPackages(term, token);
            return result.Select(x => new NuGetPackageViewModel(x));
        }

        private async Task ExecuteRefresh()
        {
            var result = await _nugetPackageService.SearchNuGetPackages(SearchText, CancellationToken.None);
        }

        private IObservable<IEnumerable<IPackageSearchMetadata>> SearchNuGetPackages(string term) =>
            Observable.FromAsync(async () =>
                await _nugetPackageService.SearchNuGetPackages(term, CancellationToken.None));
    }
}