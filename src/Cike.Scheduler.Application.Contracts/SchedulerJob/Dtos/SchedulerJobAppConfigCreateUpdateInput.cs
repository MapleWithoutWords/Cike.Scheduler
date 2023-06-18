namespace Cike.Scheduler.Application.Contracts.SchedulerJob.Dtos;

public class SchedulerJobAppConfigCreateUpdateInput
{
    public Guid JobAppResourceId { get; set; }

    [MaxLength(256)]
    public string JobEntryAssembly { get; set; } = string.Empty;

    [MaxLength(256)]
    public string JobEntryClassName { get; set; } = string.Empty;

    [MaxLength(128)]
    public string JobParams { get; set; } = string.Empty;
}
