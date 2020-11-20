using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Account {

        [Required]
        [Key]
        [MaxLength(12)]
        [JsonPropertyName("username")]
        public string username{get; set;}

        [Required]
        [MaxLength(12)]
        [JsonPropertyName("password")]
        public string password{get;set;}

        [Required]
        [JsonPropertyName("email")]
        public string email{get;set;}

        [Required]
        public Address address;

        public Account()
        {
            address = new Address();
        }

    }
}