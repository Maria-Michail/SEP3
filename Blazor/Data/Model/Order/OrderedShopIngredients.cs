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
        public double totalPrice { get; set; }
        
        [Required]
        public int amount { get; set; }
        
        [Required]
        public ShopIngredient shopIngredient { get; set; }

        public bool uncheck { get; set; } = true;

        /*[Required]
        public Order order { get; set; }*/

    }
}