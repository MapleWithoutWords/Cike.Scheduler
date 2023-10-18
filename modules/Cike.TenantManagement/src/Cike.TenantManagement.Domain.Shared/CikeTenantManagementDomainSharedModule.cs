using System;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;
using Cike.TenantManagement.Domain.Shared.Localization;

namespace Cike.TenantManagement.Domain.Shared
{
    [DependsOn(typeof(AbpValidationModule))]
    public class CikeTenantManagementDomainSharedModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CikeTenantManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CikeTenantManagementResource>("en")
                    .AddBaseTypes(
                        typeof(AbpValidationResource)
                    ).AddVirtualJson("/TenantManagement/Localization/Resources");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("Cike.TenantManagement", typeof(CikeTenantManagementResource));
            });
        }

    }
}
