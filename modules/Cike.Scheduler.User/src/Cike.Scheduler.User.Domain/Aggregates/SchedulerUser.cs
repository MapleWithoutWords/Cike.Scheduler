namespace Cike.Scheduler.User.Domain.Aggregates;

public class SchedulerUser : FullAuditedAggregateRoot<Guid>, IUser
{
    public SchedulerUser()
    {

    }
    public SchedulerUser(Guid id)
    {
        this.Id = id;
    }
    public string UserName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public bool IsActive { get; set; } = false;

    public bool EmailConfirmed { get; set; } = false;

    public string PhoneNumber { get; set; } = string.Empty;

    public bool PhoneNumberConfirmed { get; set; } = false;

    public string Password { get; set; } = string.Empty;

    public Guid? TenantId { get; set; }

    public object[] GetKeys()
    {
        return new object[] { Id, UserName, Email, Name, Surname, PhoneNumber, Password };
    }
}
