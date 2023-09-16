namespace GameLibrary.Models
{
	public interface ILibRepository
	{
		IQueryable<Game> Game { get; }
		IQueryable<Genre> Genre { get; }
		IQueryable<Developer> Developer { get; }
	}
}