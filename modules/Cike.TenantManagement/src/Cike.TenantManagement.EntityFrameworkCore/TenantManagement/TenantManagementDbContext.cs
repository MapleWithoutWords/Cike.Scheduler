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
public class TenantManagementDbContext : AbpDbContext<TenantManagementDbContext>, ITenantManagementDbContext
{

    public DbSet<Tenant> Tenants { get; set; }

    public DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    public TenantManagementDbContext(DbContextOptions<TenantManagementDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureTenantManagement();
    }
}
