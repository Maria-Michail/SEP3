using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Database.Model;
using Database.Model.Order;
using Database.Model.ShopRelated;
using Microsoft.EntityFrameworkCore;
using Model;

namespace Db
{
    public class DbOrderedShopIngreService:IDbOrderedShopIngreService
    {
        DatabaseContext ctx = new DatabaseContext();
        public async Task<List<OrderedIngredient>> getOrderedShopIngredientsAsync()
        {
            List<OrderedIngredient> temp = await ctx.OrderedIngredients.ToListAsync();
            return temp;
        }

        public async Task<OrderedIngredient> getOrderedShopIngredientAsync(int id)
        {
            OrderedIngredient temp = await ctx.OrderedIngredients.FirstOrDefaultAsync(s => s.osId == id);
            return temp;
        }

        public async Task addOrderedShopIngredientAsync(OrderedIngredient ingredient)
        {
            ctx.OrderedIngredients.Add(ingredient);
            await ctx.SaveChangesAsync();
        }
        public async Task addOrderedShopIngredientsAsync(IList<OrderedIngredient> ingredients)
        {
            Console.WriteLine(2);
            foreach (var ing in ingredients)
            {
                Console.WriteLine("inside");
                await ctx.OrderedIngredients.AddAsync(ing);
                await ctx.SaveChangesAsync();
                //await LinkShop(ing);
            }
            await ctx.SaveChangesAsync();
        }
        
        /*public async Task LinkShop(OrderedIngredient ord)
        {
            //OrderedShopIngredients ord = await ctx.orderedShopIngredients.FirstAsync(s => s.osId == orderedShopIngredient.osId );
            Console.WriteLine(ord.ShopIngredient.name);
            ShopIngredient shop = await ctx.shopIngredients.FirstAsync(c => c.name.Equals(ord.ShopIngredient.name));
            Console.WriteLine("frrf");
            OSIngredients sc2 = new OSIngredients()
            {
                orderedShopIngredients = ord,
                shopIngredient = shop
            };
            Console.WriteLine("frvrf");
            if (shop.OsIngredientses == null)
            {
                shop.OsIngredientses = new List<OSIngredients>();
            }
            Console.WriteLine("frrp");
            shop.OsIngredientses.Add(sc2);
            ctx.Update(shop);
            await ctx.SaveChangesAsync();
        }*/

        public async Task updateOrderedShopIngredientAsync(OrderedIngredient ingredient)
        {
            ctx.OrderedIngredients.Update(ingredient);
            await ctx.SaveChangesAsync();
        }

        public async Task removeOrderedShopIngredientAsync(OrderedIngredient ingredient)
        {
            ctx.OrderedIngredients.Remove(ingredient);
            await ctx.SaveChangesAsync();
        }
    }
}