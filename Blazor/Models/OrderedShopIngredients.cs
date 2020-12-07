using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Model;

namespace Database.Model
{
    public class OrderedShopIngredients
    {
        [Required]
        [JsonPropertyName("TotalPrice")]
        public double totalPrice { get; set; }

        [Required]
        [JsonPropertyName("Amount")]
        public double amount { get; set; }

        [Required]
        [JsonPropertyName("ShopIngredients")]
        public ShopIngredient ingredient { get; set; }
    }
}

