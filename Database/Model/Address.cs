using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Address
    {
        [Key]
        [Required,MaxLength(128)]
        [JsonPropertyName("Street")]
        public string street { get; set; }
        
        [Key]
        [Required,MaxLength(128)]
        [JsonPropertyName("StreetNumber")]
        public string streetNumber { get; set; }
        
        [Required,MaxLength(45)]
        [JsonPropertyName("City")]
        public string city { get; set; }
        
        [Required]
        [Range(1000,9999,ErrorMessage = "Must be a danish PostalCode")]
        [JsonPropertyName("ZipCode")]
        public int zipCode { get; set; }

        public override string ToString()
        {
            return streetNumber + " " + street + " " + zipCode + city;
        }
    }
}