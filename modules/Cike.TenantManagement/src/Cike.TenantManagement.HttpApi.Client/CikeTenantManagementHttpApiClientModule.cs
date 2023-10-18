using Cike.TenantManagement.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Cike.TenantManagement.HttpApi.Client
{
    [DependsOn(typeof(AbpHttpClientModule))]
    [DependsOn(typeof(CikeTenantManagementApplicationContractsModule))]
    public class CikeTenantManagementHttpApiClientModule:AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddStaticHttpClientProxies(
                typeof(CikeTenantManagementApplicationContractsModule).Assembly,
                TenantManagementRemoteServiceConsts.RemoteServiceName
            );

            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CikeTenantManagementHttpApiClientModule>();
            });
        }
    }
}
