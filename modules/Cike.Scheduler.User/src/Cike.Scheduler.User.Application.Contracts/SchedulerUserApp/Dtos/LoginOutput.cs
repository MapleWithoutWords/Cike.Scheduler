namespace Cike.Scheduler.User.Application.Contracts.SchedulerUserApp.Dtos;

public class LoginOutput
{
    public string AccessToken { get; set; }

    public long Expire { get; set; }
}
