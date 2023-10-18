using AutoMapper;
using Cike.TenantManagement.Domain.Shared;
using Cike.TenantManagement.Domain.TenantManagement.Entities;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

namespace Cike.TenantManagement.Domain.TenantManagement.MapperProfiles;

public class CikeTenantManagementDomainMappingProfile : Profile
{
    public CikeTenantManagementDomainMappingProfile()
    {
        CreateMap<Tenant, TenantConfiguration>()
            .ForMember(ti => ti.ConnectionStrings, opts =>
            {
                opts.MapFrom((tenant, ti) =>
                {
                    var connStrings = new ConnectionStrings();

                    foreach (var connectionString in tenant.ConnectionStrings)
                    {
                        connStrings[connectionString.Name] = connectionString.Value;
                    }

                    return connStrings;
                });
            })
            .ForMember(x => x.IsActive, x => x.Ignore());

        CreateMap<Tenant, TenantEto>();
    }
}
