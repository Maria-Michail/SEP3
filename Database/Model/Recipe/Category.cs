using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Model
{
    public class Category
    {
        [Key]
        [Required]
        [MaxLength(64)]
        public string categoryName { get; set; }
        
        public IList<RecipeCategory> RecipeCategories;
    }
}