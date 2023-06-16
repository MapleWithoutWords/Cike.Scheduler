using Cike.Scheduler.Domain.JobAppResources;
using Cike.Scheduler.Domain.SchedulerJob.Aggregates;
using Cike.Scheduler.Domain.SchedulerJob.Entities;
using Cike.Scheduler.Domain.SchedulerTask.Aggregates;
using Cike.Scheduler.User.Domain.Aggregates;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Cike.Scheduler.EntityFrameworkCore;

[ReplaceDbContext(typeof(ISettingManagementDbContext))]
[ReplaceDbContext(typeof(ITenantManagementDbContext))]
[ReplaceDbContext(typeof(ICikeSchedulerUserDbContext))]
[ConnectionStringName("Default")]
public class CikeSchedulerDbContext : AbpDbContext<CikeSchedulerDbContext>, ITenantManagementDbContext, ISettingManagementDbContext,ICikeSchedulerUserDbContext
{
    public CikeSchedulerDbContext(DbContextOptions<CikeSchedulerDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<TenantConnectionString> TenantConnectionStrings { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<SchedulerUser> Users { get; set; }

    public virtual DbSet<JobAppResource> JobAppResources { get; set; }

    public virtual DbSet<SchedulerJob> SchedulerJobs { get; set; }

    public virtual DbSet<SchedulerJobAppConfig> SchedulerJobAppConfigs { get; set; }

    public virtual DbSet<SchedulerJobHttpConfig> SchedulerJobHttpConfigs { get; set; }

    public virtual DbSet<SchedulerTask> SchedulerTasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ConfigureTenantManagement();
        modelBuilder.ConfigureSettingManagement();
        
        modelBuilder.Entity<SchedulerUser>()
            .ConfigureAbpUser();
    }
}
