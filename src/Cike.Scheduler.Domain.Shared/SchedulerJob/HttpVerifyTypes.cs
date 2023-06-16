namespace Cike.Scheduler.Domain.Shared.SchedulerJob;

/// <summary>
/// Http验证成功类型
/// </summary>
public enum HttpVerifyTypes
{
    [Description("状态码200")]
    StatusCode200 = 1,
    [Description("自定义状态码")]
    CustomStatusCode,
    [Description("返回内容包含")]
    ContentContains,
    [Description("返回内容不包含")]
    ContentUnContains,
}

