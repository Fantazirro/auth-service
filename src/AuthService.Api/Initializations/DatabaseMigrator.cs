using AuthService.Persistence;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Api.Initializations
{
    public static class DatabaseMigrator
    {
        public static void ApplyMigration(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AuthDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}