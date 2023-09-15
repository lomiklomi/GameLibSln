namespace GameLibrary.Models
{
	public class EFLibRepository : ILibRepository
	{
		private LibDbContext context;
		public EFLibRepository(LibDbContext ctx)
		{
			context = ctx;
		}
		public IQueryable<Game> Games => context.Games;
	}
}