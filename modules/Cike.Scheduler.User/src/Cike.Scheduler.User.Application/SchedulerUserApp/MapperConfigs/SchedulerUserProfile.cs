using AutoMapper;

namespace Cike.Scheduler.User.Application.SchedulerUserApp.MapperConfigs;

public class SchedulerUserProfile : Profile
{
    public SchedulerUserProfile()
    {
        CreateMap<SchedulerUser, SchedulerUserGetListOutput>();

        CreateMap<SchedulerUserCreateUpdateInput, SchedulerUser>()
            .Ignore(e => e.IsActive)
            .Ignore(e => e.EmailConfirmed)
            .Ignore(e => e.PhoneNumberConfirmed)
            .Ignore(e => e.TenantId)
            .Ignore(e => e.Id)
            .IgnoreFullAuditedObjectProperties();
    }
}
