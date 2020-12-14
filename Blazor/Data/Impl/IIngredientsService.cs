using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Model;

namespace Blazor.Data
{
    public interface IIngredientsService
    {
        public IList<Ingredient> Ingredients { get; }
        public IList<OrderedShopIngredients> OrderedShopIngredients { get; }
        public void UpdateOrderedShopIngredients(OrderedShopIngredients orderedShopIngredients);
        Task<List<Ingredient>> GetIngredientsAsync(int id);
        Task<List<OrderedShopIngredients>> GetShopIngredientsAsync();
    }
}