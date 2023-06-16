namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

/// <summary>
/// 阻塞策略
/// </summary>
public enum ScheduleBlockStrategyTypes
{
    [Description("串行-等待上次任务完成")]
    Serial = 1,
    [Description("并行-同时运行")]
    Parallel,
    [Description("丢弃新的任务")]
    Discard,
    [Description("中断上次任务并运行")]
    Cover
}
