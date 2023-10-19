using Cike.TenantManagement.Domain.TenantManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Cike.TenantManagement.EntityFrameworkCore.TenantManagement
{
    public class EntityFrameworkCoreCikeTenantManagementDbMigrator : ICikeTenantManagementDbMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;
        public EntityFrameworkCoreCikeTenantManagementDbMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task MigrateAsync()
        {

            await _serviceProvider
                .GetRequiredService<TenantManagementDbContext>()
                .Database
                .MigrateAsync();

            //await Console.Out.WriteLineAsync($"Tenant:{dbcontext.Tenants.Any()}");
        }
    }
}
