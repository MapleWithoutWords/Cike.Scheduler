using Cike.Scheduler.User.Application.Contracts.SchedulerUserApp.Dtos;

namespace Cike.Scheduler.User.Application.Contracts.SchedulerUser;

public interface ISchedulerUserAppService : ICrudAppService<SchedulerUserGetListOutput, Guid, SchedulerUserGetListInput, SchedulerUserCreateUpdateInput>
{
    public Task<LoginOutput> LoginAsync(LoginInput input);
}
