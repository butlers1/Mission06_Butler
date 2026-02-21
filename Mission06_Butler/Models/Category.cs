using System.ComponentModel.DataAnnotations;

namespace Mission06_Butler.Models
{
    public class Category
    {
        // Primary Key for the Category table
        [Key]
        [Required]
        public int CategoryId { get; set; }
        // Name of the category, not the number
        [Required]
        public string CategoryName { get; set; } = string.Empty;
    }
}