using Microsoft.AspNetCore.Mvc;
using GameLibrary.Models;

namespace GameLibrary.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GameController : ControllerBase
	{
		private LibDbContext context;

		public GameController(LibDbContext ctx)
		{
			context = ctx;
		}
		[HttpGet]
		public IAsyncEnumerable<Game> GetGames()
		{
			return context.Game.AsAsyncEnumerable();
		}

		[HttpGet("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetGame(long id)
		{
			Game? p = await context.Game.FindAsync(id);
			if (p == null)
			{
				return NotFound();
			}

			return Ok(p);
		}

		[HttpPost]
		public async Task<IActionResult>
			SaveProduct(GameBindingTarget target)
		{
			Game p = target.ToGame();
			await context.Game.AddAsync(p);
			await context.SaveChangesAsync();
			return Ok(p);
		}

		[HttpPut]
		public async Task UpdateGame(Game game)
		{
			context.Game.Update(game);
			await context.SaveChangesAsync();
		}

		[HttpDelete("{id}")]
		public async Task DeleteGame(long id)
		{
			context.Game.Remove(new Game() { GameId = id });
			await context.SaveChangesAsync();
		}

		[HttpGet("redirect")]
		public IActionResult Redirect()
		{
			return RedirectToAction(nameof(GetGame), new { Id = 1 });
		}
	}
}
