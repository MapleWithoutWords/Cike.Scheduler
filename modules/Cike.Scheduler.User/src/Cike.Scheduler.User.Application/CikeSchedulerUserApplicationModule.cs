namespace Cike.Scheduler.User.Application;

[DependsOn(new Type[] {
    typeof(CikeSchedulerUserDomainModule),
    typeof(CikeSchedulerUserApplicationContractsModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
})]
public class CikeSchedulerUserApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<CikeSchedulerUserApplicationModule>();
        });
    }
}