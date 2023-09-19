using Microsoft.AspNetCore.Mvc;
using GameLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.JsonPatch;

namespace GameLibrary.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GenreController : ControllerBase
	{
		private LibDbContext context;
		public GenreController(LibDbContext ctx)
		{
			context = ctx;
		}
		[HttpGet("{id}")]
		public async Task<Genre?> GetGenre(long id)
		{
			Genre genre = await context.Genre.Include(s => s.Games)
				.FirstAsync(s => s.GenreId == id);
			if (genre.Games != null)
			{
				foreach (Game p in genre.Games)
				{
					p.Genre = null;
				};
			}
			return genre;
		}

		[HttpPatch("{id}")]
		public async Task<Genre?> PatchGenre(long id,
			JsonPatchDocument<Genre> patchDoc)
		{
			Genre? s = await context.Genre.FindAsync(id);
			if (s != null)
			{
				patchDoc.ApplyTo(s);
				await context.SaveChangesAsync();
			}
			return s;
		}
	}
}
