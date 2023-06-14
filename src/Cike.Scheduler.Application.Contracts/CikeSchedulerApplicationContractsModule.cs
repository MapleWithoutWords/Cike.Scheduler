namespace Cike.Scheduler.Application.Contracts;

[DependsOn(new Type[] {
    typeof(CikeSchedulerDomainSharedModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule),
})]
public class CikeSchedulerApplicationContractsModule : AbpModule
{

}