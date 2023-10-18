using Cike.TenantManagement.Domain.Shared;
using Cike.TenantManagement.Domain.TenantManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;

namespace Cike.TenantManagement.EntityFrameworkCore.TenantManagement;

[IgnoreMultiTenancy]
[ConnectionStringName(TenantConsts.ConnectionStringName)]
public interface ITenantManagementDbContext : IEfCoreDbContext
{
    DbSet<Tenant> Tenants { get; }

    DbSet<TenantConnectionString> TenantConnectionStrings { get; }
}
