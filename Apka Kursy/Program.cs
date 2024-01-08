using Apka_Kursy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Apka_Kursy.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using FluentValidation;
using Apka_Kursy.Models;
using Apka_Kursy.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using NLog.Web;
using System.Text;
using Apka_Kursy.Middlewere;
using System.Security.Cryptography;

namespace Apka_Kursy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //NLog Setup
            builder.Logging.ClearProviders();
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();

            // Add services to the container.


            var authenticationSettings = new AuthenticationSettings();//autentykacja u¿ytkownika

            builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
            builder.Services.AddSingleton(authenticationSettings);
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = "Bearer";
                option.DefaultScheme = "Bearer";
                option.DefaultChallengeScheme = "Bearer";
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = authenticationSettings.JwtIssuer,
                    ValidAudience = authenticationSettings.JwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),

                };
            });//autentykacja u¿ytkownika
            builder.Services.AddControllers().AddFluentValidation();//Validacja danych rejestracji
            builder.Services.AddScoped<ApkaKursySeeder>();//seeder nie dzia³a? 
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ErrorHandlingMiddlewere>();
            builder.Services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();
            builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            builder.Services.AddDbContext<Apka_KursyDBContext>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<ApkaKursySeeder>();

            
            app.UseResponseCaching();
            app.UseStaticFiles();
            app.UseCors("FrondEndClient");
            seeder.Seed();

            app.UseMiddleware<ErrorHandlingMiddlewere>();
            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
