using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Model
{
    public class Address
    {
        [Key, Column(Order = 0)]
        [Required,MaxLength(128)]
        [JsonPropertyName("Street")]
        public string street { get; set; }
        
        [Key, Column(Order = 1)]
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