using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Recipe
    {    
        [Key]
        [Required, MaxLength(25)]
        [JsonPropertyName("recipeName")]
        public string name { get; set; }
        
        [JsonPropertyName("Instructions")]
        public string instructions { get; set; }
        
        [Required]
        [Range(0.1,Double.MaxValue,ErrorMessage = "Cooking time must be in hour/min above 0.1")]
        public double cookingTime { get; set; }
        
        [Required]
        [JsonPropertyName("ingredients")]
        public IList<Ingredient> ingredients { get; set; }
        
        [JsonPropertyName("Category")]
        public Category Category { get; set; }
    }
}