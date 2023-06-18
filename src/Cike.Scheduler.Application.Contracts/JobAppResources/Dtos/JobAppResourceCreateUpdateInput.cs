namespace Cike.Scheduler.Application.Contracts.JobAppResources.Dtos;

public class JobAppResourceCreateUpdateInput
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required(AllowEmptyStrings = true)]
    public string Description { get; set; } = string.Empty;

    [Required]
    public string FilePath { get; set; } = string.Empty;

    [Required]
    public string Version { get; set; } = string.Empty;
}
