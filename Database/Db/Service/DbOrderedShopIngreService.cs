using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database.Model;
using Database.Model.ShopRelated;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbOrderedShopIngreService:IDbOrderedShopIngreService
    {
        DatabaseContext ctx = new DatabaseContext();
        
        public async Task addOrderedShopIngredientsAsync(IList<OrderedShopIngredients> ingredients, Order order)
        {
            foreach (var ing in ingredients)
            {
                Console.WriteLine("here1");
                ing.shopIngredient = ctx.shopIngredients.FirstOrDefault(c => c.id == ing.shopIngredient.id);
                Console.WriteLine("here2");
                ing.order = ctx.orders.FirstOrDefault(o => o.orderId == order.orderId);
                Console.WriteLine("here3");
                await ctx.orderedShopIngredients.AddAsync(ing);
                await ctx.SaveChangesAsync();
                Console.WriteLine("here");
                //await LinkShop(ing);
            }
            await ctx.SaveChangesAsync();
        }
        
        
    }
}