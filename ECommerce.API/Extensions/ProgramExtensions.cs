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

            // This code : 
            //var dbContext = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
            //var CatalogLogger = scope.ServiceProvider.GetRequiredService<ILogger<CatalogDataSeeder>>();
            //CatalogDataSeeder catalogDataSeeder = new CatalogDataSeeder(dbContext, CatalogLogger);

            // is same as this code, but this code is more flexible and allows for different implementations of IDataSeeder to be used
            var catalogDataSeeder = scope.ServiceProvider.GetRequiredKeyedService<IDataSeeder>("Catalog");

            await catalogDataSeeder.SeedAsync();
        }
    }
}
