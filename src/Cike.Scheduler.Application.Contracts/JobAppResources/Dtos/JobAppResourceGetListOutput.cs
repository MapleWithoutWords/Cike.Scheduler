namespace Cike.Scheduler.Application.Contracts.JobAppResources.Dtos;

public class JobAppResourceGetListOutput : FullAuditedEntityDto<Guid>
{
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string FilePath { get; set; } = string.Empty;

    public string Version { get; set; } = string.Empty;
}
