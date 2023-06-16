namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

/// <summary>
/// 调度过期策略
/// </summary>
public enum ScheduleExpiredStrategyTypes
{
    /// <summary>
    /// 立即运行一次
    /// </summary>
    ExecuteImmediately = 1,
    /// <summary>
    /// 忽略
    /// </summary>
    Ignore
}
