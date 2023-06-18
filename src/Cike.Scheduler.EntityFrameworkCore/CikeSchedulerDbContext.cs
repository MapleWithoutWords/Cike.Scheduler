using Cike.Scheduler.Domain.JobAppResources;
using Cike.Scheduler.Domain.SchedulerJob.Aggregates;
using Cike.Scheduler.Domain.SchedulerJob.Entities;
using Cike.Scheduler.Domain.SchedulerTask.Aggregates;
using Cike.Scheduler.EntityFrameworkCore.Convertions;
using Cike.Scheduler.User.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;

namespace Cike.Scheduler.EntityFrameworkCore;

[ReplaceDbContext(typeof(ISettingManagementDbContext))]
[ReplaceDbContext(typeof(ICikeSchedulerUserDbContext))]
[ConnectionStringName("Default")]
public class CikeSchedulerDbContext : AbpDbContext<CikeSchedulerDbContext>, ISettingManagementDbContext, ICikeSchedulerUserDbContext
{
    public CikeSchedulerDbContext(DbContextOptions<CikeSchedulerDbContext> options) : base(options)
    {
    }

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
        modelBuilder.ConfigureSettingManagement();

        modelBuilder.Entity<SchedulerUser>().ConfigureAbpUser();

        var entityBuilder = modelBuilder.Entity<SchedulerJobHttpConfig>();
        entityBuilder.Property(e => e.HttpHeaders).HasConversion<JsonValueConverter<List<KeyValuePair<string, string>>>>();
        entityBuilder.Property(e => e.HttpParameters).HasConversion<JsonValueConverter<List<KeyValuePair<string, string>>>>();
    }
}
