using Volo.Abp.Data;

namespace Cike.TenantManagement.Domain.Shared;

public static class TenantConsts
{
    public static string DbTablePrefix { get; set; } = "Cike";

    public static string DbSchema { get; set; } = AbpCommonDbProperties.DbSchema;

    public const string ConnectionStringName = "CikeTenantManagement";


    /// <summary>
    /// Default value: 64
    /// </summary>
    public static int Length64 { get; set; } = 64;

    /// <summary>
    /// Default value: 128
    /// </summary>
    public static int Length128 { get; set; } = 128;

    /// <summary>
    /// Default value: 256
    /// </summary>
    public static int Length256 { get; set; } = 256; 
    public static int Length512 { get; set; } = 512; 
    public static int Length1024 { get; set; } = 1024; 
}
