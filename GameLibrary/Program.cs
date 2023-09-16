using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using GameLibrary.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<LibDbContext>(opts => {
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:GameLibConnection"]);
});

builder.Services.AddScoped<ILibRepository, EFLibRepository>();

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();
