using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database.Model
{
    public class Account {

        [Required]
        [Key]
        [Range(1,12,ErrorMessage = "Username to long")]
        [JsonPropertyName("username")]
        public string username{get; set;}

        [Required]
        [Range(3,20, ErrorMessage = "Password must be between 4-20 characters")]
        [JsonPropertyName("password")]
        public string password{get;set;}

        [Required]
        [JsonPropertyName("email")]
        public string email{get;set;}
    }
}