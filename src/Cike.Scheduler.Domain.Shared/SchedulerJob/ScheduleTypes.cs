namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

public enum ScheduleTypes
{
    [Description("手动运行")]
    ManualRun = 1,
    [Description("Cron表达式")]
    Cron
}
