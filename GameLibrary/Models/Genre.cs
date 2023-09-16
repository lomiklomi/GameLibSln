namespace GameLibrary.Models
{
	public class Genre
	{
		public long? GenreId { get; set; }
		public string Name { get; set; } = String.Empty;
		public IEnumerable<Game>? Games { get; set; }
	}
}
