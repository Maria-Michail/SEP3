using Model;

namespace Database.Model.ShopRelated
{
    public class OSIngredients
    {
        public int id { get; set; }
        public ShopIngredient shopIngredient;
        public int osId { get; set; }
        public OrderedShopIngredients orderedShopIngredients;
    }
}