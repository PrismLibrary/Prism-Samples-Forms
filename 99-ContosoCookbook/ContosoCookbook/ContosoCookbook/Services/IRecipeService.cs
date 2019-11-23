using ContosoCookbook.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContosoCookbook.Services
{
    public interface IRecipeService
    {
        Task<IList<RecipeGroup>> GetRecipeGroups();
    }
}
