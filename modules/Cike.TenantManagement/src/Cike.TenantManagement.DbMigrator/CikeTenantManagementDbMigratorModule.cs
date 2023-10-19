using Cike.TenantManagement.Application.Contracts;
using Cike.TenantManagement.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Cike.TenantManagement.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(CikeTenantManagementEntityFraemworkCoreModule),
        typeof(CikeTenantManagementApplicationContractsModule)
        )]
    public class CikeTenantManagementDbMigratorModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);

            //context.Services.AddTransient<ICikeSchedulerDbSchemaMigrator, EntityFrameworkCoreCike.SchedulerDbSchemaMigrator>();
        }
    }
}
