using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Recipe
    {
        [Required]
        [Key]
        [Range(1,int.MaxValue, ErrorMessage = "Must be bigger than {1}")]
        [JsonPropertyName("")]
        public int recipeId { get; set;}
        
        [Required, MaxLength(25)]
        [JsonPropertyName("recipeName")]
        public string name { get; set; }
        
        [Required]
        [JsonPropertyName("ingredients")]
        public IList<Ingredient> ingredients { get; set; }

        public void Recipy(List<Ingredient> ingredients)
        {
            this.ingredients = ingredients;
        }

        public override string ToString()
        {
            string toReturn = name + "\n";
            foreach (var VARIABLE in ingredients)
            {
                toReturn = toReturn + VARIABLE.ToString();
                toReturn = toReturn + "\n";
            }

            return toReturn;
        }
    }
}