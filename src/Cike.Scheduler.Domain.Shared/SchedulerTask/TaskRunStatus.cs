namespace Cike.Scheduler.Domain.Shared.SchedulerTask;

public enum TaskRunStatus
{
    [Description("闲置")]
    Idle = 1,
    [Description("运行中")]
    Running,
    [Description("成功")]
    Success,
    [Description("失败")]
    Failure,
    [Description("超时")]
    Timeout,
    [Description("超时成功")]
    TimeoutSuccess,
    [Description("等待重试")]
    WaitToRetry,
    [Description("等待运行")]
    WaitToRun,
    [Description("忽略")]
    Ignore
}
