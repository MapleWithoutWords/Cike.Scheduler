using Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Cike.TenantManagement.Application.Contracts.TenantManagement;

public interface ITenantAppService : ICrudAppService<TenantDto, Guid, GetTenantsInput, TenantCreateDto, TenantUpdateDto>
{
    Task<string> GetDefaultConnectionStringAsync(Guid id);

    Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString);

    Task DeleteDefaultConnectionStringAsync(Guid id);
}
