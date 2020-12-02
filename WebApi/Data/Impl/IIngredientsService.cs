using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Blazor.Data
{
    public interface IIngredientsService
    {
        public IList<Ingredient> Recipes { get; }
        Task<List<Ingredient>> GetIngredientsAsync();
    }
}