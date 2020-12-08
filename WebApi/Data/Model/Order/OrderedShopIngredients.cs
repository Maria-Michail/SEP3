using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Database.Model.ShopRelated;
using Model;

namespace Database.Model
{
    public class OrderedShopIngredients
    {
        [Key]
        [Required]
        [NotNull]
        public int osId { get; set; }
        
        [Required]
        [JsonPropertyName("TotalPrice")]
        public double totalPrice { get; set; }
        
        [Required]
        [JsonPropertyName("Amount")]
        public int amount { get; set; }
        
        [Required]
        [JsonPropertyName("ShopIngredient")]
        public ShopIngredient ShopIngredient { get; set; }
        
        /*[Required]
        [JsonPropertyName("Order")]
        public Order Order { get; set; }*/

        //public IList<OSIngredients> OsIngredientses { get; set; }

    }
}