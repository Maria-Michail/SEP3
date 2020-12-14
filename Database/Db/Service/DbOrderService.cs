using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Model;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbOrderService:IDbOrderService
    {
        DatabaseContext ctx = new DatabaseContext();
        public async Task<List<Order>> getOrdersAsync()
        {
            List<Order> temp = await ctx.orders.Include(o => o.recipe).Include(o=>o.account).Include(o=>o.recipe.category).ToListAsync();
            return temp;
        }


        public async Task addOrderAsync(Order order)
        {
            order.OrderedShopIngredients = new List<OrderedShopIngredients>();
            order.recipe = ctx.recipes.FirstOrDefault(r => r.recipeId == order.recipeId);
            order.account = ctx.accounts.FirstOrDefault(a => a.username.Equals(order.username));
            await ctx.orders.AddAsync(order);
            await ctx.SaveChangesAsync();
        }
        

    }
}
