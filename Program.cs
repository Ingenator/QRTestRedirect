using Microsoft.AspNetCore.Http.Headers;
//using MixPanelHttpClient;
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

var client = new Mixpanel.MixpanelClient("8255ab531142f1adb3521c57407c4ae5");

app.MapGet("/viveTlayacapanDev", (context) =>
{
	client.TrackAsync("QR_DEV", new
	{		
		prop = "prueba",
	});
	context.Response.Redirect("https://vivetlayacapan.azurewebsites.net/");	
	return Task.CompletedTask;
});

app.MapGet("/viveTlayacapan", (context) =>
{
	client.TrackAsync("QR_Lona", null);
	context.Response.Redirect("https://vivetlayacapan.com/");
	return Task.CompletedTask;
});

app.MapGet("/etapauno", (context) =>
{
	client.TrackAsync("QR_Flyer", null);
	context.Response.Redirect("https://vivetlayacapan.com/");
	return Task.CompletedTask;
});


app.Run();


