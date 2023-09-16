using Microsoft.EntityFrameworkCore;
namespace GameLibrary.Models
{
	public class LibDbContext : DbContext
	{
		public LibDbContext(DbContextOptions<LibDbContext> options)
			: base(options) { }
		public DbSet<Game> Game => Set<Game>();
		public DbSet<Genre> Genre => Set<Genre>();
		public DbSet<Developer> Developer => Set<Developer>();
	}
}