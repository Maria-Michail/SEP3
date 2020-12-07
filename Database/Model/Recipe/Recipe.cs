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
        public int recipeId { get; set; }
        
        [Required]
        [MaxLength(25)]
        public string recipeName { get; set; }
        
        [Required]
        public string description { get; set; }
        
        [Required]
        public string instructions { get; set; }
        
        [Required]
        [Range(1,300,ErrorMessage = "Cooking time must be in min")]
        public double cookingTime { get; set; }
        
        [Required]
        public IList<Ingredient> ingredients { get; set; }
        
        [Required]
        [JsonPropertyName("Imagename")]
        public string imageName { get; set; }
        
        public Category Category { get; set; }
        
        public IList<RecipeCategory> RecipeCategories;
        public IList<IngredientRecipe> IngredientRecipes;
    }
}