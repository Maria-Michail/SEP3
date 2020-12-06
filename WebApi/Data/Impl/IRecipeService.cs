using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Data.Impl
{
    public interface IRecipeService
    {
        Task<IList<Recipe>> getRecipesAsync();
        Task<IList<Ingredient>> GetIngredientsAsync(int id);
        Task<IList<OrderedShopIngredients>> GetShopIngredientsAsync(int id);
        Task SetIngredientsAsync(IList<Ingredient> ingredients);
    }
}