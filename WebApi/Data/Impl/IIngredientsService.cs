using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Blazor.Data
{
    public interface IIngredientsService
    {
        Task<IList<Ingredient>> GetIngredientsAsync();
        
    }
}