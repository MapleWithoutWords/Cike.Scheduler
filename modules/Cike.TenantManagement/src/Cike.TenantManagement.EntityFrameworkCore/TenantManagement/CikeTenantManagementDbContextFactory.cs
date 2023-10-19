using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.TenantManagement.EntityFrameworkCore.TenantManagement
{
    public class CikeTenantManagementDbContextFactory : IDesignTimeDbContextFactory<TenantManagementDbContext>
    {
        public TenantManagementDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<TenantManagementDbContext>()
                .UseMySql(configuration.GetConnectionString("CikeTenantManagement"), MySqlServerVersion.LatestSupportedServerVersion);

            return new TenantManagementDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Cike.TenantManagement.DbMigrator/"))
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
