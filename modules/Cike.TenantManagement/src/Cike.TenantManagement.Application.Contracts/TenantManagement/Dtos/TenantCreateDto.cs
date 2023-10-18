using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Auditing;

namespace Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;

public class TenantCreateDto : TenantCreateOrUpdateDtoBase
{
    [Required]
    [EmailAddress]
    [MaxLength(256)]
    public virtual string AdminEmailAddress { get; set; }

    [Required]
    [MaxLength(128)]
    [DisableAuditing]
    public virtual string AdminPassword { get; set; }
}
