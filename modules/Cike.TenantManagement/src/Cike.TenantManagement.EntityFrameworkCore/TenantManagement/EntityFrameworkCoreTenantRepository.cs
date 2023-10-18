using Cike.TenantManagement.Domain.TenantManagement;
using Cike.TenantManagement.Domain.TenantManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace Cike.TenantManagement.EntityFrameworkCore.TenantManagement
{
    public class EntityFrameworkCoreTenantRepository : EfCoreRepository<ITenantManagementDbContext, Tenant, Guid>, ITenantRepository
    {
        public EntityFrameworkCoreTenantRepository(IDbContextProvider<ITenantManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        [Obsolete("Use FindAsync method.")]
        public Tenant FindById(Guid id, bool includeDetails = true)
        {
            return IncludeDetails(DbSet, includeDetails).FirstOrDefault(t => t.Id == id);
        }

        public Tenant FindByName(string name, bool includeDetails = true)
        {
            return IncludeDetails(DbSet, includeDetails).FirstOrDefault(t => t.Name == name);
        }

        public async Task<Tenant> FindByNameAsync(string name, bool includeDetails = true, CancellationToken cancellationToken = default)
        {
            return await IncludeDetails(DbSet, includeDetails).FirstOrDefaultAsync(t => t.Name == name, GetCancellationToken(cancellationToken));
        }

        public async Task<long> GetCountAsync(string filter = null, CancellationToken cancellationToken = default)
        {
            return await (await GetQueryableAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(), u => u.Name.Contains(filter))
                .CountAsync(cancellationToken: GetCancellationToken(cancellationToken));
        }

        public async Task<List<Tenant>> GetListAsync(string sorting = null, int maxResultCount = int.MaxValue, int skipCount = 0, string filter = null, bool includeDetails = false, CancellationToken cancellationToken = default)
        {
            return await IncludeDetails(await GetDbSetAsync())
                .WhereIf(!filter.IsNullOrWhiteSpace(),u => u.Name.Contains(filter))
                .OrderBy(sorting.IsNullOrEmpty() ? nameof(Tenant.Name) : sorting)
                .PageBy(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        [Obsolete("Use WithDetailsAsync method.")]
        public override IQueryable<Tenant> WithDetails()
        {
            return IncludeDetails(GetQueryable());
        }

        public override async Task<IQueryable<Tenant>> WithDetailsAsync()
        {
            return IncludeDetails(await GetQueryableAsync());
        }


        private IQueryable<Tenant> IncludeDetails(IQueryable<Tenant> queryable, bool includeDetails = true)
        {
            if (includeDetails)
            {
                return queryable.Include(t => t.ConnectionStrings);
            }

            return queryable;
        }
    }
}
