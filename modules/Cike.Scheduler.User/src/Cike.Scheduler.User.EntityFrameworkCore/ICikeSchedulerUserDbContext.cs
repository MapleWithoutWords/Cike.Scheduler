using Cike.Scheduler.User.Domain.Aggregates;

namespace Cike.Scheduler.User.EntityFrameworkCore;

[IgnoreMultiTenancy]
public interface ICikeSchedulerUserDbContext : IEfCoreDbContext, IDisposable, IAsyncDisposable
{
    public DbSet<SchedulerUser> Users { get; set; }
}
