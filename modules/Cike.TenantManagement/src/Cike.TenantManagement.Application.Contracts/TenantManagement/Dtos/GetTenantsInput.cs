using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos
{
    public class GetTenantsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
