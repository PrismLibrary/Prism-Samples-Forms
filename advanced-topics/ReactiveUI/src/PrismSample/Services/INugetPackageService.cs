using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;
using PrismSample.ViewModels;

namespace PrismSample.Services
{
    public interface INuGetPackageService
    {
        Task<IEnumerable<IPackageSearchMetadata>> SearchNuGetPackages(string term, CancellationToken token);
    }
}