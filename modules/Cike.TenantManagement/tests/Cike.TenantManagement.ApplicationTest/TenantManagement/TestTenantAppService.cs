using Cike.TenantManagement.Application.Contracts.TenantManagement;
using Cike.TenantManagement.Application.Contracts.TenantManagement.Dtos;
using Cike.TenantManagement.Application.TenantManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Cike.TenantManagement.ApplicationTest.TenantManagement
{
    public class TestTenantAppService : CikeTenantManagementApplicationTestBase
    {
        private ITenantAppService _tenantAppService;
        public TestTenantAppService()
        {
            _tenantAppService = GetRequiredService<ITenantAppService>();
        }

        [Fact]
        public async Task TestCrudAsync()
        {
            var tenant = await _tenantAppService.CreateAsync(new TenantCreateDto
            {
                Name = "test",
                AdminEmailAddress = "test@qq.com",
                AdminPassword = "password",
            });

            tenant = await _tenantAppService.UpdateAsync(tenant.Id, new TenantUpdateDto
            {
                Name = "test2",
                ConcurrencyStamp = tenant.ConcurrencyStamp
            });

            await _tenantAppService.UpdateDefaultConnectionStringAsync(tenant.Id, "server=xxx;");

            tenant = await _tenantAppService.GetAsync(tenant.Id);
            var connectionstring=await _tenantAppService.GetDefaultConnectionStringAsync(tenant.Id);

            Assert.True(tenant.Name == "test2");
            Assert.True(connectionstring == "server=xxx;");


            await _tenantAppService.DeleteAsync(tenant.Id);
        }
    }
}
