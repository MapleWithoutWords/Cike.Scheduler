using Cike.TenantManagement.Application.Contracts;
using Cike.TenantManagement.Application.TenantManagement.MappingProfile;
using Cike.TenantManagement.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace Cike.TenantManagement.Application;

[DependsOn(typeof(AbpDddApplicationModule))]
[DependsOn(typeof(CikeTenantManagementDomainModule))]
[DependsOn(typeof(CikeTenantManagementApplicationContractsModule))]
public class CikeTenantManagementApplicationModule : AbpModule
{

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<CikeTenantManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<CikeTenantManagementApplicationAutoMapperProfile>(validate: true);
        });
    }
}