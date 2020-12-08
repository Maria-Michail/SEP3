using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Database.Model.ShopRelated;

namespace Model
{
    public class ShopIngredient
    {
        [Key]
        [Required]
        [Range(0,int.MaxValue,ErrorMessage = "Id must be over 0")]
        [JsonPropertyName("ShopIngrId")]
        public int id { get; set; }
        
        [Required,MaxLength(128)]
        [JsonPropertyName("Name")]
        public string name { get; set; }
        
        [Required]
        [Range(0.1,Double.MaxValue,ErrorMessage = "input must be above 0.1")]
        [JsonPropertyName("Price")]
        public double price { get; set; }
        
        [Required]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Number must be above 0.1")]
        [JsonPropertyName("Amount")]
        public double amount { get; set; }
        

        [Required,MaxLength(40)]
        [JsonPropertyName("UnitType")]
        public string unitType { get; set; }

        public IList<ShopVare> shopVares { get; set; }

        public override string ToString()
        {
            return price + "DKK" + " " + name;
        }
    }
}