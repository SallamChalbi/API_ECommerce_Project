using ECommerce.Domain.Contracts;
using ECommerce.Infrastructure.Data;
using ECommerce.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.API.Extensions
{
    public static class ProgramExtensions
    {
        public static async Task MigrateAndSeedAsync(this WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            
            //var CatalogLogger = scope.ServiceProvider.GetRequiredService<ILogger<CatalogDataSeeder>>();
            //var pending = await dbContext.Database.GetAppliedMigrationsAsync();

            //if(pending.Count() > 0)
            //    await dbContext.Database.MigrateAsync();

            await dbContext.Database.MigrateAsync();

            //CatalogDataSeeder catalogDataSeeder = new CatalogDataSeeder(dbContext, CatalogLogger);
            var catalogDataSeeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");

            await catalogDataSeeder.SeedAsync();
        }
    }
}
