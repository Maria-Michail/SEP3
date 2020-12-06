using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Blazor.Data
{
    public interface IIngredientsService
    {
        public IList<Ingredient> Ingredients { get; }
        Task<List<Ingredient>> GetIngredientsAsync(int id);
        Task<List<OrderedShopIngredients>> GetShopIngredientsAsync();
    }
}