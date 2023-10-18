using Volo.Abp.Data;

namespace Cike.TenantManagement.Domain.TenantManagement;

public static class CikeTenantManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = AbpCommonDbProperties.DbTablePrefix;

    public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

    public const string ConnectionStringName = "AbpTenantManagement";
}
