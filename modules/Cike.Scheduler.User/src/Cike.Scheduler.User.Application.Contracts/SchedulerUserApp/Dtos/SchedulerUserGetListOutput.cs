namespace Cike.Scheduler.User.Application.Contracts.SchedulerUser.Dtos;

public class SchedulerUserGetListOutput : ExtensibleFullAuditedEntityDto<Guid>
{
    public string UserName { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Surname { get; set; }

    public bool IsActive { get; set; }

    public bool EmailConfirmed { get; set; }

    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }
}
