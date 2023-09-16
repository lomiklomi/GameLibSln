namespace GameLibrary.Models
{
	public class Developer
	{
		public long? DeveloperID { get; set; }
		public string Name { get; set; } = String.Empty;
		public IEnumerable<Game>? Games { get; set; }
	}
}
