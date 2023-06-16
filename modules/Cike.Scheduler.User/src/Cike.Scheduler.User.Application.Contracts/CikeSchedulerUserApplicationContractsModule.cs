namespace Cike.Scheduler.User.Application.Contracts;

[DependsOn(new Type[] {
    typeof(CikeSchedulerUserDomainSharedModule),
    typeof(AbpTenantManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule),
})]
public class CikeSchedulerUserApplicationContractsModule : AbpModule
{

}