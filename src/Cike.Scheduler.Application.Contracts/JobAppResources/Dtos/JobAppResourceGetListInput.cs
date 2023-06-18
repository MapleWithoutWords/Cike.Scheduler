namespace Cike.Scheduler.Application.Contracts.JobAppResources.Dtos;

public class JobAppResourceGetListInput : PagedAndSortedResultRequestDto
{
    public string Keyword { get; set; } = string.Empty;
}
