namespace GameLibrary.Models
{
	public class Developer
	{
		public long DeveloperId { get; set; }
		public string Name { get; set; } = String.Empty;
		public IEnumerable<Game>? Games { get; set; }
	}
}
