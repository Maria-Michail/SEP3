using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Database.Model
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

        [Required] 
        public BankInfo bankInfo;
        
        public IList<AccountAddress> AccountAddresses { get; set; }
        
        public IList<AccountBankInfo> AccountBankInfos { get; set; }
        

        public Account()
        {
            address = new Address();
            bankInfo = new BankInfo();
        }

    }
}