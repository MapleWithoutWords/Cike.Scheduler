namespace Cike.Scheduler.Domain.Shared;

[DependsOn(new Type[] {
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(CikeSchedulerUserDomainSharedModule),
})]
public class CikeSchedulerDomainSharedModule : AbpModule
{

}