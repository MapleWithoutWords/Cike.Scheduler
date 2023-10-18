using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;

public class TenantDto : ExtensibleEntityDto<Guid>, IHasConcurrencyStamp
{
    public string Name { get; set; }

    public string ConcurrencyStamp { get; set; }
}
