using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Ingredient
    {
        [Key]
        [JsonPropertyName(("IngredientId"))]
        public int ingredientId { get; set; }
        

        [Required,MaxLength(128)]
        [JsonPropertyName("IngredientName")]
        public string ingredientName { get; set; }
        
        [Required]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Number must be above 0.1")]
        [JsonPropertyName("number")]
        public double number { get; set; }
        

        [Required,MaxLength(128)]
        public string unitType { get; set; }

        public IList<IngredientRecipe> IngredientRecipes;

        public override string ToString()
        {
            return "Ingredient: " + ingredientName;
        }
    }
}