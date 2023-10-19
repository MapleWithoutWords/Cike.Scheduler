using Cike.TenantManagement.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseAutofac();

await builder.AddApplicationAsync<CikeTenantManagementWebModule>();
var app = builder.Build();

await app.InitializeApplicationAsync();

await app.RunAsync();
