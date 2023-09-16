using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace GameLibrary.Models
{
	public class Game
	{
		public long? GameId { get; set; }
		public string Name { get; set; } = String.Empty;

		public long DeveloperId { get; set; }
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public Developer Developer { get; set; } = new Developer();

		public long GenreId { get; set; }
		public Genre Genre { get; set; } = new Genre();
	}
}