namespace Cike.Scheduler.Application.Contracts;

[DependsOn(new Type[] {
    typeof(CikeSchedulerDomainSharedModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule),
    typeof(CikeSchedulerUserApplicationContractsModule),
})]
public class CikeSchedulerApplicationContractsModule : AbpModule
{

}