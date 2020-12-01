using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Category
    {
        [Key]
        [Required]
        [JsonPropertyName("Category")]
        [MaxLength(64)]
        public string category { get; set; }
    }
}