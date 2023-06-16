namespace Cike.Scheduler.User.Domain.Shared;

[DependsOn(new Type[] {
    typeof(AbpUsersDomainSharedModule),
})]
public class CikeSchedulerUserDomainSharedModule : AbpModule
{

}