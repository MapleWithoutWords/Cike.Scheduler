namespace Cike.Scheduler.Domain.JobAppResources;

public class JobAppResource : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;
}
