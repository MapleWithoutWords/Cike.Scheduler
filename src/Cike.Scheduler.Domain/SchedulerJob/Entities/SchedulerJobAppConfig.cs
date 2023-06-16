namespace Cike.Scheduler.Domain.SchedulerJob.Entities;

public class SchedulerJobAppConfig : Entity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public Guid JobAppResourceId { get; set; }

    public string JobEntryAssembly { get; set; } = string.Empty;

    public string JobEntryClassName { get; set; } = string.Empty;

    public string JobParams { get; set; } = string.Empty;
}
