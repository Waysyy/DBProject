using Microsoft.Extensions.Options;
using MongoDB.Driver;
using project.Models;
using project.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICakesServise,CakesServise>();

builder.Services.AddScoped<IClientsServise, ClientsServise>();

builder.Services.AddScoped<IIngredientsServise, IngredientsServise>();

builder.Services.AddScoped<IOrdersServise, OrdersServise>();

builder.Services.AddScoped<IPersonalsServise, PersonalsServise>();

builder.Services.Configure<DBStettings>(
    builder.Configuration.GetSection(nameof(DBStettings)));

builder.Services.AddSingleton<IDBStettings>(sp =>
sp.GetRequiredService<IOptions<DBStettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("DBStettings:ConnectionString")));
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
