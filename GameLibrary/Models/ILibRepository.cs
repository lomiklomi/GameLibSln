namespace GameLibrary.Models
{
	public interface ILibRepository
	{
		IQueryable<Game> Games { get; }
	}
}