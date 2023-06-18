using Cike.Scheduler.Domain.Shared.SchedulerJob;

namespace Cike.Scheduler.Application.Contracts.SchedulerJob.Dtos;

public class SchedulerJobHttpConfigCreateUpdateInput
{
    public HttpMethods HttpMethod { get; private set; }

    public string RequestUrl { get; private set; } = string.Empty;

    public List<KeyValuePair<string, string>> HttpParameters { get; private set; } = new();

    public List<KeyValuePair<string, string>> HttpHeaders { get; private set; } = new();

    public string HttpBody { get; private set; } = string.Empty;

    public HttpVerifyTypes HttpVerifyType { get; private set; }

    public string VerifyContent { get; private set; } = string.Empty;
}
