using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Shop
    {
        [Key]
        [Required,MaxLength(25)]
        [JsonPropertyName("ShopName")]
        public string shopName { get; set; }
        
        [JsonPropertyName("Vares")]
        public IList<ShopIngredient> vares { get; set; }
        
        [JsonPropertyName("Address")]
        public Address shopAddress { get; set; }
    }
}