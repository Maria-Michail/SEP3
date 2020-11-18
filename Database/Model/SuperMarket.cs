using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class SuperMarket
    {
        [Required]
        [Key]
        [Range(1, int.MaxValue, ErrorMessage = "Must be over 1")]
        [JsonPropertyName("supermarketId")]
        public int supermarkedId { get; set; }
        [Required]
        [Key]
        [Range(1,12, ErrorMessage = "Must be a valid name")]
        [JsonPropertyName("supermarketName")]
        public string name { get; set; }
        
        [Required]
        [JsonPropertyName("address")]
        public string address { get; set; }
        
        [Required]
        [JsonPropertyName("ingredients")]
        public IList<Ingredient> ingredients { get; set; }

        public override string ToString()
        {
            string toReturn = name + "\n" + "Address: " + address + "\n";
            foreach (var VARIABLE in ingredients)
            {
                toReturn = toReturn + VARIABLE.ToString() + "\n";
            }

            return toReturn;
        }
    }
}