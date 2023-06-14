namespace Cike.Scheduler.WebApi;

[DependsOn(new Type[] {
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(CikeSchedulerApplicationModule),
    typeof(CikeSchedulerEntityFrameworkCoreModule),
    typeof(AbpSwashbuckleModule)
})]
public class CikeSchedulerWebApiModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(CikeSchedulerApplicationModule).Assembly);
        });


        context.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(builder =>
            {
                builder
                    .WithOrigins(
                    //configuration["App:CorsOrigins"]
                    //    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                    //    .Select(o => o.RemovePostFix("/"))
                    //    .ToArray()
                    )
                    .WithAbpExposedHeaders()
                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials();
            });
        });


        context.Services.AddAbpSwaggerGen(
            //configuration["AuthServer:Authority"],
            //new Dictionary<string, string>
            //{
            //    {"BookStore", "BookStore API"}
            //},
            options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BookStore API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                options.CustomSchemaIds(type => type.FullName);
            });
    }

    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }


        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();

        app.UseMultiTenancy();

        app.UseUnitOfWork();
        app.UseAuthorization();

        app.UseSwagger();
        app.UseAbpSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API");
        });

        app.UseAuditing();
        app.UseConfiguredEndpoints();
    }
}
