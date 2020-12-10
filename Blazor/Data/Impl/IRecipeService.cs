
using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Blazor.Data
{
    public interface IRecipeService
    {
        public IList<Recipe> Recipes { get; }
        public Recipe recipe { get; set; }
        Task<List<Recipe>> GetRecipesAsync();
    }
}