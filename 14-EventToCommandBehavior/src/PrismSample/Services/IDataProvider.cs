using PrismSample.Models;
using System.Collections.Generic;

namespace PrismSample.Services
{
    public interface IDataProvider
    {
        List<Developer> GetAllData();
    }
}
