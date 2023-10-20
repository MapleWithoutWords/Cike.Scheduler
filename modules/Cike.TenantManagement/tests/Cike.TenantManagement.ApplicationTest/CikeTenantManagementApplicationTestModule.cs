using Cike.TenantManagement.Application;
using Cike.TenantManagement.EntityFrameworkCore;
using Cike.TenantManagement.TestBase;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Modularity;
using Cike.TenantManagement.EntityFrameworkCore.TenantManagement;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Cike.TenantManagement.ApplicationTest
{
    [DependsOn(typeof(CikeTenantManagementTestBaseModule))]
    [DependsOn(typeof(CikeTenantManagementApplicationModule))]
    [DependsOn(typeof(CikeTenantManagementEntityFraemworkCoreModule))]
    public class CikeTenantManagementApplicationTestModule : AbpModule
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
                //options.Configure(context =>
                //{
                //    //context.DbContextOptions.UseSqlite(_sqliteConnection);
                //    context.DbContextOptions.UseMySql();
                //});
                options.UseMySQL();
                //options.Configure(context =>
                //{
                //    context.DbContextOptions.UseMySql(_sqliteConnection);
                //});
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

            var options = new DbContextOptionsBuilder<TenantManagementDbContext>()
                .UseSqlite(connection)
                .Options;

            using (var context = new TenantManagementDbContext(options))
            {
                context.GetService<IRelationalDatabaseCreator>().CreateTables();
            }

            return connection;
        }
    }
}
