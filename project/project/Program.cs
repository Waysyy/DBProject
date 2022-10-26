using Microsoft.Extensions.Options;
using MongoDB.Driver;
using project.Models;
using project.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//cakes
builder.Services.Configure<CakesDBStettings>(
    builder.Configuration.GetSection(nameof(CakesDBStettings)));

builder.Services.AddSingleton<ICakesDBStettings>(sp => 
sp.GetRequiredService<IOptions<CakesDBStettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("CakesDBStettings:ConnectionString")));

builder.Services.AddScoped<ICakesServise,CakesServise>();

//clients
builder.Services.Configure<ClientsDBStettings>(
    builder.Configuration.GetSection(nameof(ClientsDBStettings)));

builder.Services.AddSingleton<IClientsDBStettings>(sp =>
sp.GetRequiredService<IOptions<ClientsDBStettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("ClientsDBStettings:ConnectionString")));

builder.Services.AddScoped<IClientsServise, ClientsServise>();
//ingredients
builder.Services.Configure<IngredientsDBStettings>(
    builder.Configuration.GetSection(nameof(IngredientsDBStettings)));

builder.Services.AddSingleton<IIngredientsDBStettings>(sp =>
sp.GetRequiredService<IOptions<IngredientsDBStettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("IngredientsDBStettings:ConnectionString")));

builder.Services.AddScoped<IIngredientsServise, IngredientsServise>();
//Orders
builder.Services.Configure<OrdersDBStettings>(
    builder.Configuration.GetSection(nameof(OrdersDBStettings)));

builder.Services.AddSingleton<IOrdersDBStettings>(sp =>
sp.GetRequiredService<IOptions<OrdersDBStettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("OrdersDBStettings:ConnectionString")));

builder.Services.AddScoped<IOrdersServise, OrdersServise>();
//Personals
builder.Services.Configure<PersonalsDBStettings>(
    builder.Configuration.GetSection(nameof(PersonalsDBStettings)));

builder.Services.AddSingleton<IPersonalsDBStettings>(sp =>
sp.GetRequiredService<IOptions<PersonalsDBStettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("PersonalsDBStettings:ConnectionString")));

builder.Services.AddScoped<IPersonalsServise, PersonalsServise>();

/////////////////////////////////////////////////////////////////
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
