using Microsoft.Extensions.Options;
using MongoDB.Driver;
using project.Models;
using project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<CakesDBStettings>(
    builder.Configuration.GetSection(nameof(CakesDBStettings)));

builder.Services.AddSingleton<ICakesDBStettings>(sp => 
sp.GetRequiredService<IOptions<CakesDBStettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("CakesDBStettings:ConnectionString")));

builder.Services.AddScoped<ICakesServise,CakesServise>();


builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
