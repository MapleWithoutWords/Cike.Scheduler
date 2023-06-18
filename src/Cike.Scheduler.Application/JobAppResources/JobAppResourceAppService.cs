namespace Cike.Scheduler.Application.JobAppResources;

public class JobAppResourceAppService : CrudAppService<JobAppResource, JobAppResourceGetListOutput, Guid, JobAppResourceGetListInput, JobAppResourceCreateUpdateInput>, IJobAppResourceAppService
{
    public JobAppResourceAppService(IRepository<JobAppResource, Guid> repository) : base(repository)
    {
    }

    protected override async Task<IQueryable<JobAppResource>> CreateFilteredQueryAsync(JobAppResourceGetListInput input)
    {
        var query = await ReadOnlyRepository.GetQueryableAsync();
        query = query.WhereIf(!input.Keyword.IsNullOrEmpty(),
                    e => e.Name.Contains(input.Keyword) || e.Version.Contains(input.Keyword));
        return query;
    }

    public override async Task<JobAppResourceGetListOutput> CreateAsync(JobAppResourceCreateUpdateInput input)
    {
        await ValidateAsync(input.Name, input.Version);
        return await base.CreateAsync(input);
    }

    public override async Task<JobAppResourceGetListOutput> UpdateAsync(Guid id, JobAppResourceCreateUpdateInput input)
    {
        await ValidateAsync(input.Name, input.Version, id);
        return await base.UpdateAsync(id, input);
    }

    private async Task ValidateAsync(string name, string version, Guid? id = null)
    {
        var resource = await Repository.FindAsync(e => e.Name == name && e.Version != version && e.Id != id);
        if (resource != null)
        {
            throw new UserFriendlyException($"已存在相同版本的【{name}】");
        }
    }
}
