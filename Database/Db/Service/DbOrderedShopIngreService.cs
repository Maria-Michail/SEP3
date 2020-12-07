using System;
using System.Collections.Generic;
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
        public async Task<List<OrderedShopIngredients>> getOrderedShopIngredientsAsync()
        {
            List<OrderedShopIngredients> temp = await ctx.orderedShopIngredients.ToListAsync();
            return temp;
        }

        public async Task<OrderedShopIngredients> getOrderedShopIngredientAsync(int id)
        {
            OrderedShopIngredients temp = await ctx.orderedShopIngredients.FirstOrDefaultAsync(s => s.osId == id);
            return temp;
        }

        public async Task addOrderedShopIngredientAsync(OrderedShopIngredients ingredient)
        {
            List<OrderedShopIngredients> temp = await ctx.orderedShopIngredients.ToListAsync();
            int id = temp.Count;
            ingredient.osId = id;
            ctx.orderedShopIngredients.Add(ingredient);
            await ctx.SaveChangesAsync();
        }
        public async Task addOrderedShopIngredientsAsync(IList<OrderedShopIngredients> ingredients)
        {
            Console.WriteLine(2);
            foreach (var ing in ingredients)
            {
                Console.WriteLine("inside");
                await ctx.orderedShopIngredients.AddAsync(ing);
                await ctx.SaveChangesAsync();
                await LinkShop(ing);
            }
            await ctx.SaveChangesAsync();
        }
        
        public async Task LinkShop(OrderedShopIngredients ord)
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
        }

        public async Task updateOrderedShopIngredientAsync(OrderedShopIngredients ingredient)
        {
            ctx.orderedShopIngredients.Update(ingredient);
            await ctx.SaveChangesAsync();
        }

        public async Task removeOrderedShopIngredientAsync(OrderedShopIngredients ingredient)
        {
            ctx.orderedShopIngredients.Remove(ingredient);
            await ctx.SaveChangesAsync();
        }
    }
}