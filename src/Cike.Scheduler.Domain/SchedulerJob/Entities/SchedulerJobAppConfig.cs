namespace Cike.Scheduler.Domain.SchedulerJob.Entities;

public class SchedulerJobAppConfig : Entity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public Guid SchedulerJobId { get; set; }

    public Guid JobAppResourceId { get; set; }

    [MaxLength(256)]
    public string JobEntryAssembly { get; set; } = string.Empty;

    [MaxLength(256)]
    public string JobEntryClassName { get; set; } = string.Empty;

    [MaxLength(128)]
    public string JobParams { get; set; } = string.Empty;
}
