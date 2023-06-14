using Cike.Scheduler.Application.Contracts;
using Cike.Scheduler.Domain.Data;
using Cike.Scheduler.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Acme.BookStore.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(CikeSchedulerEntityFrameworkCoreModule),
    typeof(CikeSchedulerApplicationContractsModule)
    )]
public class CikeSchedulerDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);

        //context.Services.AddTransient<ICikeSchedulerDbSchemaMigrator, EntityFrameworkCoreCike.SchedulerDbSchemaMigrator>();
    }
}
