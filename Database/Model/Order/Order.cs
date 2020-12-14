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
        public int orderId { get; set; }
        
        [Required]
        [NotNull]
        public DateTime dateTime { get; set; }
        
        [Required]
        [NotNull]
        [Range(0.1, Double.MaxValue, ErrorMessage = "number must be above 0.1")]
        public double orderPrice { get; set; }
        
        [Required]
        [NotNull]
        public int recipeId { get; set; } 
        
        [Required]
        [NotNull]
        public string username { get; set; }
        
        [Required]
        public Recipe recipe { get; set; }
        
        [Required]
        public Account account { get; set; }
        
        public IList<OrderedShopIngredients> OrderedShopIngredients { get; set; }
    }
}