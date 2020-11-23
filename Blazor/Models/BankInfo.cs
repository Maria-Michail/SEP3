using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Model
{
    public class BankInfo
    {
        [Required]
        [Key]
        [MaxLength(16)]
        [MinLength(16)]
        [JsonPropertyName("CardNumber")]
        public string cardNumber { set; get; }
        
        [Required]
        [JsonPropertyName("CardHolder")]
        public string cardHolder { set; get; }
        
        [Required]
        [Range(0,999)]
        [JsonPropertyName("cvv")]
        public int cvv { set; get; }
        
        [Required]
        [JsonPropertyName("ExpirationDate")]
        public DateTime expirationDate{set; get; }

        public override string ToString()
        {
            return cardHolder + " " + cardNumber + " " + cvv + " " + expirationDate;
        }
    }
}