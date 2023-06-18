namespace Cike.Scheduler.Domain.SchedulerTask.Aggregates;

public class SchedulerTask : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public int RunCount { get; private set; }

    /// <summary>
    /// 任务运行花费总时间（秒）
    /// </summary>
    public long RunTime { get; private set; }

    /// <summary>
    /// 任务执行的TraceId，方便对接SkyWalking之类的遥测系统
    /// </summary>
    [MaxLength(64)]
    public string TraceId { get; private set; } = string.Empty;

    public TaskRunStatus TaskStatus { get; private set; }

    public DateTimeOffset SchedulerTime { get; private set; }

    public DateTimeOffset TaskRunStartTime { get; private set; } = DateTimeOffset.MinValue;

    public DateTimeOffset TaskRunEndTime { get; private set; } = DateTimeOffset.MinValue;

    public Guid JobId { get; private set; }

    [MaxLength(256)]
    public string Origin { get; private set; } = string.Empty;

    [MaxLength(256)]
    public string WorkerHost { get; private set; } = string.Empty;

    public string Message { get; private set; } = string.Empty;

    public Guid OperatorId { get; private set; }
}
