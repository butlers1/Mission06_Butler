using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Butler.Models
{
    [Table("Movies")] // Ensures it maps to the "Movies" table in Joel's DB [cite: 28]
    public class Movie
    {
        [Key]
        public int? MovieId { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title field required")]
        public string Title { get; set; } = string.Empty;

        // Making this int? allows the [Required] tag to catch empty inputs correctly
        [Required(ErrorMessage = "Year field required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please indicate if the movie has been edited")]
        [Column("Edited")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please indicate if the movie is copied to Plex")]
        [Column("CopiedToPlex")]
        public bool? CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}