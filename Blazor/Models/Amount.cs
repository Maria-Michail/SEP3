using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Amount
    {
        [Required]
        [Key]
        [Range(0.1, Double.MaxValue, ErrorMessage = "Number must be above 0.1")]
        [JsonPropertyName("number")]
        public double number { get; set; }
        

        [Required,MaxLength(128)]
        public string unitType { get; set; }

        public override string ToString()
        {
            return number + unitType;
        }
    }
}