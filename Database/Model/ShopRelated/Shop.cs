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
        [Range(0, int.MaxValue, ErrorMessage = "Id must be above 0")]
        public int shopId { get; set; }
        
        [Required,MaxLength(25)]
        public string shopName { get; set; }

        public IList<ShopIngredient> vares { get; set; }
        
        public Address shopAddress { get; set; }
        
        public IList<ShopVare> shopVares { get; set; }
        
        public override string ToString()
        {
            return shopName + " (" + shopAddress.street + "/" + shopAddress.zipCode + "/" + shopAddress.city +")" + "[" + shopId + "]";
        }
    }
}