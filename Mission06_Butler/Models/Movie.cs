using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Butler.Models
{
    [Table("Movies")] // Goes to the movies table in the db
    public class Movie
    {
        // Primary Key for Movie table
        [Key]
        public int? MovieId { get; set; }

        // Requirement for Category field
        [Required(ErrorMessage = "Please select a category")]
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // Requirement for Title field
        [Required(ErrorMessage = "Title field required")]
        public string Title { get; set; } = string.Empty;

        // Requirement for Year field, must be 1888 or later
        [Required(ErrorMessage = "Year field required")]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later")]
        public int? Year { get; set; }

        public string? Director { get; set; }

        public string? Rating { get; set; }

        // Requirement for Edited field, must be true or false
        [Required(ErrorMessage = "Please indicate if the movie has been edited")]
        [Column("Edited")]
        public bool? Edited { get; set; }

        public string? LentTo { get; set; }

        // Requirement for CopiedToPlex field, must be true or false
        [Required(ErrorMessage = "Please indicate if the movie is copied to Plex")]
        [Column("CopiedToPlex")]
        public bool? CopiedToPlex { get; set; }

        [MaxLength(25)]
        public string? Notes { get; set; }
    }
}