using Cike.TenantManagement.Domain;
using Cike.TenantManagement.EntityFrameworkCore.TenantManagement;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Cike.TenantManagement.EntityFrameworkCore
{
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    [DependsOn(typeof(CikeTenantManagementDomainModule))]
    public class CikeTenantManagementEntityFraemworkCoreModule : AbpModule
    {

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TenantManagementDbContext>(options =>
            {
                options.AddDefaultRepositories<ITenantManagementDbContext>();
            });

            context.Services.Configure<AbpDbContextOptions>(options =>
            {
                options.UseMySQL();
            });
        }
    }
}