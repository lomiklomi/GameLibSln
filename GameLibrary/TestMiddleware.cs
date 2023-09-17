using GameLibrary.Models;

namespace GameLibrary
{
	public class TestMiddleware
	{
		private RequestDelegate nextDelegate;
		public TestMiddleware(RequestDelegate next)
		{
			nextDelegate = next;
		}
		public async Task Invoke(HttpContext context, LibDbContext dataContext)
		{
			if (context.Request.Path == "/test")
			{
				await context.Response.WriteAsync(
				$"There are {dataContext.Game.Count()} products\n");
				await context.Response.WriteAsync(
				$"There are {dataContext.Genre.Count()} categories\n");
				await context.Response.WriteAsync(
				$"There are {dataContext.Developer.Count()} suppliers\n");
			}
			else
			{
				await nextDelegate(context);
			}
		}
	}
}
