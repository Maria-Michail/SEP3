using Model;

namespace Database.Model.ShopRelated
{
    public class OSIngredients
    {
        public int id;
        public ShopIngredient shopIngredient;
        public int osId;
        public OrderedShopIngredients orderedShopIngredients;
    }
}