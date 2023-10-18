using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Domain.Entities;

namespace Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;

public class TenantUpdateDto : TenantCreateOrUpdateDtoBase, IHasConcurrencyStamp
{
    public string ConcurrencyStamp { get; set; }
}
