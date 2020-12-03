using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Database.Model;

namespace Model
{
    public class Delivery
    {
        [Key]
        [Required]
        [Range(0,int.MaxValue, ErrorMessage = "Id must be above 0")]
        [JsonPropertyName("Id")]
        public int deliveryId { get; set; }

        [Required, MaxLength(8)]
        [JsonPropertyName("Date")]
        public string date { get; set; }
        
        [Required]
        [Range(0,int.MaxValue, ErrorMessage = " Cost must be above 0")]
        [JsonPropertyName("Cost")]
        public double cost { get; set; }

        [Required] 
        [JsonPropertyName("Recipe")]
        public Recipe Recipe;

        [Required] 
        [JsonPropertyName("Payment")]
        public BankInfo BankInfo;
    }
}