using Apka_Kursy.Entities;
using Microsoft.EntityFrameworkCore;

namespace Apka_Kursy.IoC;

public static class MigrationExtension
{
    public static void UseDatabaseMigrations(this WebApplication application)
    {
        using (var scope = application.Services.CreateScope())
        {
            var sp = scope.ServiceProvider;
            var logger = sp.GetRequiredService<ILogger<Program>>();

            var dbContext = sp.GetRequiredService<Apka_KursyDBContext>();
            try
            {
                dbContext.Database.SetCommandTimeout(TimeSpan.FromSeconds(300));
                logger.LogInformation("Getting pending migrations...");
                var migrationsToApply = dbContext.Database.GetPendingMigrations();
                logger.LogInformation("Getting pending migrations - Done!");
               
                if (migrationsToApply.Any())
                {
                    logger.LogInformation("Applying migrations: " + String.Join(",", migrationsToApply));
                    dbContext.Database.Migrate();
                    logger.LogInformation("Migration is completed");
                }
                else
                {
                    logger.LogInformation("The database is up to date :)");
                }

            }
            catch (Exception ex)
            {
                logger.LogCritical("DATABASE ERROR: " + ex.Message);
            }
        }
    }
}