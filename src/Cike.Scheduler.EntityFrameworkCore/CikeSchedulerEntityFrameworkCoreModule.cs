namespace Cike.Scheduler.EntityFrameworkCore;

[DependsOn(new Type[] {
    typeof(CikeSchedulerDomainModule),
    typeof(AbpEntityFrameworkCoreMySQLModule),
    typeof(AbpTenantManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
})]
public class CikeSchedulerEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<CikeSchedulerDbContext>(options =>
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