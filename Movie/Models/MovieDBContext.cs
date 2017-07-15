using System.Data.Entity;
namespace Movie.Models
{
    public class MovieDBContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}