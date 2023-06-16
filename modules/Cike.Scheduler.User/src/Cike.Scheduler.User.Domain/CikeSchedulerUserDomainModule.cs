namespace Cike.Scheduler.User.Domain;

[DependsOn(new Type[] {
    typeof(AbpUsersDomainModule),
    typeof(CikeSchedulerUserDomainSharedModule),
})]
public class CikeSchedulerUserDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
        
    }
}