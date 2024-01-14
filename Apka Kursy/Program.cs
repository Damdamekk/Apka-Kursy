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
using Apka_Kursy.IoC;

namespace Apka_Kursy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Logger
            //NLog Setup
            builder.Logging.ClearProviders();//Logi
            builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            builder.Host.UseNLog();
            #endregion Logger
            
            #region Authentication
            var authenticationSettings = new AuthenticationSettings();//autentykacja u�ytkownika

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
            });//autentykacja uzytkownika
            #endregion Authentication

            #region Application IoC
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();//Validacja danych rejestracji
            builder.Services.AddScoped<ApkaKursySeeder>();//seeder nie dzia�a? 
            builder.Services.AddScoped<IAccountService, AccountService>();
            builder.Services.AddScoped<ICoursesService, CourseService>();
            builder.Services.AddScoped<IImageService, ImageService>();
            builder.Services.AddScoped<ErrorHandlingMiddlewere>();
            builder.Services.AddScoped<IPasswordHasher<Users>, PasswordHasher<Users>>();
            builder.Services.AddScoped<IValidator<RegisterUserDto>, RegisterUserDtoValidator>();
            builder.Services.AddDbContext<Apka_KursyDBContext>();
            builder.Services.AddSwaggerGen();
            #endregion Application IoC

            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("FrontEndClient", corsPolicyBuilder =>
                {
                    corsPolicyBuilder.WithOrigins("http://localhost:8000")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            }); ;
            #endregion
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            var scope = app.Services.CreateScope();
            var seeder = scope.ServiceProvider.GetRequiredService<ApkaKursySeeder>();

            #region Connector Database migrations
            app.UseDatabaseMigrations();
            #endregion
            
            app.UseResponseCaching();
            app.UseStaticFiles();
            app.UseCors("FrondEndClient");
            seeder.Seed();

            app.UseMiddleware<ErrorHandlingMiddlewere>();
            app.UseAuthentication();
            app.UseHttpsRedirection();

            #region UseSwagger
            app.UseSwagger();
            app.UseSwaggerUI(
                c => { 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApkaKursAPI");
            });
            #endregion UseSwagger
            
            app.UseAuthorization();
            app.MapControllers();
            
            app.Run();
        }
    }
}
