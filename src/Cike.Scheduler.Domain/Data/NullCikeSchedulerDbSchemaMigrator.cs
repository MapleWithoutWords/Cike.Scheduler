namespace Cike.Scheduler.Domain.Data;

/* This is used if database provider does't define
 * IBookStoreDbSchemaMigrator implementation.
 */
public class NullCikeSchedulerDbSchemaMigrator : ICikeSchedulerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
