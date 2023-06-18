using Cike.Scheduler.Application.Contracts.SchedulerJob;
using Cike.Scheduler.Application.Contracts.SchedulerJob.Dtos;
using Cike.Scheduler.Domain.SchedulerJob.Aggregates;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Services;

namespace Cike.Scheduler.Application.SchedulerJobs;

[Authorize]
public class SchedulerJobAppService : CrudAppService<SchedulerJob, SchedulerJobGetOutput, SchedulerJobGetListOutput, Guid, SchedulerJobGetListInput, SchedulerJobCreateUpdateInput, SchedulerJobCreateUpdateInput>, ISchedulerJobAppService
{
    public SchedulerJobAppService(IRepository<SchedulerJob, Guid> repository) : base(repository)
    {
    }
}
