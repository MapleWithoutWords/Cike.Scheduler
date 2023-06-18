using System.ComponentModel.DataAnnotations;

namespace Cike.Scheduler.User.Application.Contracts.SchedulerUserApp.Dtos;

public class LoginInput
{
    [Required]
    public string TenantName { get; set; }

    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}
