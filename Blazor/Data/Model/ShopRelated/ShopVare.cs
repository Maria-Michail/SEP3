namespace Model
{
    public class ShopVare
    {
        public int shopId { get; set; }
        public Shop shop { get; set; }
        public int shopIngredientId { get; set; }
        public ShopIngredient shopIngredient { get; set; }

        public override string ToString()
        {
            return shopId + " " + shopIngredientId;
        }
    }
}