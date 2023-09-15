using Microsoft.EntityFrameworkCore;
namespace GameLibrary.Models
{
	public class LibDbContext : DbContext
	{
		public LibDbContext(DbContextOptions<LibDbContext> options)
			: base(options) { }
		public DbSet<Game> Games => Set<Game>();
	}
}