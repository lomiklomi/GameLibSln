using System.ComponentModel.DataAnnotations;

namespace GameLibrary.Models
{
	public class GameBindingTarget
	{
		[Required]
		public string Name { get; set; } = "";
		[Range(1, long.MaxValue)]
		public long GenreId { get; set; }
		[Range(1, long.MaxValue)]
		public long DeveloperId { get; set; }
		public Game ToGame() => new Game()
		{
			Name = this.Name,
			GenreId = this.GenreId,
			DeveloperId = this.DeveloperId
		};
	}
}
