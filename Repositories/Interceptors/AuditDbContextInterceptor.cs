using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace App.Repositories.Interceptors
{
    public class AuditDbContextInterceptor:SaveChangesInterceptor
    {
        private static readonly Dictionary<EntityState, Action<DbContext, IAuditEntity>> Behaviors = new()
        {
            { EntityState.Added, AddBehavior },
            { EntityState.Modified, ModifiedBehavior }

        };

        private static void AddBehavior(DbContext context, IAuditEntity auditEntity)
        {
            auditEntity.CreatedAt = DateTime.Now;
            context.Entry(auditEntity).Property(x => x.UpdatedAt).IsModified = false;
        }
        private static void ModifiedBehavior(DbContext context, IAuditEntity auditUpdatedEntity)
        {
            context.Entry(auditUpdatedEntity).Property(x => x.CreatedAt).IsModified = false;
            auditUpdatedEntity.UpdatedAt = DateTime.Now;
        }


        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entityEntry in eventData.Context!.ChangeTracker.Entries().ToList())
            {

                if (entityEntry.Entity is not IAuditEntity auditEntity) continue;
                Behaviors[entityEntry.State](eventData.Context, auditEntity);

                #region Ilk yol

                //switch (entityEntry.State)
                //{
                //    case EntityState.Added:
                //        if(entityEntry.Entity is IAuditEntity auditEntity)
                //        {
                //            auditEntity.CreatedAt = DateTime.Now;
                //            eventData.Context.Entry(auditEntity).Property(x => x.UpdatedAt).IsModified = false;
                //        }
                //        break;

                //    case EntityState.Modified:
                //        if (entityEntry.Entity is IAuditEntity auditUpdatedEntity)
                //        {
                //            eventData.Context.Entry(auditUpdatedEntity).Property(x => x.CreatedAt).IsModified = false;
                //            auditUpdatedEntity.UpdatedAt = DateTime.Now;
                //        }
                //        break;
                //}   

                #endregion
            }
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
