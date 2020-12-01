using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Database.Model
{
    public class Address
    {
        [Key]
        [Required,MaxLength(128)]
        [JsonPropertyName("Street")]
        public string street { get; set; }


        [Required,MaxLength(45)]
        [JsonPropertyName("City")]
        public string city { get; set; }
        
        [Required]
        [Range(1000,9999,ErrorMessage = "Must be a danish PostalCode")]
        [JsonPropertyName("ZipCode")]
        public int zipCode { get; set; }
        
        [JsonIgnore]
        public IList<AccountAddress> AccountAddresses { get; set; }

        public override string ToString()
        {
            return street + " " + zipCode + city;
        }
    }
}