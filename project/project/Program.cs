using AspNet.Security.OAuth.Validation;
using DnsClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using project;
using project.Controllers;
using project.Models;
using project.Services;
using System.Security.Cryptography.Xml;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<TokenOperations>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsersServise, UsersServise>();

builder.Services.AddScoped<ICakesServise, CakesServise>();

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

   

        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        // укзывает, будет ли валидироваться издатель при валидации токена
                        ValidateIssuer = true,
                        // строка, представляющая издателя
                        ValidIssuer = Authorization.ISSUER,

                        // будет ли валидироваться потребитель токена
                        ValidateAudience = true,
                        // установка потребителя токена
                        ValidAudience = Authorization.AUDIENCE,
                        // будет ли валидироваться время существования
                        ValidateLifetime = true,

                        // установка ключа безопасности
                        IssuerSigningKey = Authorization.GetSymmetricSecurityKey(),
                        // валидация ключа безопасности
                        ValidateIssuerSigningKey = true,
                    };
                });
            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(options =>
                    {
                        options.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "JWT Token Authentication API",

                        });
                        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                        {
                            Name = "Authorization",
                            Type = SecuritySchemeType.Http,
                            Scheme = "Bearer",
                            BearerFormat = "JWT",
                            In = ParameterLocation.Header,

                        });
                        options.AddSecurityRequirement(new OpenApiSecurityRequirement
                            {
                                {
                                      new OpenApiSecurityScheme
                                        {
                                            Reference = new OpenApiReference
                                            {
                                                Type = ReferenceType.SecurityScheme,
                                                Id = "Bearer"
                                            }
                                        },
                                        new string[] {}
                                }
                            });
                    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
        {

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "dotnetClaimAuthorization v1"));
        }


app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

