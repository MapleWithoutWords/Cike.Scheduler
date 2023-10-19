using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Cike.TenantManagement.Domain.TenantManagement.Data
{
    public interface ICikeTenantManagementDbMigrator
    {
        Task MigrateAsync();
    }

    public class NullCikeTenantManagementDbMigrator : ICikeTenantManagementDbMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}
