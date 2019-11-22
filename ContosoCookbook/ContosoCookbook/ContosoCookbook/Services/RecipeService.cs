using ContosoCookbook.Business;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ContosoCookbook.Services
{
    public class RecipeService : IRecipeService
    {
        public async Task<IList<RecipeGroup>> GetRecipeGroups()
        {
            // Read RecipeData.json from this Assembly's DataModel folder
            var assembly = GetType().Assembly;
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith("Data.RecipeData.json", System.StringComparison.OrdinalIgnoreCase));
            if(string.IsNullOrEmpty(resourceName))
            {
                Debugger.Break();
                return new List<RecipeGroup>();
            }

            // Parse the JSON and generate a collection of RecipeGroup objects
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            using (var reader = new StreamReader(stream))
            {
                string json = await reader.ReadToEndAsync();
                var obj = new { Groups = new List<RecipeGroup>() };
                var result = JsonConvert.DeserializeAnonymousType(json, obj);
                return result.Groups;
            }
        }
    }
}
