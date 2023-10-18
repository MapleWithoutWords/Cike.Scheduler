using Cike.TenantManagement.Domain.Shared;
using Cike.TenantManagement.Domain.TenantManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Cike.TenantManagement.EntityFrameworkCore.TenantManagement;

public static class CikeTenantManagementDbContextModelCreatingExtensions
{
    public static void ConfigureTenantManagement(
        this ModelBuilder builder)
    {
        Check.NotNull(builder, nameof(builder));

        if (builder.IsTenantOnlyDatabase())
        {
            return;
        }

        builder.Entity<Tenant>(b =>
        {
            b.ToTable(TenantConsts.DbTablePrefix + "Tenants", TenantConsts.DbSchema);

            b.ConfigureByConvention();

            b.Property(t => t.Name).IsRequired().HasMaxLength(TenantConsts.Length64);

            b.HasMany(u => u.ConnectionStrings).WithOne().HasForeignKey(uc => uc.TenantId).IsRequired();

            b.HasIndex(u => u.Name);

            b.ApplyObjectExtensionMappings();
        });

        builder.Entity<TenantConnectionString>(b =>
        {
            b.ToTable(TenantConsts.DbTablePrefix + "TenantConnectionStrings", TenantConsts.DbSchema);

            b.ConfigureByConvention();

            b.HasKey(x => new { x.TenantId, x.Name });

            b.Property(cs => cs.Name).IsRequired().HasMaxLength(TenantConsts.Length64);
            b.Property(cs => cs.Value).IsRequired().HasMaxLength(TenantConsts.Length1024);

            b.ApplyObjectExtensionMappings();
        });

        builder.TryConfigureObjectExtensions<TenantManagementDbContext>();
    }
}
