namespace Cike.Scheduler.User.Application.Contracts.SchedulerUser.Dtos;

public class SchedulerUserGetListInput : PagedAndSortedResultRequestDto
{
    public string Keyword { get; set; }
}
