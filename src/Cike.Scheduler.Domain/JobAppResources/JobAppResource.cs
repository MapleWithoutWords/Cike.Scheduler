namespace Cike.Scheduler.Domain.JobAppResources;

public class JobAppResource : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(256)]
    public string Description { get; set; } = string.Empty;

    [MaxLength(256)]
    public string FilePath { get; set; } = string.Empty;

    [MaxLength(32)]
    public string Version { get; set; } = string.Empty;
}
