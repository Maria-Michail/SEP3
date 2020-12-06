using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbCategoryService:IDbCategoryService
    {
        DatabaseContext ctx = new DatabaseContext();

        //Accounts
        public async Task<List<Category>> GetCategoriesAcyns()
        {
            List<Category> categories = await ctx.categories.ToListAsync();  
            return categories;
        }

        public async Task removeCategoryAsync(Category category)
        {
            ctx.categories.Remove(category);
            await ctx.SaveChangesAsync();
        }

        public async Task addCategoryAsync(Category category)
        {
            bool boolCategoryExists = false;
            foreach (var categoryExists in ctx.categories)
            {
                if (categoryExists.categoryName.Equals(category.categoryName))
                {
                    boolCategoryExists = true;
                }
            }

            if (!boolCategoryExists)
            {
                await ctx.categories.AddAsync(category);
            }
            await ctx.SaveChangesAsync();
        }

        public async Task updateCategoryAsync(Category category)
        {
            ctx.categories.Update(category);
            await ctx.SaveChangesAsync();
        }
    }
}