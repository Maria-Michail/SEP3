using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Database.Model
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
        
       

        public override string ToString()
        {
            return cardHolder + " " + cardNumber;
        }
    }
}