using Docker.Compose.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Docker.Compose.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async Task ApplyMigrationsAsync(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();

            try {

                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Перед использванием метода MigrateAsync необходимо руками прописать Add-Migration Init
                await context.Database.MigrateAsync();
            }
            catch (Exception exception) {

                var logger = scope.ServiceProvider.GetRequiredService<ILogger<AppDbContext>>();
                logger.LogError(exception, "Error during database migration!");

                throw;
            }
        }
    }
}
