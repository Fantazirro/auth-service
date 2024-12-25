using AuthService.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AuthService.Persistence.Interceptors
{
    internal class AuditInterceptor : SaveChangesInterceptor
    {
        private const string ModifiedBy = "%SYSTEM%";

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            var dbContext = eventData.Context;
            if (dbContext is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var entries = dbContext.ChangeTracker.Entries<IAuditable>();

            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property(a => a.CreatedBy).CurrentValue = ModifiedBy;
                    entry.Property(a => a.CreatedOnUtc).CurrentValue = DateTimeOffset.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property(a => a.LastModifiedBy).CurrentValue = ModifiedBy;
                    entry.Property(a => a.LastModifiedOnUtc).CurrentValue = DateTimeOffset.UtcNow;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}