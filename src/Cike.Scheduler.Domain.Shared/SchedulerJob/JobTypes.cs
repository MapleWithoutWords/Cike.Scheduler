
namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

/// <summary>
/// 任务类型
/// </summary>
public enum JobTypes
{
    [Description("JobApp")]
    JobApp = 1,
    [Description("Http")]
    Http,
}
