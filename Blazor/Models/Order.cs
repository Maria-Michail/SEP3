using System;
using System.Collections.Generic;
using Model;

namespace Database.Model
{
    public class Order
    {
        public int recipeId { get; set; }
        public string userName { get; set; }
        public DateTime dateTime { get; set; }
        
        public IList<OrderedShopIngredients> orderedShopIngredientses { get; set; }

        public int orderId { get; set; }
        public double orderPrice { get; set; }
    }
}