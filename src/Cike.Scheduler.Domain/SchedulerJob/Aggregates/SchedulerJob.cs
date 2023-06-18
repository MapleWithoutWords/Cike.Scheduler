using Cike.Scheduler.Domain.Shared.SchedulerTask;
using System.ComponentModel.DataAnnotations;

namespace Cike.Scheduler.Domain.SchedulerJob.Aggregates;

public class SchedulerJob : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    [MaxLength(64)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(64)]
    public string Owner { get; set; } = string.Empty;

    public Guid OwnerId { get; set; }

    /// <summary>
    /// 定时类型：手动运行或者Cron
    /// </summary>
    public ScheduleTypes ScheduleType { get; set; }

    [MaxLength(64)]
    public string CronExpression { get; set; } = string.Empty;

    /// <summary>
    /// Job类型：http调用任务或者jobapp任务
    /// </summary>
    public JobTypes JobType { get; set; }

    /// <summary>
    /// 路由策略：手动指定worker或自动平均分配
    /// </summary>
    public RoutingStrategyTypes RoutingStrategy { get; set; }

    /// <summary>
    /// 执行任务的worker主机
    /// </summary>
    [MaxLength(256)]
    public string SpecifiedWorkerHost { get; set; } = string.Empty;

    /// <summary>
    /// 任务阻塞策略
    /// </summary>
    public ScheduleBlockStrategyTypes ScheduleBlockStrategy { get; set; }

    /// <summary>
    /// 调度过期策略：当前时间超过下一次运行时间，可以选择立即运行，或者忽略本次过期
    /// </summary>
    public ScheduleExpiredStrategyTypes ScheduleExpiredStrategy { get; set; }

    /// <summary>
    /// 运行超时策略
    /// </summary>
    public RunTimeoutStrategyTypes RunTimeoutStrategy { get; set; }

    /// <summary>
    /// 运行超时秒数：当前时间内任务没完成则认为超时了
    /// </summary>
    public int RunTimeoutSecond { get; set; }

    /// <summary>
    /// 失败策略
    /// </summary>
    public FailedStrategyTypes FailedStrategy { get; set; }

    /// <summary>
    /// 失败重试间隔秒数
    /// </summary>
    public int FailedRetryInterval { get; set; }

    /// <summary>
    /// 失败重试次数
    /// </summary>
    public int FailedRetryCount { get; set; }

    [MaxLength(512)]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// 运行结果回调通知地址
    /// </summary>
    [MaxLength(256)]
    public string NotifyUrl { get; set; } = string.Empty;

    /// <summary>
    /// 最近一次任务的调度时间
    /// </summary>
    public DateTimeOffset LastScheduleTime { get; set; } = DateTimeOffset.MinValue;

    /// <summary>
    /// 最近一次任务的运行开始时间
    /// </summary>
    public DateTimeOffset LastRunStartTime { get; set; } = DateTimeOffset.MinValue;

    /// <summary>
    /// 最近一次任务的运行结束时间
    /// </summary>
    public DateTimeOffset LastRunEndTime { get; set; } = DateTimeOffset.MinValue;

    /// <summary>
    /// 最近一次任务的运行状态
    /// </summary>
    public TaskRunStatus LastRunStatus { get; set; }
}
