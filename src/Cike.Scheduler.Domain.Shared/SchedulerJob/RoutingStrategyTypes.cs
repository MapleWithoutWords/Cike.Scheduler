namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

/// <summary>
/// 路由策略
/// </summary>
public enum RoutingStrategyTypes
{
    [Description("自动平均分配")]
    RoundRobin = 1,
    [Description("手动指定")]
    Specified
    // implement this routing strategy in next version
    //DynamicRatioApm
}
