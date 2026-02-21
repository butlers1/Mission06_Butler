using Microsoft.EntityFrameworkCore;

namespace Mission06_Butler.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        // Db for category and movie table
        public DbSet<Category> Categories { get; set; }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            // fills the category table with the following data
            mb.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Action" },
                new Category { CategoryId = 2, CategoryName = "Comedy" },
                new Category { CategoryId = 3, CategoryName = "Drama" },
                new Category { CategoryId = 4, CategoryName = "Family" },
                new Category { CategoryId = 5, CategoryName = "Horror/Suspense" },
                new Category { CategoryId = 6, CategoryName = "Miscellaneous" },
                new Category { CategoryId = 7, CategoryName = "Television" },
                new Category { CategoryId = 8, CategoryName = "VHS" }
            );
        }
    }
}