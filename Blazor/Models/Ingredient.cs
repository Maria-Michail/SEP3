using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Ingredient
    {
        [Key]
        [JsonPropertyName(("ingredientId"))]
        public int ingredientId { get; set; }
        

        [Required,MaxLength(128)]
        [JsonPropertyName("ingredientName")]
        public string name { get; set; }
        
        [Required]
        [JsonPropertyName("Amount")]
        public Amount Amount { get; set; }

        public override string ToString()
        {
            return "Ingredient: " + name + Amount;
        }
    }
}