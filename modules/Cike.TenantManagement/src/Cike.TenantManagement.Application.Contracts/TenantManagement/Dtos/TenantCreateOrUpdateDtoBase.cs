using Cike.TenantManagement.Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.ObjectExtending;
using Volo.Abp.Validation;

namespace Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;

public abstract class TenantCreateOrUpdateDtoBase : ExtensibleObject
{
    [Required]
    [DynamicStringLength(typeof(TenantConsts), nameof(TenantConsts.Length64))]
    [Display(Name = "TenantName")]
    public string Name { get; set; }

    public TenantCreateOrUpdateDtoBase() : base(false)
    {

    }
}
