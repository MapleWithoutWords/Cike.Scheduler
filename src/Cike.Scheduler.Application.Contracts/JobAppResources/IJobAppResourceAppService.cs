using Cike.Scheduler.Application.Contracts.JobAppResources.Dtos;
using Volo.Abp.Application.Services;

namespace Cike.Scheduler.Application.Contracts.JobAppResources;

public interface IJobAppResourceAppService : ICrudAppService<JobAppResourceGetListOutput, Guid, JobAppResourceGetListInput, JobAppResourceCreateUpdateInput>
{
}
