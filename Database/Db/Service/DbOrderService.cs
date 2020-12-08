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
            List<Order> temp = await ctx.orders.ToListAsync();
            return temp;
        }

        public async Task<Order> getOrderAsync(int id)
        {
            Order temp = await ctx.orders.FirstOrDefaultAsync(s => s.orderId == id);
            return temp;
        }

        public async Task addOrderAsync(Order order)
        {
            order.OrderedShopIngredients = new List<OrderedShopIngredients>();
            order.Recipe = ctx.recipes.FirstOrDefault(r => r.recipeId == order.recipeId);
            order.Account = ctx.accounts.FirstOrDefault(a => a.username.Equals(order.username));
            await ctx.orders.AddAsync(order);
            await ctx.SaveChangesAsync();
        }
        
        /*public async Task LinkShop(OrderedShopIngredients shopIngredient, Shop shop)
        {
            ShopIngredient shoping1 = await ctx.shopIngredients.FirstAsync(s => s.id == shopIngredient.id );
            Shop shop1 = await ctx.shops.FirstAsync(c => c.shopId == shop.shopId);
            ShopVare sc2 = new ShopVare()
            {
                shop = shop1,
                shopIngredient = shoping1
            };
            if (shop1.shopVares == null)
            {
                shop1.shopVares = new List<ShopVare>();
            }
            shop1.shopVares.Add(sc2);
            ctx.Update(shop1);
            await ctx.SaveChangesAsync();
        }*/

        public async Task updateOrderAsync(Order order)
        {
            ctx.orders.Update(order);
            await ctx.SaveChangesAsync();
        }

        public async Task removeOrderAsync(Order order)
        {
            ctx.orders.Remove(order);
            await ctx.SaveChangesAsync();
        }
    }
}