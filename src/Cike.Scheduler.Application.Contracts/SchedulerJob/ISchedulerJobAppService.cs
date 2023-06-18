using Cike.Scheduler.Application.Contracts.SchedulerJob.Dtos;
using Volo.Abp.Application.Services;

namespace Cike.Scheduler.Application.Contracts.SchedulerJob;

public interface ISchedulerJobAppService : ICrudAppService<SchedulerJobGetOutput, SchedulerJobGetListOutput, Guid, SchedulerJobGetListInput, SchedulerJobCreateUpdateInput, SchedulerJobCreateUpdateInput>
{
}
