namespace Cike.Scheduler.EntityFrameworkCore;

public class EntityFrameworkCoreCikeSchedulerDbSchemaMigrator
    : ICikeSchedulerDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCikeSchedulerDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the BookStoreDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        var dbcontext = _serviceProvider.GetRequiredService<CikeSchedulerDbContext>();

        await dbcontext.Database.MigrateAsync();

        //Guid? tenantId = null;

        //if (!await dbcontext.Tenants.AnyAsync(e => e.Name != "Cike.Scheduler"))
        //{
        //    var tenantManager = _serviceProvider.GetRequiredService<ITenantManager>();
        //    var tenant = await tenantManager.CreateAsync("Cike.Scheduler");
        //    tenant.CreationTime = DateTime.UtcNow;
        //    tenantId = tenant.Id;
        //    await dbcontext.Tenants.AddAsync(tenant);
        //}

        //if (!dbcontext.Users.Any(e => e.Name == "admin" && e.TenantId == tenantId))
        //{
        //    await dbcontext.Users.AddAsync(new User.Domain.Aggregates.SchedulerUser(Guid.NewGuid())
        //    {
        //        UserName = "admin",
        //        Email = "admin@qq.com",
        //        Name = "超级管理员",
        //        Surname = "张三",
        //        PhoneNumber = "13133737905"
        //    });
        //}

        await dbcontext.SaveChangesAsync();
    }
}
