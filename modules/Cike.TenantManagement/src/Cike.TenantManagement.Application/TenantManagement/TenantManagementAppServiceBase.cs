using Cike.TenantManagement.Domain.Shared.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Localization;

namespace Cike.TenantManagement.Application.TenantManagement;

public abstract class TenantManagementAppServiceBase : ApplicationService
{
    protected TenantManagementAppServiceBase()
    {
        ObjectMapperContext = typeof(CikeTenantManagementApplicationModule);
        LocalizationResource = typeof(CikeTenantManagementResource);
    }
}
