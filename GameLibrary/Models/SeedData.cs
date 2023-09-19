using Microsoft.EntityFrameworkCore;
namespace GameLibrary.Models
{
	public static class SeedData
	{
		public static void SeedDatabase(LibDbContext context)
		{
			context.Database.Migrate();
			if (context.Game.Count() == 0 && context.Developer.Count() == 0
					&& context.Genre.Count() == 0)
			{

				Developer s1 = new Developer { Name = "Bohemia Interactive" };
				Developer s2 = new Developer { Name = "Iron Gate AB" };
				Developer s3 = new Developer { Name = "Re-Logic" };
				Developer s4 = new Developer { Name = "Supergiant Games" };
				Developer s5 = new Developer { Name = "ConcernedApe" };
				Developer s6 = new Developer { Name = "Larian Studios" };
				Developer s7 = new Developer { Name = "FromSoftware Inc." };
				Developer s8 = new Developer { Name = "Tarsier Studios" };
				Developer s9 = new Developer { Name = "tobyfox" };
				Developer s10 = new Developer { Name = "Activision Blizzard" };
				Developer s11 = new Developer { Name = "Valve" };
				Developer s12 = new Developer { Name = "Riot Games" };


				Genre c1 = new Genre { Name = "Shooter" };
				Genre c2 = new Genre { Name = "Farming Simulator" };
				Genre c3 = new Genre { Name = "Survival" };
				Genre c4 = new Genre { Name = "MMORPG" };
				Genre c5 = new Genre { Name = "RPG" };
				Genre c6 = new Genre { Name = "Autochess" };
				Genre c7 = new Genre { Name = "MOBA" };
				Genre c8 = new Genre { Name = "Roguelike" };
				Genre c9 = new Genre { Name = "Soulslike" };
				Genre c10 = new Genre { Name = "Horror" };
				Genre c11 = new Genre { Name = "2D" };


				context.Game.AddRange(
				new Game
				{
					Name = "Arma 3",
					Developer = s1,
					Genre = c1
				},
				new Game
				{
					Name = "Valheim",
					Developer = s2,
					Genre = c3
				},
				new Game
				{
					Name = "Terraria",
					Developer = s3,
					Genre = c3
				},
				new Game
				{
					Name = "Hades",
					Developer = s4,
					Genre =c8
				},
				new Game
				{
					Name = "Stardew Valley",
					Developer = s5,
					Genre = c2
				},
				new Game
				{
					Name = "Baldur's Gate 3",
					Developer = s6,
					Genre = c5
				},
				new Game
				{
					Name = "ELDEN RING",
					Developer = s7,
					Genre = c5
				},
				new Game
				{
					Name = "Little Nightmares 2",
					Developer = s8,
					Genre = c10
				},
				new Game
				{
					Name = "Undertale",
					Developer = s9,
					Genre = c11
				},
				new Game
				{
					Name = "World of Warcraft",
					Developer = s10,
					Genre = c4
				},
				new Game
				{
					Name = "Dota 2",
					Developer = s11,
					Genre = c6
				},
				new Game
				{
					Name = "League of legend",
					Developer = s12,
					Genre = c6
				},
				new Game
				{
					Name = "CS:GO",
					Developer = s12,
					Genre = c1
				},
				new Game
				{
					Name = "CS:GO 2",
					Developer = s12,
					Genre = c1
				}
				);
				context.SaveChanges();
			}
		}
	}
}