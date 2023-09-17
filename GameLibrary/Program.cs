using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using GameLibrary.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
//using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibDbContext>(opts => {
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:GameLibConnection"]);
	opts.EnableSensitiveDataLogging(true);
});

builder.Services.AddControllers()
	.AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Services.Configure<MvcNewtonsoftJsonOptions>(opts => {
	opts.SerializerSettings.NullValueHandling
		= Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.Configure<MvcOptions>(opts => {
	opts.RespectBrowserAcceptHeader = true;
	opts.ReturnHttpNotAcceptable = true;
});
/*builder.Services.Configure<JsonOptions>(opts => {
	opts.JsonSerializerOptions.DefaultIgnoreCondition
		= JsonIgnoreCondition.WhenWritingNull;
});*/

builder.Services.AddSwaggerGen(c => {
	c.SwaggerDoc("v1", new OpenApiInfo { Title = "GameLib", Version = "v1" });
});

var app = builder.Build();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.UseSwagger();
app.UseSwaggerUI(options => {
	options.SwaggerEndpoint("/swagger/v1/swagger.json", "GameLib");
});

var context = app.Services.CreateScope().ServiceProvider
	.GetRequiredService<LibDbContext>();

SeedData.SeedDatabase(context);

app.Run();
