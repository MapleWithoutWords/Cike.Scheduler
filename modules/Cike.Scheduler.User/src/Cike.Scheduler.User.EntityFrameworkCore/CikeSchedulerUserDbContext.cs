using Cike.Scheduler.User.Domain.Aggregates;

namespace Cike.Scheduler.User.EntityFrameworkCore;

[ConnectionStringName("Default")]
public class CikeSchedulerUserDbContext : AbpDbContext<CikeSchedulerUserDbContext>, ICikeSchedulerUserDbContext
{
    public CikeSchedulerUserDbContext(DbContextOptions<CikeSchedulerUserDbContext> options) : base(options)
    {
    }

    public virtual DbSet<SchedulerUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SchedulerUser>()
            .ConfigureAbpUser();
    }
}
