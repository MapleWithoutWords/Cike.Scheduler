namespace Cike.Scheduler.Domain.Data;

public interface ICikeSchedulerDbSchemaMigrator
{
    Task MigrateAsync();
}
