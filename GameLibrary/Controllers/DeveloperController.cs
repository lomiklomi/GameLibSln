using Microsoft.AspNetCore.Mvc;
using GameLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace GameLibrary.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class DeveloperController : ControllerBase
	{
		private LibDbContext context;
		public DeveloperController(LibDbContext ctx)
		{
			context = ctx;
		}
		[HttpGet("{id}")]
		public async Task<Developer?> GetDeveloper(long id)
		{
			Developer developer = await context.Developer.Include(s => s.Games)
				.FirstAsync(s => s.DeveloperId == id);
			if (developer.Games != null)
			{
				foreach (Game p in developer.Games)
				{
					p.Developer = null;
				};
			}
			return developer;
		}

		[HttpPatch("{id}")]
		public async Task<Developer?> PatchDeveloper(long id,
			JsonPatchDocument<Developer> patchDoc)
		{
			Developer? s = await context.Developer.FindAsync(id);
			if (s != null)
			{
				patchDoc.ApplyTo(s);
				await context.SaveChangesAsync();
			}
			return s;
		}
	}
}