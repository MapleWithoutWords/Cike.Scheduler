using Cike.Scheduler.User.Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        base.PreConfigureServices(context);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        Configure<AbpAspNetCoreMvcOptions>(options =>
        {
            options.ConventionalControllers.Create(typeof(CikeSchedulerApplicationModule).Assembly);
            options.ConventionalControllers.Create(typeof(CikeSchedulerUserApplicationModule).Assembly);
        });

        //注册服务
        context.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true, //是否验证Issuer
                ValidIssuer = configuration["Jwt:Issuer"], //发行人Issuer
                ValidateAudience = true, //是否验证Audience
                ValidAudience = configuration["Jwt:Audience"], //订阅人Audience
                ValidateIssuerSigningKey = true, //是否验证SecurityKey
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"])), //SecurityKey
                ValidateLifetime = true, //是否验证失效时间
                ClockSkew = TimeSpan.FromSeconds(30), //过期时间容错值，解决服务器端时间不同步问题（秒）
                RequireExpirationTime = true,
            };
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


                //jwt鉴权在swagger中的应用
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme{
                        Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"}
                        },new string[] { }
                    }
                });
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

        //app.UseMultiTenancy();

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
