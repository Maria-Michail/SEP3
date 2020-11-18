using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Ingredient
    {
        [Key]
        [JsonPropertyName(("ingredientId"))]
        public int ingredientId { get; set; }
        
        [Required]
        [Range(1,12, ErrorMessage = "Name to long")]
        [JsonPropertyName("ingredientName")]
        public string name { get; set; }
        
        [Required]
        [JsonPropertyName("amount")]
        public double amount { get; set; }
        
        [Required]
        [Range(1,5,ErrorMessage = "Must be a valid type")]
        [JsonPropertyName("ingredientType")]
        public string ingredientType { get; set; }

        [JsonPropertyName("price")]
        public double price { get; set; }

        public override string ToString()
        {
            return name + " " + amount + ingredientType;
        }
    }
}