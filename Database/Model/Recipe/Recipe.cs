using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Recipe
    {    
        [Key]
        [Required]
        [JsonPropertyName("-IdRecipe")]
        public int recipeId { get; set; }
        
        [Required]
        [MaxLength(25)]
        [JsonPropertyName("RecipeName")]
        public string recipeName { get; set; }
        
        [Required]
        [JsonPropertyName("Description")]
        public string description { get; set; }
        
        [Required]
        [JsonPropertyName("Instructions")]
        public string instructions { get; set; }
        
        [Required]
        [Range(1,300,ErrorMessage = "Cooking time must be in min")]
        [JsonPropertyName("CookingTime")]
        public int cookingTime { get; set; }
        
        [Required]
        [JsonPropertyName("Ingredients")]
        public IList<Ingredient> ingredients { get; set; }
        
        [Required]
        [JsonPropertyName("Imagename")]
        public string imageName { get; set; }
        
        [JsonPropertyName("Category")]
        public Category Category { get; set; }
        
        public IList<RecipeCategory> RecipeCategories;
        public IList<IngredientRecipe> IngredientRecipes;
    }
}