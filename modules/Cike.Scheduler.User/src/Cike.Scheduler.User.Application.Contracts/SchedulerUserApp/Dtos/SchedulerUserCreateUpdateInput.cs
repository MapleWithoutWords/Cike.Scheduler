namespace Cike.Scheduler.User.Application.Contracts.SchedulerUser.Dtos;

public class SchedulerUserCreateUpdateInput
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public string PhoneNumber { get; set; }
}
