using Cike.Scheduler.Domain.Shared.Localization;
using Microsoft.Extensions.Localization;
using Volo.Abp.TenantManagement;

namespace Cike.Scheduler.User.Application;

public class SchedulerUserAppService : CrudAppService<SchedulerUser, SchedulerUserGetListOutput, Guid, SchedulerUserGetListInput, SchedulerUserCreateUpdateInput>, ISchedulerUserAppService
{
    private readonly IRepository<Tenant, Guid> _tenantRepository;
    private readonly IConfiguration _configuration;
    public SchedulerUserAppService(IRepository<SchedulerUser, Guid> repository, IConfiguration configuration, IRepository<Tenant, Guid> tenantRepository) : base(repository)
    {
        _configuration = configuration;
        _tenantRepository = tenantRepository;
    }

    public override async Task<SchedulerUserGetListOutput> CreateAsync(SchedulerUserCreateUpdateInput input)
    {
        await ValidateAsync(input.UserName, input.Email, input.PhoneNumber);
        input.Password = input.Password.ToMd5();
        return await base.CreateAsync(input);
    }

    public override async Task<SchedulerUserGetListOutput> UpdateAsync(Guid id, SchedulerUserCreateUpdateInput input)
    {
        var entity = await GetEntityByIdAsync(id);

        await ValidateAsync(input.UserName, input.Email, input.PhoneNumber, id);
        input.Password = entity.Password;
        await MapToEntityAsync(input, entity);
        await Repository.UpdateAsync(entity, autoSave: true);

        return await MapToGetOutputDtoAsync(entity);
    }

    private async Task ValidateAsync(string userName, string email, string phoneNumber, Guid? id = null)
    {
        await CheckUserNameExistsAsync(userName, id);
        await CheckEmailExistsAsync(email, id);
        await CheckPhoneNumberExistsAsync(phoneNumber, id);
    }

    public async Task CheckUserNameExistsAsync(string userName, Guid? id = null)
    {
        var user = await Repository.FindAsync(e => e.UserName == userName && e.Id != id);
        if (user != null)
        {
            throw new UserFriendlyException(L["UserNameExists"]);
        }
    }

    public async Task CheckEmailExistsAsync(string email, Guid? id = null)
    {
        var user = await Repository.FindAsync(e => e.Email == email && e.Id != id);
        if (user != null)
        {
            throw new UserFriendlyException(L["EmailExists"]);
        }
    }

    public async Task CheckPhoneNumberExistsAsync(string phoneNumber, Guid? id = null)
    {
        var user = await Repository.FindAsync(e => e.PhoneNumber == phoneNumber && e.Id != id);
        if (user != null)
        {
            throw new UserFriendlyException(L["PhoneNumberExists"]);
        }
    }

    [AllowAnonymous]
    public async Task<LoginOutput> LoginAsync(LoginInput input)
    {
        var tenant = await _tenantRepository.FindAsync(e => e.Name == input.TenantName);
        if (tenant == null)
        {
            throw new UserFriendlyException("租户、用户名或密码错误");
        }

        using (CurrentTenant.Change(tenant.Id, tenant.Name))
        {
            var user = await Repository.FindAsync(e => e.UserName == input.UserName);
            if (user == null)
            {
                throw new UserFriendlyException(L["UserNameOrPasswordError"]);
            }
            if (user.Password != input.Password.ToMd5())
            {
                throw new UserFriendlyException(L["UserNameOrPasswordError"]);
            }

            var nowTime = DateTime.Now;
            var claims = new[]
            {
            new Claim(AbpClaimTypes.Name, user.Name),
            new Claim(AbpClaimTypes.TenantId, (user.TenantId==null?"":user.TenantId.ToString())),
            new Claim(AbpClaimTypes.UserName, user.UserName),
            new Claim(AbpClaimTypes.Email, user.Email),
            new Claim(AbpClaimTypes.PhoneNumber, user.PhoneNumber),
            new Claim(AbpClaimTypes.SurName, user.Surname),
            new Claim(AbpClaimTypes.UserId, user.Id.ToString()),
            new Claim(AbpClaimTypes.EmailVerified, "true".ToString()),
            new Claim(AbpClaimTypes.PhoneNumberVerified, "true".ToString()),
            new Claim(AbpClaimTypes.ClientId, "scheduler".ToString()),
            new Claim(AbpClaimTypes.Role, "scheduler".ToString()),
            new Claim("AbpTenantManagement.Tenants", "true".ToString()),
        };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
            var algorithm = SecurityAlgorithms.HmacSha256;
            var signingCredentials = new SigningCredentials(secretKey, algorithm);
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],     //Issuer
                _configuration["Jwt:Audience"],   //Audience
                claims,                          //Claims,
                nowTime,                    //notBefore
                nowTime.AddHours(4),    //expires
                signingCredentials
            );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return new LoginOutput()
            {
                AccessToken = token,
                Expire = nowTime.AddHours(4).Ticks,
            };
        }
    }
}
