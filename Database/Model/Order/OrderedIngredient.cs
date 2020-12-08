using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Model;

namespace Database.Model.Order
{
    public class OrderedIngredient
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
        
        [Required]
        [JsonPropertyName("OrderTable")]
        public OrderTable OrderTable { get; set; }
    }
}