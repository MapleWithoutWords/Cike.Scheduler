
using Cike.TenantManagement.DbMigrator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .AddAppSettingsSecretsJson()
        .ConfigureLogging((context, logging) => logging.ClearProviders())
        .ConfigureServices((hostContext, services) =>
        {
            services.AddHostedService<DbMigratorHostedService>();
        });

await CreateHostBuilder(args).RunConsoleAsync();