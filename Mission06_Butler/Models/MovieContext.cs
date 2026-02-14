using Microsoft.EntityFrameworkCore;

namespace Mission06_Butler.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Category = "Action", Title = "The Dark Knight", Year = 2008, Director = "Christopher Nolan", Rating = "PG-13", Edited = false },
                new Movie { MovieId = 2, Category = "Sci-Fi", Title = "Inception", Year = 2010, Director = "Christopher Nolan", Rating = "PG-13", Edited = false },
                new Movie { MovieId = 3, Category = "Drama", Title = "The Prestige", Year = 2006, Director = "Christopher Nolan", Rating = "PG-13", Edited = false }
            );
        }
    }
}