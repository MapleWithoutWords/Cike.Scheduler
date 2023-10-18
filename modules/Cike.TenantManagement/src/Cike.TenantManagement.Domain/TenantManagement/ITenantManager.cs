using System.Threading.Tasks;
using Cike.TenantManagement.Domain.TenantManagement.Entities;
using JetBrains.Annotations;
using Volo.Abp.Domain.Services;

namespace Cike.TenantManagement.Domain.TenantManagement;

public interface ITenantManager : IDomainService
{
    [NotNull]
    Task<Tenant> CreateAsync([NotNull] string name);

    Task ChangeNameAsync([NotNull] Tenant tenant, [NotNull] string name);
}
