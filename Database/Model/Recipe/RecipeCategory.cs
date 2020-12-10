namespace Model
{
    public class RecipeCategory
    {
        public int recipeId { get; set; }
        public Recipe recipe { get; set; }
        public string categoryName { get; set; }
        public Category category { get; set; }
    }
}