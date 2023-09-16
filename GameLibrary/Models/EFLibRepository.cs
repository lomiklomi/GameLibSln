namespace GameLibrary.Models
{
	public class EFLibRepository : ILibRepository
	{
		private LibDbContext context;
		public EFLibRepository(LibDbContext ctx)
		{
			context = ctx;
		}
		public IQueryable<Game> Game => context.Game;
		public IQueryable<Genre> Genre => context.Genre;
		public IQueryable<Developer> Developer => context.Developer;
	}
}