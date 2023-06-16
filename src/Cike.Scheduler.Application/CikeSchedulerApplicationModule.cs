using Cike.Scheduler.User.Application;

namespace Cike.Scheduler.Application;

[DependsOn(new Type[] {
    typeof(CikeSchedulerDomainModule),
    typeof(CikeSchedulerApplicationContractsModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(CikeSchedulerUserApplicationModule),
})]
public class CikeSchedulerApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CikeSchedulerApplicationModule>();
        });
    }
}