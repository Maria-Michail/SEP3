using System.Collections.Generic;
using System.Threading.Tasks;
using Model;

namespace Db
{
    public interface IDbCategoryService
    {
        Task<List<Category>> GetCategoriesAcyns();
        Task addCategoryAsync(Category category);
        Task updateCategoryAsync(Category category);
        Task removeCategoryAsync(Category category);
    }
}