
namespace Cike.Scheduler.Application.Contracts.SchedulerJob.Dtos;

public class SchedulerJobAppConfigGetOutput : EntityDto<Guid>
{
    public Guid JobAppResourceId { get; set; }

    public string JobEntryAssembly { get; set; } = string.Empty;

    public string JobEntryClassName { get; set; } = string.Empty;

    public string JobParams { get; set; } = string.Empty;
}
