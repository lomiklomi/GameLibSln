using Microsoft.EntityFrameworkCore;
namespace GameLibrary.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			LibDbContext context = app.ApplicationServices
			.CreateScope().ServiceProvider.GetRequiredService<LibDbContext>();
			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}
			if (!context.Games.Any())
			{
				context.Games.AddRange(
				new Game
				{
					Name = "Arma 3",
					Developer = "Bohemia Interactive"
				},
				new Game
				{
					Name = "Valheim",
					Developer = "Iron Gate AB"
				},
				new Game
				{
					Name = "Terraria",
					Developer = "Re-Logic"
				},
				new Game
				{
					Name = "Hades",
					Developer = "Supergiant Games"
				},
				new Game
				{
					Name = "Stardew Valley",
					Developer = "ConcernedApe"
				},
				new Game
				{
					Name = "Baldur's Gate 3",
					Developer = "Larian Studios"
				},
				new Game
				{
					Name = "ELDEN RING",
					Developer = "FromSoftware Inc."
				},
				new Game
				{
					Name = "Little Nightmares 2",
					Developer = "Tarsier Studios"
				},
				new Game
				{
					Name = "Undertale",
					Developer = "tobyfox"
				}
				);
				context.SaveChanges();
			}
		}
	}
}