using Cike.Scheduler.Application;
using Cike.Scheduler.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Modularity;
using Cike.Scheduler.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Cike.Scheduler.TestBase;

namespace Acme.BookStore;

[DependsOn(
    new Type[] {
    typeof(CikeSchedulerApplicationModule),
    typeof(CikeSchedulerDomainModule),
    typeof(CikeSchedulerEntityFrameworkCoreModule),
    typeof(CikeSchedulerTestBaseModule),
    })]
public class CikeSchedulerApplicationTestModule : AbpModule
{

    private SqliteConnection _sqliteConnection;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureInMemorySqlite(context.Services);
    }

    private void ConfigureInMemorySqlite(IServiceCollection services)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();

        services.Configure<AbpDbContextOptions>(options =>
        {
            options.Configure(context =>
            {
                context.DbContextOptions.UseSqlite(_sqliteConnection);
            });
        });
    }

    public override void OnApplicationShutdown(ApplicationShutdownContext context)
    {
        _sqliteConnection.Dispose();
    }

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<CikeSchedulerDbContext>()
            .UseSqlite(connection)
            .Options;

        using (var context = new CikeSchedulerDbContext(options))
        {
            context.GetService<IRelationalDatabaseCreator>().CreateTables();
        }

        return connection;
    }
}
