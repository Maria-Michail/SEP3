using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbRecipeService
    {
        Task<List<Recipe>> getRecipiesAsync();
        Task removeRecipeAsync(string recipeName);
        Task addRecipeAsync(Recipe recipe, string categoryName);
        Task updateRecipeAsync(Recipe recipe);
        Task<List<Category>> getCategoriesAsync();
    }
}