using Cike.Scheduler.User.Application.Contracts.SchedulerUserApp.Dtos;

namespace Cike.Scheduler.User.Application;

public class SchedulerUserAppService : CrudAppService<SchedulerUser, SchedulerUserGetListOutput, Guid, SchedulerUserGetListInput, SchedulerUserCreateUpdateInput>, ISchedulerUserAppService
{
    public SchedulerUserAppService(IRepository<SchedulerUser, Guid> repository) : base(repository)
    {
    }

    public Task<LoginOutput> LoginAsync(LoginInput input)
    {
        throw new NotImplementedException();
    }
}
