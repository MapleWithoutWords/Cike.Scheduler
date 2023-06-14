namespace Cike.Scheduler.Domain.Shared;

[DependsOn(new Type[] {
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
})]
public class CikeSchedulerDomainSharedModule : AbpModule
{

}