using Microsoft.AspNetCore.Mvc;
using GameLibrary.Models;

namespace GameLibrary.Controllers
{
	public class HomeController : Controller
	{
		private ILibRepository repository;
		public HomeController(ILibRepository repo)
		{
			repository = repo;
		}
		public IActionResult Index() => View(repository.Game);
	}
}