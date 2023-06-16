namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

/// <summary>
/// 任务失败策略
/// </summary>
public enum FailedStrategyTypes
{
    [Description("自动重试")]
    Auto = 1,
    [Description("手动重试")]
    Manual
}
