using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database.Model
{
    public class Account {

        [Required]
        [Key]
        [JsonPropertyName("accountId")]
        public int id{get;set;}

        [Required]
        [Range(1,12,ErrorMessage = "Username to long")]
        [JsonPropertyName("username")]
        public string username{get; set;}

        [Required]
        [Range(4,20, ErrorMessage = "Password must be between 4-20 characters")]
        [JsonPropertyName("password")]
        public string password{get;set;}

        [Range(2,5, ErrorMessage = "Must be a valid name")]
        [JsonPropertyName("firstName")]
        public string firstName{get;set;}

        [Range(2,5, ErrorMessage = "Must be a valid name")]
        [JsonPropertyName("lastName")]
        public string lastName{get;set;}

        [Range(15,99, ErrorMessage = "User must be older then 15 years")]
        [JsonPropertyName("age")]
        public int age{get;set;}

        [MaxLength(40)]
        [JsonPropertyName("streetName")]
        public string streetName{get;set;}

        [MaxLength(10)]
        [JsonPropertyName("houseNumber")]
        public string houseNumber{get;set;}

        [Range(1000,9999, ErrorMessage = "Must be a danish postalNumber")]
        [JsonPropertyName("postNumber")]
        public int postNumber{get;set;}
    }
}