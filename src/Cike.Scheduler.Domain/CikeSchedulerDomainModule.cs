namespace Cike.Scheduler.Domain;

[DependsOn(new Type[] {
    typeof(AbpEmailingModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(CikeSchedulerDomainSharedModule),
    typeof(CikeSchedulerUserDomainModule),
})]
public class CikeSchedulerDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        
    }
}