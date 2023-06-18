using Cike.Scheduler.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Cike.Scheduler.Domain.Shared;

[DependsOn(new Type[] {
    typeof(AbpTenantManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(CikeSchedulerUserDomainSharedModule),
    typeof(AbpLocalizationModule),
})]
public class CikeSchedulerDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CikeSchedulerDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<CikeSchedulerResource>("en")
                .AddVirtualJson("/Localization/Resources");
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.DefaultResourceType = typeof(CikeSchedulerResource);
        });
    }
}