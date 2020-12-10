using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Database.Model
{
    public class BankInfo
    {
        [Required]
        [Key]
        [Range(0000000000000000, 9999999999999999)]
        public long cardNumber { set; get; }

        [Required]
        public string cardHolder { set; get; }
        [JsonIgnore]
        public IList<AccountBankInfo> AccountBankInfos { get; set; }


        public override string ToString()
        {
            return cardHolder + " " + cardNumber;
        }
    }
}