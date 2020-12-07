using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Database.Model;
using Database.Model.ShopRelated;

namespace Model
{
    public class Order
    {
        [Key]
        [Required]
        [NotNull]
        [JsonPropertyName("orderId")]
        public int orderId { get; set; }
        
        [Required]
        [NotNull]
        [JsonPropertyName("dateTime")]
        public DateTime dateTime { get; set; }
        
        [Required]
        [NotNull]
        [Range(0.1, Double.MaxValue, ErrorMessage = "number must be above 0.1")]
        [JsonPropertyName("orderPrice")]
        public double orderPrice { get; set; }
        
        [ForeignKey("recipeId")]
        [Required]
        [NotNull]
        public int recipeId { get; set; } 
        
        [ForeignKey("userName")]
        [Required]
        [NotNull]
        public string userName { get; set; }
        
        [JsonPropertyName("OrderedShopIngredients")]
        public IList<OrderedShopIngredients> OrderedShopIngredients { get; set; }
    }
}