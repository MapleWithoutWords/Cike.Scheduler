namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

/// <summary>
/// 运行超时策略
/// </summary>
public enum RunTimeoutStrategyTypes
{
    [Description("运行失败策略")]
    RunFailedStrategy = 1,
    [Description("忽略超时")]
    IgnoreTimeout
}