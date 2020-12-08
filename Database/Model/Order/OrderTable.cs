using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Model;

namespace Database.Model.Order
{
    public class OrderTable
    {
        [Key]
        [Required]
        [NotNull]
        [JsonPropertyName("orderId")]
        public int orderId { get; set; }
        
        [Required]
        [NotNull]
        [JsonPropertyName("dateTime")]
        public DateTime dateTime { get; set; }
        
        [Required]
        [NotNull]
        [Range(0.1, Double.MaxValue, ErrorMessage = "number must be above 0.1")]
        [JsonPropertyName("orderPrice")]
        public double orderPrice { get; set; }


        [Required]
        [JsonPropertyName("Account")]
        public Account Account { get; set; }

        public override string ToString()
        {
            return orderId + " " + dateTime + " " + orderPrice + " " + Account.username + " " + Account.email;
        }
    }
}