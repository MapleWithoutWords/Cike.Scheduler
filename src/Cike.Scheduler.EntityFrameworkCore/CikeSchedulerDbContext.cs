using Cike.Scheduler.Domain.Consts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Settings;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
namespace Cike.Scheduler.EntityFrameworkCore;

[ReplaceDbContext(typeof(ISettingManagementDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ConnectionStringName("Default")]
public class CikeSchedulerDbContext : AbpDbContext<CikeSchedulerDbContext>, ITenantManagementDbContext, ISettingManagementDbContext
{
    public CikeSchedulerDbContext(DbContextOptions<CikeSchedulerDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureTenantManagement();
        modelBuilder.ConfigureSettingManagement();
    }
}
