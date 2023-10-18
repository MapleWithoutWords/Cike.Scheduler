using AutoMapper;
using Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;
using Cike.TenantManagement.Domain.TenantManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cike.TenantManagement.Application.TenantManagement.MappingProfile
{
    public class CikeTenantManagementApplicationAutoMapperProfile : Profile
    {
        public CikeTenantManagementApplicationAutoMapperProfile()
        {
            CreateMap<Tenant, TenantDto>()
                .MapExtraProperties();
        }
    }
}
