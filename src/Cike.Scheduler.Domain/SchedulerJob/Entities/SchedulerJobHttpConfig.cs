using Volo.Abp.Domain.Values;

namespace Cike.Scheduler.Domain.SchedulerJob.Entities;

public class SchedulerJobHttpConfig :  Entity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public Guid SchedulerJobId { get; set; }

    public HttpMethods HttpMethod { get; private set; }

    [MaxLength(256)]
    public string RequestUrl { get; private set; } = string.Empty;

    public List<KeyValuePair<string, string>> HttpParameters { get; private set; } = new();

    public List<KeyValuePair<string, string>> HttpHeaders { get; private set; } = new();

    public string HttpBody { get; private set; } = string.Empty;

    public HttpVerifyTypes HttpVerifyType { get; private set; }

    public string VerifyContent { get; private set; } = string.Empty;
}
