using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Data.Impl
{
    public interface IRecipeService
    {
        Task<IList<Recipe>> getRecipesAsync();
    }
}