namespace Model
{
    public class IngredientRecipe
    {
        public int recipeId { get; set; }
        public Recipe recipe { get; set; }
        public int ingredientId { get; set; }
        public Ingredient ingredient { get; set; }
    }
}