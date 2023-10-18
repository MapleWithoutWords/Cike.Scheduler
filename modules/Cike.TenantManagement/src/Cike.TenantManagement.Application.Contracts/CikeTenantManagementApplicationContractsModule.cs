using Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;
using Cike.TenantManagement.Domain.Shared;
using System;
using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending.Modularity;
using Volo.Abp.Threading;

namespace Cike.TenantManagement.Application.Contracts
{
    [DependsOn(typeof(AbpDddApplicationContractsModule))]
    [DependsOn(typeof(CikeTenantManagementDomainSharedModule))]
    public class CikeTenantManagementApplicationContractsModule:AbpModule
    {

        private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

        public override void PostConfigureServices(ServiceConfigurationContext context)
        {
            OneTimeRunner.Run(() =>
            {
                ModuleExtensionConfigurationHelper
                    .ApplyEntityConfigurationToApi(
                        TenantManagementModuleExtensionConsts.ModuleName,
                        TenantManagementModuleExtensionConsts.EntityNames.Tenant,
                        getApiTypes: new[] { typeof(TenantDto) },
                        createApiTypes: new[] { typeof(TenantCreateDto) },
                        updateApiTypes: new[] { typeof(TenantUpdateDto) }
                    );
            });
        }
    }
}
