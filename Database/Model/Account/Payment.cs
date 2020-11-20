using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Newtonsoft.Json.Serialization;

namespace Model
{
    public class Payment
    {
        [Key]
        [Required]
        [Range(16,16,ErrorMessage = "Must be 16 in digits")]
        [JsonPropertyName("CardNumber")]
        public int cardNumber { get; set; }
        
        [Required, MaxLength(5), MinLength(5)]
        [JsonPropertyName("ExpirationDate")]
        public string expirationDate { get; set; }
        
        [Required]
        [Range(4,4,ErrorMessage = "Must be a 4 number digit")]
        [JsonPropertyName("RegNum")]
        public int regNumber { get; set; }
        
        [Required]
        [Range(10,10,ErrorMessage = "Must be a 10 digit number")]
        [JsonPropertyName("KontoNumb")]
        public int kontoNumb { get; set; }
        
        [Required]
        [Range(3,3,ErrorMessage = "Must be a 3 digit number")]
        [JsonPropertyName("CVV")]
        public int cvv { get; set; }

        [Required]
        [MaxLength(64)]
        [JsonPropertyName("CardHolder")]
        public string cardHolder { get; set; }
    }
}