namespace Cike.Scheduler.User.EntityFrameworkCore;

[DependsOn(new Type[] {
    typeof(CikeSchedulerUserDomainModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpUsersEntityFrameworkCoreModule),
})]
public class CikeSchedulerUserEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CikeSchedulerUserDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            /* The main point to change your DBMS.
             * See also BookStoreMigrationsDbContextFactory for EF Core tooling. */
            options.UseMySQL();
        });
    }
}