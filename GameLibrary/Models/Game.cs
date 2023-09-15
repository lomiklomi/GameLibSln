using System.ComponentModel.DataAnnotations.Schema;
namespace GameLibrary.Models
{
	public class Game
	{
		public long? GameID { get; set; }
		public string Name { get; set; } = String.Empty;
		public string Developer { get; set; } = String.Empty;
	}
}