using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class ShopIngredient
    {
        [Key]
        [Required]
        [Range(0,int.MaxValue,ErrorMessage = "Id must be over 0")]
        public int id { get; set; }
        
        [Required,MaxLength(128)]
        public string name { get; set; }
        
        [Required]
        [Range(0.1,Double.MaxValue,ErrorMessage = "input must be above 0.1")]
        public double price { get; set; }
        
        [Required]
        [Range(0.1,Double.MaxValue,ErrorMessage = "input must be above 0.1")]
        public double amount { get; set; }
        
        [Required,MaxLength(40)]
        public string unitType { get; set; }
        
        public IList<ShopVare> ShopVares { get; set; }

        public override string ToString()
        {
            return price + "DKK" + " " + name + "[" + id + "]";
        }
    }
}