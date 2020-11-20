using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbIngredientService
    {
        Task<List<Ingredient>> getIngredientsAsync();
        Task<Ingredient> getIngredientAsync(string name);
        Task addIngredientAsync(Ingredient ingredient);
        Task updateIngredientAsync(Ingredient ingredient);
        Task removeIngredientAsync(Ingredient ingredient);
    }
}