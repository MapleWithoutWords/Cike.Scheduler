﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;

namespace Cike.TenantManagement.TestBase.Secrets;

[Dependency(ReplaceServices = true)]
public class TestAuthCurrentPrincipalAccessor : ThreadCurrentPrincipalAccessor
{
    protected override ClaimsPrincipal GetClaimsPrincipal()
    {
        return GetPrincipal();
    }

    private ClaimsPrincipal _principal;

    private ClaimsPrincipal GetPrincipal()
    {
        if (_principal == null)
        {
            lock (this)
            {
                if (_principal == null)
                {
                    _principal = new ClaimsPrincipal(
                        new ClaimsIdentity(
                            new List<Claim>
                            {
                                new Claim(AbpClaimTypes.UserId,"2e701e62-0953-4dd3-910b-dc6cc93ccb0d"),
                                new Claim(AbpClaimTypes.UserName,"admin"),
                                new Claim(AbpClaimTypes.Email,"admin@abp.io"),
                                new Claim(AbpClaimTypes.TenantId,"C913D62E-A8C7-5E86-B903-13A502185A71"),
                            }
                        )
                    );
                }
            }
        }

        return _principal;
    }
}
