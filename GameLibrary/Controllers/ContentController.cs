using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameLibrary.Models;

namespace GameLibrary.Controllers
{
	[ApiController]
	[Route("/api/[controller]")]
	public class ContentController : ControllerBase
	{
		private LibDbContext context;
		public ContentController(LibDbContext dataContext)
		{
			context = dataContext;
		}
		[HttpGet("string")]
		public string GetString() => "This is a string response";

		[HttpGet("object/{format?}")]
		[FormatFilter]
		[Produces("application/json", "application/xml")]
		public async Task<GameBindingTarget> GetObject()
		{
			Game p = await context.Game.FirstAsync();
			return new GameBindingTarget()
			{
				Name = p.Name,
				DeveloperId = p.DeveloperId,
				GenreId = p.GenreId
			};
		}

		[HttpPost]
		[Consumes("application/json")]
		public string SaveGameJson(GameBindingTarget game)
		{
			return $"JSON: {game.Name}";
		}
		/*[HttpPost]
		[Consumes("application/xml")]
		public string SaveGameXml(GameBindingTarget game)
		{
			return $"XML: {game.Name}";
		}*/
	}
}
