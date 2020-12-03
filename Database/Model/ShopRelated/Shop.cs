using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Database.Model;

namespace Model
{
    public class Shop
    {
        [Key] 
        [Required] 
        [Range(0, int.MaxValue, ErrorMessage = "Id must be above 0")] [JsonPropertyName("Id")]
        public int shopId { get; set; }

        [Required,MaxLength(25)]
        [JsonPropertyName("ShopName")]
        public string shopName { get; set; }
        
        [JsonPropertyName("Vares")]
        public IList<ShopIngredient> vares { get; set; }
        
        [JsonPropertyName("Address")]
        public Address shopAddress { get; set; }
        
        public IList<ShopVare> shopVares { get; set; }

        public override string ToString()
        {
            return shopName + " (" + shopAddress.street + ")";
        }
    }
}