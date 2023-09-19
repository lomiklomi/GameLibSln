using Microsoft.AspNetCore.Mvc;
using GameLibrary.Models;

namespace GameLibrary.Controllers
{
	public class HomeController : Controller
	{
		private LibDbContext context;
		public HomeController(LibDbContext ctx)
		{
			context = ctx;
		}
		public async Task<IActionResult> Index(long id = 1)
		{
			return View(await context.Game.FindAsync(id));
		}
	}
}