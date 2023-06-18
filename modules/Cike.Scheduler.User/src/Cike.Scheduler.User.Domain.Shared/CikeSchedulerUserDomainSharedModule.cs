using Cike.Scheduler.Domain.Shared.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Cike.Scheduler.User.Domain.Shared;

[DependsOn(new Type[] {
    typeof(AbpUsersDomainSharedModule),
    typeof(AbpLocalizationModule),
})]
public class CikeSchedulerUserDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<CikeSchedulerUserDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<CikeSchedulerUserResource>("en")
                .AddVirtualJson("/Localization/Resources");
        });
    }
}