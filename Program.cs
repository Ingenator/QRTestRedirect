using Microsoft.AspNetCore.Http.Headers;
using System.Net;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/viveTlayacapanDev", (context) =>
{
	context.Response.Redirect("https://vivetlayacapan.azurewebsites.net/");
	return Task.CompletedTask;
});

app.MapGet("/viveTlayacapan", (context) =>
{
	context.Response.Redirect("https://vivetlayacapan.com/");
	return Task.CompletedTask;
});


app.Run();


